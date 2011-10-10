using System.Linq;
using System.Web.Mvc;

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
            result.Content = string.Concat(renderedTemplates);
            return result;
        }
    }
}