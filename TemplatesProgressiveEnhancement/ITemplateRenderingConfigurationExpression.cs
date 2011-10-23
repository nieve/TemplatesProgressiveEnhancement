namespace TemplatesProgressiveEnhancement
{
    public interface ITemplateRenderingConfigurationExpression
    {
        void WithPath(string path);
        void WithDefaults();
    }
}