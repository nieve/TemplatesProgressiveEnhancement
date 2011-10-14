namespace TemplatesProgressiveEnhancement.Domain.Services.Interfaces
{
    public interface ITemplatesFactory
    {
        Template CreateTemplate(string templateName);
        ITemplateModel GetTemplateModel(object innerModel);
    }
}