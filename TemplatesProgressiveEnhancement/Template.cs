using System.Collections.Generic;
using System.Text.RegularExpressions;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;
using TemplatesProgressiveEnhancement.Domain;

namespace TemplatesProgressiveEnhancement
{
    public class Template
    {
        public string Text { get; private set; }
        private List<string> _propertyNames;
        internal string Name { get; private set; }
        private readonly ITemplatesDomainFactory _factory;

        public Template(string name, string text, ITemplatesDomainFactory factory)
        {
            Name = name;
            Text = text;
            _factory = factory;
        }

        private void PrepareDynamicRendering()
        {
            _propertyNames = new List<string>();
            var resolver = TemplatesCache.Resolver;
            var matches = Regex.Matches(Text, resolver.ResolvePattern());
            for (int i = 0; i < matches.Count; i++)
            {
                var propertyName = resolver.Resolve(matches[i].Value);
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