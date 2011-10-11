using TemplatesProgressiveEnhancement.Domain;

namespace TemplatesProgressiveEnhancement
{
    public class TemplatesExtractor
    {
        internal TemplatesExtractor()
        {
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