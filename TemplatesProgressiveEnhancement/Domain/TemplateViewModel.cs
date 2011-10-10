using System.Linq.Expressions;

namespace TemplatesProgressiveEnhancement.Domain
{
    internal class TemplateViewModel
    {
        private readonly object _innerObject;

        internal TemplateViewModel(object innerObject)
        {
            _innerObject = innerObject;
        }

        internal string GetProperty(string propertName)
        {
            var exp = Expression.Constant(_innerObject);
            var property = Expression.Property(exp, propertName);
            var getProp = Expression.Lambda(Expression.GetFuncType(property.Type), property).Compile();
            return getProp.DynamicInvoke().ToString();
        }
    }
}