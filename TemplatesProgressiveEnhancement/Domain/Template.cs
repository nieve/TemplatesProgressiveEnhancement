using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TemplatesProgressiveEnhancement.Domain.Services.Impl;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain
{
    public class Template
    {
        public string Text { get; private set; }
        private List<string> _propertyNames;
        internal string Name { get; private set; }
        private ITemplatesFactory _factory;

        internal Template(string name, string text)
        {
            Name = name;
            Text = text;
            _factory = new TemplatesFactory();
        }

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

        internal string Render<T>(T viewModel)
        {
            PrepareDynamicRendering();
            var model = _factory.GetTemplateModel(viewModel);
            foreach (var propName in _propertyNames)
            {
                var oldValue = "${" + propName + "}";
                var property = model.GetProperty(propName);
                Text = Text.Replace(oldValue, property);
            }
            return Text;
        }
    }
}