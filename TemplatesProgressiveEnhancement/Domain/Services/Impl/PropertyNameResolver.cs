using System;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain.Services.Impl
{
    internal class PropertyNameResolver : IResolvePropertyName
    {
        public PropertyNameResolver(ITemplateKey templateKey)
        {
            TemplateKey = templateKey;
        }

        public PropertyNameResolver()
        {
            TemplateKey = new DefaultTemplateKey();
        }

        public ITemplateKey TemplateKey
        {
            get; private set;
        }

        public string Resolve(string templateKey)
        {
            return templateKey.Replace(TemplateKey.LeftSide, "").Replace(TemplateKey.RightSide, "");
        }

        public string ResolvePattern()
        {
            return "\\{0}[a-zA-Z]*{1}".ToFormat(TemplateKey.LeftSide.Replace("[", "\\["), TemplateKey.RightSide);
        }
    }
}