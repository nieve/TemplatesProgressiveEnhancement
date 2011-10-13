using System.Collections.Generic;

namespace TemplatesProgressiveEnhancement.Domain.Services.Interfaces
{
    public interface ITemplatesFactory
    {
        Template CreateTemplate(string templatePath);
        IEnumerable<string> GetTemplatesPaths(string path);
        ITemplateModel GetTemplateModel(object innerModel);
    }
}