using System;
using System.Linq.Expressions;

namespace DeadToadRoad.ArgEnsure
{
    public interface IArg<T, TSelf>
        where TSelf : IArg<T, TSelf>
    {
        string Name { get; }
        T Value { get; }
        Andable<TSelf> Andable { get; }

        Andable<TSelf> IsNotNull();
        Andable<TSelf> Is(Expression<Predicate<T>> predicate, string message = null);
        Andable<TSelf> IsInRange(Expression<Predicate<T>> predicate, string message = null);
    }
}
