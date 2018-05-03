namespace DeadToadRoad.ArgEnsure
{
    public class Andable<T>
    {
        public Andable(T and)
        {
            And = and;
        }

        public T And { get; }
    }
}
