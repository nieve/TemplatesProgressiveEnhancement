using TemplatesProgressiveEnhancement.Domain.Services;
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

        public void WithPath(string path)
        {
            var appPath = _appPathContainer.GetAppPath();
            path = path.StartsWith("/") ? path.TrimStart('/') : path;
            TemplatesCache.SetTemplatePath(appPath + path);
        }

        public void WithDefaults()
        {
            WithPath("Views/Templates");
        }
    }
}