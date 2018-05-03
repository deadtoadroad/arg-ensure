using System;
using System.Linq.Expressions;

namespace DeadToadRoad.ArgEnsure
{
    public abstract class ArgBase<T, TSelf> : IArg<T, TSelf>
        where TSelf : ArgBase<T, TSelf>
    {
        protected ArgBase(string name, T value)
        {
            Name = name;
            Value = value;
            Andable = new Andable<TSelf>((TSelf)this);
        }

        public string Name { get; }
        public T Value { get; }
        public Andable<TSelf> Andable { get; }

        public abstract Andable<TSelf> IsNotNull();
        public abstract Andable<TSelf> Is(Expression<Predicate<T>> predicate, string message = null);
        public abstract Andable<TSelf> IsInRange(Expression<Predicate<T>> predicate, string message = null);
    }
}
