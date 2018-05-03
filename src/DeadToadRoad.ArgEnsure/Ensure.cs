using DeadToadRoad.ArgEnsure.Internal.Extensions;

namespace DeadToadRoad.ArgEnsure
{
    public static class Ensure
    {
        public static Arg<T> Arg<T>(string name, T value)
        {
            Internal.Ensure.Arg(nameof(name), name).IsNotNull().And.IsNotWhitespace();

            return new Arg<T>(name, value);
        }
    }
}
