using System.Web;
using TemplatesProgressiveEnhancement.Domain;

namespace TemplatesProgressiveEnhancement
{
    public class TemplatesExtractor
    {
        private readonly HttpApplication _app;

        internal TemplatesExtractor(HttpApplication app)
        {
            _app = app;
        }

        internal void ExtractFrom(string path)
        {
            var location = new TemplatesLocation(path);
            foreach (var template in location.Templates)
                template.PrepareDynamicRendering();

            TemplatesCache.Templates = location.Templates;
        }
    }
}