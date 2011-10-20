using NUnit.Framework;
using Rhino.Mocks;
using TemplatesProgressiveEnhancement.Domain;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Tests.Unit
{
    [TestFixture]
    public class TemplateTests
    {
        private ITemplatesFactory _factory;
        private readonly string _name = "name";
        private readonly object _viewModel = new object();
        private ITemplateModel _templateModel;

        [SetUp]
        public void SetUp()
        {
            _factory = MockRepository.GenerateStub<ITemplatesFactory>();
            _templateModel = MockRepository.GenerateStub<ITemplateModel>();
            _factory.Stub(f => f.GetTemplateModel(_viewModel)).Return(_templateModel);
        }

        [Test]
        public void Rendering_replaces_template_key_with_model_value()
        {
            var template = new Template(_name, "${SomeKey} SomeKey", _factory);
            _templateModel.Stub(m => m.GetProperty("SomeKey")).Return("some value");

            var renderedText = template.Render(_viewModel);

            Assert.AreEqual("some value SomeKey", renderedText);
        }

        [Test]
        public void Rendering_replaces_several_template_keys_with_model_values()
        {
            var template = new Template(_name, "count: ${FirstKey}, ${SecondKey}, ${ThirdKey}", _factory);
            _templateModel.Stub(m => m.GetProperty("FirstKey")).Return("One");
            _templateModel.Stub(m => m.GetProperty("SecondKey")).Return("Two");
            _templateModel.Stub(m => m.GetProperty("ThirdKey")).Return("Three");

            var renderedText = template.Render(_viewModel);

            Assert.AreEqual("count: One, Two, Three", renderedText);
        }

        [Test]
        public void Rendering_capitalises_template_key()
        {
            var template = new Template(_name, "${minusculeName}", _factory);
            _templateModel.Stub(m => m.GetProperty("MinusculeName")).Return("I got capitalised!");

            var renderedText = template.Render(_viewModel);

            Assert.AreEqual("I got capitalised!", renderedText);
        }

        [Test]
        public void Rendering_replaces_several_occurances_of_the_same_template_key_with_the_same_model_value()
        {
            var template = new Template(_name, "${Repeat}, ${Repeat}, ${Repeat}, ${Repeat} Claudius!", _factory);
            _templateModel.Stub(m => m.GetProperty("Repeat")).Return("I");

            var renderedText = template.Render(_viewModel);

            Assert.AreEqual("I, I, I, I Claudius!", renderedText);
        }

        [Test]
        public void Rendering_untemplated_text_replaces_nothing()
        {
            var text = "${TemplateKey";
            var text2 = "{TemplateKey}";
            var text3 = "$TemplateKey}";
            var text4 = "TemplateKey";

            var template = new Template(_name, text, _factory);
            var template2 = new Template(_name, text2, _factory);
            var template3 = new Template(_name, text3, _factory);
            var template4 = new Template(_name, text4, _factory);
            _templateModel.Stub(m => m.GetProperty("TemplateKey")).Return("Different value")
                .Repeat.Times(4);

            var renderedText = template.Render(_viewModel);
            var renderedText2 = template2.Render(_viewModel);
            var renderedText3 = template3.Render(_viewModel);
            var renderedText4 = template4.Render(_viewModel);

            Assert.AreEqual(text, renderedText);
            Assert.AreEqual(text2, renderedText2);
            Assert.AreEqual(text3, renderedText3);
            Assert.AreEqual(text4, renderedText4);
        }
    }
}