using System;
using System.IO;
using TemplatesProgressiveEnhancement.Domain.Services.Templating;

namespace TemplatesProgressiveEnhancement.Domain.Services.Caching
{
    public class AppCache : IAppCache
    {
        private readonly ITemplatesFactory _factory;
        static ICacheTemplates _cache;

        public AppCache(ICacheTemplates cache, ITemplatesFactory factory)
        {
            _factory = factory;
            _cache = cache;
        }

        public AppCache()
        {
            _factory = new TemplatesFactory();
            _cache = new DefaultTemplatesCache();
        }

        public static string TemplatesPath { get; private set; }
        
        public void SetTemplatePath(string templatePath)
        {
            TemplatesPath = templatePath.EndsWith("/") ? templatePath : templatePath + "/";
        }

        public Template GetTemplate(string name)
        {
            if (_cache.Contains(name)) return _cache[name];
            var file = TemplatesPath + name + ".ascx";
            return AddToCache(file);
        }

        private Template AddToCache(string file)
        {
            try
            {
                var template = _factory.CreateTemplate(file);
                template.PrepareDynamicRendering();
                _cache.Insert(template.Name, template, file);
                return template;
            }
            catch(FileNotFoundException e)
            {
                throw new TemplateNotFoundException(e, file);
            }
            catch (IOException e)
            {
                throw new TemplateFileException(e, file);
            }
        }

        public void CacheAllTemplates(string templatesPath)
        {
            foreach (var file in Directory.GetFiles(templatesPath))
                AddToCache(file);
        }
    }

    public class TemplateFileException : Exception
    {
        public TemplateFileException(IOException innerException, string file)
            : base("problems loading template {0}".ToFormat(file), innerException){}
    }

    public class TemplateNotFoundException : Exception
    {
        public TemplateNotFoundException(FileNotFoundException innerException, string file)
            : base("template {0} was not found".ToFormat(file), innerException){}
    }
}