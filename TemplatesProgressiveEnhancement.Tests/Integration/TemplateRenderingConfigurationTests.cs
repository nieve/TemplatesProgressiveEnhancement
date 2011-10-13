using System.Web;
using System.Web.Mvc;
using NUnit.Framework;

namespace TemplatesProgressiveEnhancement.Tests.Integration
{
    [TestFixture]
    public class TemplateRenderingConfigurationTests
    {
        readonly FakeHttpApplication _app = new FakeHttpApplication();
        private readonly FakeController _controller = new FakeController();

        [SetUp]
        public void SetUp()
        {
            var configExpression = _app.ConfigureTemplateRendering();
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
        public void Rendering_a_list_of_models()
        {
            var model1 = new FakeViewModel1 {Key = "A", Value = "1"};
            var model2 = new FakeViewModel1 {Key = "B", Value = "2"};
            var model3 = new FakeViewModel1 {Key = "D", Value = "42"};
            var models = new[] {model1, model2, model3};
            var renderedText = _controller.Template("Template2", models).Content;

            renderedText.ShouldBe("<div>A, 1</div><div>B, 2</div><div>D, 42</div>");
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
