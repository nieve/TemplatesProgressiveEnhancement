using System.Web;
using System.Web.Mvc;
using NUnit.Framework;

namespace TemplatesProgressiveEnhancement.Tests.Integration
{
    [TestFixture]
    public class TemplateRenderingConfigurationTests
    {
        readonly FakeHttpApplication _app = new FakeHttpApplication();

        [SetUp]
        public void SetUp()
        {
            var configExpression = _app.ConfigureTemplateRendering();
            configExpression.WithDefaults();
        }

        [Test]
        public void Rendering_replaces_values_with_the_templated_keys()
        {
            var controller = new FakeController();
            var model = new FakeViewModel{Key="calculon", Value = 43};
            var renderedText = controller.Template("Display", model);
            
            Assert.That(renderedText.Content.Contains("calculon"));
            Assert.That(renderedText.Content.Contains("43"));
        }

        [Test]
        public void Rendering_removes_wrapping_jquery_tmpl_script_tag()
        {
            var controller = new FakeController();
            var model = new FakeViewModel1 { Key = "A l'aise blaise", Value = "Cool Raul" };
            var renderedText = controller.Template("Template1", model).Content;
            
            Assert.AreEqual("<span>A l'aise blaise</span>\r\n<span>Cool Raul</span>", renderedText);
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

    public class FakeController : Controller{}

    public class FakeHttpApplication : HttpApplication{}
}
