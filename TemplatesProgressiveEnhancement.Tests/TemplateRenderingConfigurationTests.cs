using System.Web;
using System.Web.Mvc;
using NUnit.Framework;
using TemplatesProgressiveEnhancement;

namespace FakeMvcApplication
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
    }

    public class FakeViewModel
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }

    public class FakeController : Controller{}

    public class FakeHttpApplication : HttpApplication{}
}
