using NUnit.Framework;

namespace TemplatesProgressiveEnhancement.Tests
{
    public static class Should
    {
        public static void ShouldBe<T>(this T obj, T expected)
        {
            Assert.AreEqual(expected, obj);
        }

        public static void ShouldContain(this string obj, string expected)
        {
            Assert.That(obj.Contains(expected));
        }
    }
}