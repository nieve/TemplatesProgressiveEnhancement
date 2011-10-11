using System.Collections.Generic;

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
                var templateData = _factory.GetTemplateData(templatePath);
                var template = _factory.CreateTemplate(templateData);
                Templates.Add(template);
            }
        }

        internal IList<Template> Templates { get; set; }
    }
}