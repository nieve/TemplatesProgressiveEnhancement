using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain.Services.Impl
{
    internal class DefaultTemplateKey : ITemplateKey
    {
        public string LeftSide
        {
            get { return "${"; }
        }

        public string RightSide
        {
            get { return "}"; }
        }
    }
}