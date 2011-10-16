using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.XPath;
using TemplatesProgressiveEnhancement.Domain.Services.Impl;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement
{
    public static class ControllerExtensions
    {
        private static readonly ITemplatesFactory Factory = new TemplatesFactory();

        public static ContentResult TemplateList<T>(this Controller controller, string templateName, IEnumerable<T> models)
        {
            return Template(controller, templateName, models.ToArray());
        }

        public static ContentResult Template<T>(this Controller controller, string templateName, params T[] models)
        {
            var result = new ContentResult();
            var template = Factory.CreateTemplate(templateName);
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