namespace TemplatesProgressiveEnhancement.Domain
{
    internal static class StringExtensions
    {
        internal static string Capitalise(this string str)
        {
            return str.Insert(0, str.Substring(0, 1).ToUpper()).Remove(1, 1);
        }

        internal static string ToFormat(this string str, params object[] args)
        {
            return string.Format(str, args);
        }
    }
}