namespace TemplatesProgressiveEnhancement.Domain.Services.Caching
{
    public interface IAppCache
    {
        void SetTemplatePath(string templatePath);
        Template GetTemplate(string name);
        void CacheAllTemplates(string templatesPath);
    }
}