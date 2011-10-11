using System.Collections.Generic;

namespace TemplatesProgressiveEnhancement.Domain
{
    internal interface ITemplatesFactory
    {
        IContainTemplateData GetTemplateData(string templatePath);
        Template CreateTemplate(IContainTemplateData templateData);
        IEnumerable<string> GetTemplatesPaths(string path);
    }
}