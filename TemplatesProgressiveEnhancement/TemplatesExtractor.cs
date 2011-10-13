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

            TemplatesCache.SetTemplates(location.Templates);
        }
    }
}