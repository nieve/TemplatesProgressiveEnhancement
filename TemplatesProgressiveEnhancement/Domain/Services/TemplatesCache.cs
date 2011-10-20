namespace TemplatesProgressiveEnhancement.Domain.Services
{
    internal static class TemplatesCache
    {
        internal static string TemplatesPath { get; private set; }
        
        public static void SetTemplatePath(string templatePath)
        {
            TemplatesPath = templatePath.EndsWith("/") ? templatePath : templatePath + "/";
        }
    }
}