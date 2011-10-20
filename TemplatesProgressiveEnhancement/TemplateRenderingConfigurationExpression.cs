using TemplatesProgressiveEnhancement.Domain;
using TemplatesProgressiveEnhancement.Domain.Services.Impl;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement
{
    public class TemplateRenderingConfigurationExpression
    {
        private readonly IContainAppPath _appPathContainer;

        public TemplateRenderingConfigurationExpression(IContainAppPath appPathContainer)
        {
            _appPathContainer = appPathContainer;
        }

        internal TemplateRenderingConfigurationExpression()
        {
            _appPathContainer = new AppPathContainer();
        }

        public TemplateRenderingConfigurationExpression UseTemplateKey(ITemplateKey templateKey)
        {
            TemplatesCache.Resolver = new PropertyNameResolver(templateKey);
            return this;
        }

        public TemplateRenderingConfigurationExpression WithPath(string path)
        {
            var appPath = _appPathContainer.GetAppPath();
            path = path.StartsWith("/") ? path.TrimStart('/') : path;
            TemplatesCache.SetTemplatePath(appPath + path);
            return this;
        }

        public TemplateRenderingConfigurationExpression WithDefaults()
        {
            WithPath("Views/Templates");
            TemplatesCache.Resolver = new PropertyNameResolver();
            return this;
        }
    }
}