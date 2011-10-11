using System.IO;

namespace TemplatesProgressiveEnhancement.Domain
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