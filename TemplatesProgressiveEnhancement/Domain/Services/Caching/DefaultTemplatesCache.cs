using System;
using System.Web;
using System.Web.Caching;

namespace TemplatesProgressiveEnhancement.Domain.Services.Caching
{
    public class DefaultTemplatesCache : ICacheTemplates
    {
        private readonly Cache _cache = HttpRuntime.Cache;

        public Template this[string name]
        {
            get { return (Template) _cache[name]; }
        }

        public void Insert(string name, Template template, string templateFile)
        {
            _cache.Insert(name, template, new CacheDependency(templateFile));
        }

        public bool Contains(string key)
        {
            return _cache[key] != null;
        }
    }
}