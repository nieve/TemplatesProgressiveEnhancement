namespace TemplatesProgressiveEnhancement.Domain.Services.Caching
{
    public interface ICacheTemplates
    {
        Template this[string name] { get; }
        void Insert(string name, Template template, string templateFile);
        bool Contains(string key);
    }
}