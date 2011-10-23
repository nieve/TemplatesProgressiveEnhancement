using System.Web;

namespace TemplatesProgressiveEnhancement.Domain.Services
{
    class AppPathContainer : IContainAppPath
    {
        public string GetAppPath()
        {
            return HttpRuntime.AppDomainAppPath.Replace('\\', '/');
        }
    }
}