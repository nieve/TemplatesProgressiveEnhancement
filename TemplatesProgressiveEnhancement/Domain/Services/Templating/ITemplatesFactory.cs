namespace TemplatesProgressiveEnhancement.Domain.Services.Templating
{
    public interface ITemplatesFactory
    {
        Template CreateTemplate(string templateName);
        ITemplateModel GetTemplateModel(object innerModel);
    }
}