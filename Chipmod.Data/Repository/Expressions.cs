using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Chipmod.Data.Repository
{
    public static class Expressions
    {
        public static Expression<Func<TObject, bool>> EqualsTo<TObject, TMember>
            (this Expression<Func<TObject, TMember>> memberAccessor, TMember value)
            where TMember : IEquatable<TMember>
        {
            var parameter = Expression.Parameter(typeof(TObject), "Object");
            return Expression.Lambda<Func<TObject, bool>>(
                Expression.Equal(
                    Expression.Invoke(memberAccessor, parameter),
                    Expression.Constant(value, typeof(TMember))
                ),
                parameter
            );
        }

        public static Expression<Func<TObject, bool>> ContainedIn<TObject, TMember>
            (this Expression<Func<TObject, TMember>> memberAccessor, TMember[] array)
        {
            var parameter = Expression.Parameter(typeof(TObject), "Object");

            var containsMethod = typeof(Enumerable)
                .GetRuntimeMethods()
                .Single(m => m.Name == nameof(Enumerable.Contains) && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(TMember));

            return Expression.Lambda<Func<TObject, bool>>(
                Expression.Call(containsMethod,
                    Expression.Constant(array, typeof(TMember[])),
                    Expression.Invoke(memberAccessor, parameter)
                ),
                parameter
            );
        }

    }
}
