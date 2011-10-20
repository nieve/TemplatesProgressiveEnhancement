namespace TemplatesProgressiveEnhancement.Domain.Services.Interfaces
{
    internal interface IResolvePropertyName
    {
        ITemplateKey TemplateKey{get;}
        string Resolve(string templateKey);
        string ResolvePattern();
    }
}