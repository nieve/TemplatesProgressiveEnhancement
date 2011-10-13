using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.XPath;

namespace TemplatesProgressiveEnhancement
{
    public static class ControllerExtensions
    {
        public static ContentResult Template<T>(this Controller controller, 
            string templateName, params T[] viewModels)
        {
            var result = new ContentResult();
            var renderedTemplates = viewModels.Select(model => {
                var template = TemplatesCache.GetTemplate(templateName);
                return template.Render(model);
            });
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