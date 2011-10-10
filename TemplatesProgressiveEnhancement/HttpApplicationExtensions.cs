using System.Collections.Generic;
using System.Web;
using TemplatesProgressiveEnhancement.Domain;

namespace TemplatesProgressiveEnhancement
{
    internal static class TemplatesCache
    {
        internal static IList<Template> Templates { get; set; }
    }

    public static class HttpApplicationExtensions
    {
        public static TemplateRenderingConfigurationExpression ConfigureTemplateRendering(this HttpApplication app)
        {
            return new TemplateRenderingConfigurationExpression(app);
        }
    }
}