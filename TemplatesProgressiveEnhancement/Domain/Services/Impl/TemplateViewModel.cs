using System.Linq.Expressions;
using TemplatesProgressiveEnhancement.Domain.Services.Interfaces;

namespace TemplatesProgressiveEnhancement.Domain.Services.Impl
{
    internal class TemplateViewModel : ITemplateModel
    {
        private readonly object _innerObject;

        internal TemplateViewModel(object innerObject)
        {
            _innerObject = innerObject;
        }

        public string GetProperty(string propertName)
        {
            var exp = Expression.Constant(_innerObject);
            var property = Expression.Property(exp, propertName);
            var getProp = Expression.Lambda(Expression.GetFuncType(property.Type), property).Compile();
            return getProp.DynamicInvoke().ToString();
        }
    }
}