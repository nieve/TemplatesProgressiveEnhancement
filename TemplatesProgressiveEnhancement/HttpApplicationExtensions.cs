using System.Web;

namespace TemplatesProgressiveEnhancement
{
    public static class HttpApplicationExtensions
    {
        public static TemplateRenderingConfigurationExpression ConfigureTemplateRendering(this HttpApplication app)
        {
            return new TemplateRenderingConfigurationExpression();
        }
    }
}