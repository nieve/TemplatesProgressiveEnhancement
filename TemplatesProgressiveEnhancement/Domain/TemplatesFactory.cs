using System.Collections.Generic;
using System.IO;

namespace TemplatesProgressiveEnhancement.Domain
{
    internal class TemplatesFactory : ITemplatesFactory
    {
        public IContainTemplateData GetTemplateData(string templatePath)
        {
            return new TemplateDataContainer(templatePath);
        }

        public Template CreateTemplate(IContainTemplateData templateData)
        {
            return new Template(templateData);
        }

        public IEnumerable<string> GetTemplatesPaths(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}