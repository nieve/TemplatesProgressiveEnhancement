using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using NUnit.Framework;
using Rhino.Mocks;
using TemplatesProgressiveEnhancement.Domain;
using TemplatesProgressiveEnhancement.Domain.Services;
using TemplatesProgressiveEnhancement.Domain.Services.Caching;
using TemplatesProgressiveEnhancement.Domain.Services.Templating;

namespace TemplatesProgressiveEnhancement.Tests.Integration
{
    [TestFixture]
    public class TemplateRenderingConfigurationTests
    {
        private FakeController _controller;
        private IContainAppPath _appPathContainer;

        [SetUp]
        public void SetUp()
        {
            _appPathContainer = MockRepository.GenerateStub<IContainAppPath>();
            _appPathContainer.Stub(c => c.GetAppPath()).Return(Directory.GetCurrentDirectory() + "\\");

            var appCache = new AppCache(new FakeTemplateCache(), new TemplatesFactory());
            _controller = new FakeController(appCache);
            var configExpression = new TemplateRenderingConfigurationExpression(_appPathContainer, appCache);
            configExpression.WithDefaults();
        }

        [Test]
        public void Rendering_replaces_values_with_the_templated_keys()
        {
            var model = new FakeViewModel{Key="calculon", Value = 43};
            var renderedText = _controller.Template("Display", model);
            
            renderedText.Content.ShouldContain("calculon");
            renderedText.Content.ShouldContain("43");
        }

        [Test]
        public void Rendering_removes_wrapping_jquery_tmpl_script_tag()
        {
            var model = new FakeViewModel1 { Key = "A l'aise blaise", Value = "Cool Raul" };
            var renderedText = _controller.Template("Template1", model).Content;
            
            renderedText.ShouldBe("<div>\r\n  <span value=\"A l'aise blaise\"></span>Cool Raul</div>");
        }

        [Test]
        public void Rendering_an_array_of_models()
        {
            var model1 = new FakeViewModel1 {Key = "A", Value = "1"};
            var model2 = new FakeViewModel1 {Key = "B", Value = "2"};
            var model3 = new FakeViewModel1 {Key = "D", Value = "42"};
            var models = new[] {model1, model2, model3};
            var renderedText = _controller.Template("Template2", models).Content;

            renderedText.ShouldBe("<div>A, 1</div><div>B, 2</div><div>D, 42</div>");
        }

        [Test]
        public void Rendering_a_list_of_models()
        {
            var model1 = new FakeViewModel1 {Key = "A", Value = "1"};
            var model2 = new FakeViewModel1 {Key = "B", Value = "2"};
            var model3 = new FakeViewModel1 {Key = "D", Value = "42"};
            var models = new List<FakeViewModel1> {model1, model2, model3};
            var renderedText = _controller.TemplateList("Template2", models).Content;

            renderedText.ShouldBe("<div>A, 1</div><div>B, 2</div><div>D, 42</div>");
        }
    }

    public class FakeTemplateCache : ICacheTemplates
    {
        readonly Dictionary<string, Template> _cache = new Dictionary<string, Template>();
        public Template this[string name]
        {
            get { return _cache[name]; }
        }
        public void Insert(string name, Template template, string templateFile)
        {
            _cache.Add(name, template);
        }

        public bool Contains(string key)
        {
            return _cache.ContainsKey(key);
        }
    }

    public class FakeViewModel
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }

    public class FakeViewModel1
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class FakeController : TemplateRenderingController
    {
        public FakeController(IAppCache cache) : base(cache){}
    }

    public class FakeHttpApplication : HttpApplication{}
}
