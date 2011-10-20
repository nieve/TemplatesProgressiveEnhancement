namespace TemplatesProgressiveEnhancement.Domain.Services.Interfaces
{
    public interface ITemplatesDomainFactory
    {
        Template CreateTemplate(string templateName);
        ITemplateModel GetTemplateModel(object innerModel);
    }
}