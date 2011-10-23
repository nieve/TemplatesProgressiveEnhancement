using TemplatesProgressiveEnhancement.Domain.Services.Caching;

namespace TemplatesProgressiveEnhancement.Domain.Services.Templating
{
    public class TemplatesFactory : ITemplatesFactory
    {
        public TemplatesFactory(IAppCache appCache)
        {
        }

        public TemplatesFactory()
        {
        }

        public Template CreateTemplate(string templateName)
        {
            var container = new TemplateDataContainer(templateName);
            return new Template(container.Name, container.Text, this);
        }

        public ITemplateModel GetTemplateModel(object innerModel)
        {
            return new TemplateViewModel(innerModel);
        }
    }
}