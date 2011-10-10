using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TemplatesProgressiveEnhancement.Domain
{
    internal class Template
    {
        private string _text;
        private List<string> _propertyNames;

        internal Template(string templatePath)
        {
            _text = File.ReadAllText(templatePath);
            var fileInfo = new FileInfo(templatePath);
            Name = fileInfo.Name.Replace(fileInfo.Extension, "");
        }

        internal string Name { get; private set; }

        internal void PrepareDynamicRendering()
        {
            _propertyNames = new List<string>();
            var matches = Regex.Matches(_text, "\\${[a-zA-Z]*}");
            for (int i = 0; i < matches.Count; i++)
            {
                var propertyName = matches[i].Value.Replace("${", "").Replace("}", "");
                _propertyNames.Add(propertyName);
            }
        }

        internal string Render<T>(T viewModel)
        {
            var model = new TemplateViewModel(viewModel);
            foreach (var propName in _propertyNames)
            {
                var oldValue = "${" + propName + "}";
                var property = model.GetProperty(propName);
                _text = _text.Replace(oldValue, property);
            }
            return _text;
        }
    }
}