using System.Web;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain.Services.Impl
{
    class AppPathContainer : IContainAppPath
    {
        public string GetAppPath()
        {
            return HttpRuntime.AppDomainAppPath.Replace('\\', '/');
        }
    }
}