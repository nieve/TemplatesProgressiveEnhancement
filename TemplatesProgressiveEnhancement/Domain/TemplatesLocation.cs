using System.Collections.Generic;
using TemplatesProgressiveEnhancement.Domain.Services.Impl;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain
{
    internal class TemplatesLocation
    {
        private readonly string _path;
        private readonly ITemplatesFactory _factory;

        public TemplatesLocation(string path)
        {
            _factory = new TemplatesFactory();
            _path = path;
            Templates = new List<Template>();
            LoadTemplates();
        }
        
        public TemplatesLocation(string path, ITemplatesFactory factory)
        {
            _factory = factory;
            _path = path;
            Templates = new List<Template>();
            LoadTemplates();
        }

        private void LoadTemplates()
        {
            foreach (var templatePath in _factory.GetTemplatesPaths(_path))
            {
                var template = _factory.CreateTemplate(templatePath);
                Templates.Add(template);
            }
        }

        internal IList<Template> Templates { get; set; }
    }
}