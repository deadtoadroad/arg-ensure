using System;
using System.Linq.Expressions;
using DeadToadRoad.ArgEnsure.Internal.Extensions;

namespace DeadToadRoad.ArgEnsure.Extensions
{
    public static class PredicateExtensions
    {
        public static Andable<Arg<T>> IsNot<T>(this Arg<T> arg, Expression<Predicate<T>> predicate, string message = null)
        {
            Internal.Ensure.Arg(nameof(arg), arg).IsNotNull();
            Internal.Ensure.Arg(nameof(predicate), predicate).IsNotNull();
            Internal.Ensure.Arg(arg.Name, arg.Value).IsNot(predicate, message);

            return arg.Andable;
        }

        public static Andable<Arg<T>> IsNotInRange<T>(this Arg<T> arg, Expression<Predicate<T>> predicate, string message = null)
        {
            Internal.Ensure.Arg(nameof(arg), arg).IsNotNull();
            Internal.Ensure.Arg(nameof(predicate), predicate).IsNotNull();
            Internal.Ensure.Arg(arg.Name, arg.Value).IsNotInRange(predicate, message);

            return arg.Andable;
        }
    }
}
