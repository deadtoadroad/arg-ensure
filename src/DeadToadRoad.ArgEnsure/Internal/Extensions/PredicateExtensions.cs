using System;
using System.Linq.Expressions;

namespace DeadToadRoad.ArgEnsure.Internal.Extensions
{
    public static class PredicateExtensions
    {
        public static Andable<Arg<T>> IsNot<T>(this Arg<T> arg, Expression<Predicate<T>> predicate, string message = null)
        {
            message = message ?? $"Argument passed the following predicate: {predicate}.";

            return arg.Is(v => !predicate.Compile()(v), message);
        }

        public static Andable<Arg<T>> IsNotInRange<T>(this Arg<T> arg, Expression<Predicate<T>> predicate, string message = null)
        {
            message = message ?? $"Argument passed the following predicate: {predicate}.";

            return arg.IsInRange(v => !predicate.Compile()(v), message);
        }
    }
}
