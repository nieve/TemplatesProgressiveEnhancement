using System.Collections.Generic;
using System.Text.RegularExpressions;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;
using TemplatesProgressiveEnhancement.Domain;

namespace TemplatesProgressiveEnhancement.Domain
{
    public class Template
    {
        public string Text { get; private set; }
        private List<string> _propertyNames;
        internal string Name { get; private set; }
        private readonly ITemplatesFactory _factory;

        public Template(string name, string text, ITemplatesFactory factory)
        {
            Name = name;
            Text = text;
            _factory = factory;
        }

        private void PrepareDynamicRendering()
        {
            _propertyNames = new List<string>();
            var matches = Regex.Matches(Text, "\\${[a-zA-Z]*}");
            for (int i = 0; i < matches.Count; i++)
            {
                var propertyName = matches[i].Value.Replace("${", "").Replace("}", "");
                _propertyNames.Add(propertyName);
            }
        }

        public string Render<T>(T viewModel)
        {
            PrepareDynamicRendering();
            var text = Text;
            var model = _factory.GetTemplateModel(viewModel);
            foreach (var propName in _propertyNames)
            {
                var oldValue = "${" + propName + "}";
                var property = model.GetProperty(propName.Capitalise());
                text = text.Replace(oldValue, property);
            }
            return text;
        }
    }
}