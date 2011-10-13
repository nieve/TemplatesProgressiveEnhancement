using System;
using System.Collections.Generic;
using System.IO;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain.Services.Impl
{
    internal class TemplatesFactory : ITemplatesFactory
    {
        public Template CreateTemplate(string templatePath)
        {
            var container = new TemplateDataContainer(templatePath);
            return new Template(container.Name, container.Text, this);
        }

        public IEnumerable<string> GetTemplatesPaths(string path)
        {
            return Directory.GetFiles(path);
        }

        public ITemplateModel GetTemplateModel(object innerModel)
        {
            return new TemplateViewModel(innerModel);
        }
    }
}