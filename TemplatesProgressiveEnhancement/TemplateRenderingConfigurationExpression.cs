using TemplatesProgressiveEnhancement.Domain.Services;
using TemplatesProgressiveEnhancement.Domain.Services.Caching;

namespace TemplatesProgressiveEnhancement
{
    public class TemplateRenderingConfigurationExpression : ITemplateRenderingConfigurationExpression
    {
        private readonly IContainAppPath _appPathContainer;
        private readonly IAppCache _appCache;

        public TemplateRenderingConfigurationExpression(IContainAppPath appPathContainer, IAppCache appCache)
        {
            _appPathContainer = appPathContainer;
            _appCache = appCache;
        }

        public TemplateRenderingConfigurationExpression()
        {
            _appPathContainer = new AppPathContainer();
            _appCache = new AppCache();
        }

        public void WithPath(string path)
        {
            var appPath = _appPathContainer.GetAppPath();
            path = path.StartsWith("/") ? path.TrimStart('/') : path;
            _appCache.SetTemplatePath(appPath + path);
            _appCache.CacheAllTemplates(appPath + path);
        }

        public void WithDefaults()
        {
            WithPath("Views/Templates");
        }
    }
}