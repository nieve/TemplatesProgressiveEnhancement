using System.IO;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain.Services.Impl
{
    internal class TemplateDataContainer : IContainTemplateData
    {
        internal TemplateDataContainer(string templatePath)
        {
            Text = File.ReadAllText(templatePath);
            var fileInfo = new FileInfo(templatePath);
            Name = fileInfo.Name.Replace(fileInfo.Extension, "");
        }

        public string Name { get; set; }
        public string Text { get; set; }
    }
}