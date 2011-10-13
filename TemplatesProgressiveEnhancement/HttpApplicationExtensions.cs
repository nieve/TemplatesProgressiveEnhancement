using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplatesProgressiveEnhancement.Domain;

namespace TemplatesProgressiveEnhancement
{
    internal static class TemplatesCache
    {
        private static IList<Template> Templates { get; set; }
        internal static Template GetTemplate(string name)
        {
            var template = Templates.Single(t => t.Name == name);
            return new Template(template.Name, template.Text);
        }

        public static void SetTemplates(IList<Template> templates)
        {
            Templates = templates;
        }
    }

    public static class HttpApplicationExtensions
    {
        public static TemplateRenderingConfigurationExpression ConfigureTemplateRendering(this HttpApplication app)
        {
            return new TemplateRenderingConfigurationExpression();
        }
    }
}