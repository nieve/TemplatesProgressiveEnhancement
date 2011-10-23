using System.Web;

namespace TemplatesProgressiveEnhancement
{
    public class JsDegradeableApplication : HttpApplication
    {
        protected static ITemplateRenderingConfigurationExpression ConfigureTemplateRendering()
        {
            //TODO: Add IoC- return ObjectFactory.Resolve<TemplateRenderingConfigurationExpression> + Register Factory/Registry.
            return new TemplateRenderingConfigurationExpression();
        }
    }
}