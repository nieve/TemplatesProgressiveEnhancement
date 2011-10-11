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
            var template = TemplatesCache.Templates.Single(t=>t.Name == templateName);
            var renderedTemplates = viewModels.Select(template.Render);
            var content = string.Concat(renderedTemplates);
            
            Stream stream = new MemoryStream(content.Select(Convert.ToByte).ToArray());
            var html = new XPathDocument(stream);
            var navigator = html.CreateNavigator();
            navigator.MoveToChild(XPathNodeType.All);
            var innerHtml = new MvcHtmlString(navigator.InnerXml);
            result.Content = innerHtml.ToHtmlString();
            return result;
        }
    }
}