using System.Collections.Generic;
using System.IO;

namespace TemplatesProgressiveEnhancement.Domain
{
    internal class TemplatesLocation
    {
        private readonly string _path;

        public TemplatesLocation(string path)
        {
            _path = path;
            Templates = new List<Template>();
            LoadTemplates();
        }

        private void LoadTemplates()
        {
            foreach (var templatePath in Directory.GetFiles(_path))
            {
                var template = new Template(templatePath);
                Templates.Add(template);
            }
        }

        internal IList<Template> Templates { get; set; }
    }
}