namespace Flags.Desktop.Infrastructure.Extensions
{
    using System;
    using System.Linq.Expressions;

    public class Helpers
    {
        // Requires object instance, but you can skip specifying T
        public static string GetPropertyName<T>(Expression<Func<T>> exp)
        {
            return (((MemberExpression)(exp.Body)).Member).Name;
        }
    }
}
