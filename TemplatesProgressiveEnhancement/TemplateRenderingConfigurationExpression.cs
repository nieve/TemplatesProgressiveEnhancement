namespace TemplatesProgressiveEnhancement
{
    public class TemplateRenderingConfigurationExpression
    {
        private readonly TemplatesExtractor _templatesExtractor;

        internal TemplateRenderingConfigurationExpression()
        {
            _templatesExtractor = new TemplatesExtractor();
        }

        public void WithPath(string path)
        {
            _templatesExtractor.ExtractFrom(path);
        }

        public void WithDefaults()
        {
            const string defaultPath = "../Views/Templates";
            _templatesExtractor.ExtractFrom(defaultPath);
        }
    }
}