using System;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain
{
    internal static class TemplatesCache
    {
        internal static string TemplatesPath { get; private set; }

        public static IResolvePropertyName Resolver { get; set; }

        public static void SetTemplatePath(string templatePath)
        {
            TemplatesPath = templatePath.EndsWith("/") ? templatePath : templatePath + "/";
        }
    }
}