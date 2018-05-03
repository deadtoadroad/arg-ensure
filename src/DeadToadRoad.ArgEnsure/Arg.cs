using System;
using System.Linq.Expressions;

namespace DeadToadRoad.ArgEnsure
{
    public class Arg<T> : ArgBase<T, Arg<T>>
    {
        internal Arg(string name, T value)
            : base(name, value)
        {
        }

        public override Andable<Arg<T>> IsNotNull()
        {
            Internal.Ensure.Arg(Name, Value).IsNotNull();

            return Andable;
        }

        public override Andable<Arg<T>> Is(Expression<Predicate<T>> predicate, string message = null)
        {
            Internal.Ensure.Arg(nameof(predicate), predicate).IsNotNull();
            Internal.Ensure.Arg(Name, Value).Is(predicate, message);

            return Andable;
        }

        public override Andable<Arg<T>> IsInRange(Expression<Predicate<T>> predicate, string message = null)
        {
            Internal.Ensure.Arg(nameof(predicate), predicate).IsNotNull();
            Internal.Ensure.Arg(Name, Value).IsInRange(predicate, message);

            return Andable;
        }
    }
}
