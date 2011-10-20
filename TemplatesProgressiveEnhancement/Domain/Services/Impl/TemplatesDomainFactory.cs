using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain.Services.Impl
{
    internal class TemplatesDomainFactory : ITemplatesDomainFactory
    {
        public Template CreateTemplate(string templateName)
        {
            var container = new TemplateDataContainer(TemplatesCache.TemplatesPath + templateName + ".ascx");
            return new Template(container.Name, container.Text, this);
        }

        public ITemplateModel GetTemplateModel(object innerModel)
        {
            return new TemplateViewModel(innerModel);
        }
    }
}