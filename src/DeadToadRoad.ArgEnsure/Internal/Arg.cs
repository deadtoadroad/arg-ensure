using System;
using System.Linq.Expressions;

namespace DeadToadRoad.ArgEnsure.Internal
{
    public class Arg<T> : ArgBase<T, Arg<T>>
    {
        internal Arg(string name, T value)
            : base(name, value)
        {
        }

        public override Andable<Arg<T>> IsNotNull()
        {
            if (Value == null)
                throw new ArgumentNullException(Name);

            return Andable;
        }

        public override Andable<Arg<T>> Is(Expression<Predicate<T>> predicate, string message = null)
        {
            message = message ?? $"Argument failed the following predicate: {predicate}.";

            if (!predicate.Compile()(Value))
                throw new ArgumentException(message, Name);

            return Andable;
        }

        public override Andable<Arg<T>> IsInRange(Expression<Predicate<T>> predicate, string message = null)
        {
            message = message ?? $"Argument failed the following predicate: {predicate}.";

            if (!predicate.Compile()(Value))
                throw new ArgumentOutOfRangeException(Name, message);

            return Andable;
        }
    }
}
