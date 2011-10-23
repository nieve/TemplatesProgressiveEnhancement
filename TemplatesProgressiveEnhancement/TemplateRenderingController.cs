using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.XPath;
using TemplatesProgressiveEnhancement.Domain.Services.Caching;

namespace TemplatesProgressiveEnhancement
{
    public class TemplateRenderingController: Controller
    {
        private readonly IAppCache _cache;

        public TemplateRenderingController(IAppCache cache)
        {
            _cache = cache;
        }

        public TemplateRenderingController()
        {
            _cache = new AppCache();
        }

        public ContentResult TemplateList<T>(string templateName, IEnumerable<T> models)
        {
            return Template(templateName, models.ToArray());
        }

        public ContentResult Template<T>(string templateName, params T[] models)
        {
            var result = new ContentResult();
            var template = _cache.GetTemplate(templateName);
            var renderedTemplates = models.Select(template.Render);
            var htmlElements = renderedTemplates.Select(ExtractHtml);
            var content = string.Concat(htmlElements);

            result.Content = content;
            return result;
        }

        private static string ExtractHtml(string content)
        {
            Stream stream = new MemoryStream(content.Select(Convert.ToByte).ToArray());
            var html = new XPathDocument(stream);
            var navigator = html.CreateNavigator();
            navigator.MoveToChild(XPathNodeType.All);
            var innerHtml = new MvcHtmlString(navigator.InnerXml);
            return innerHtml.ToHtmlString();
        }
    }
}