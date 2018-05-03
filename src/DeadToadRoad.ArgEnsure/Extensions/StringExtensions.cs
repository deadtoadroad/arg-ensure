using DeadToadRoad.ArgEnsure.Internal.Extensions;

namespace DeadToadRoad.ArgEnsure.Extensions
{
    public static class StringExtensions
    {
        public static Andable<Arg<string>> IsNotEmpty(this Arg<string> arg)
        {
            Internal.Ensure.Arg(nameof(arg), arg).IsNotNull();
            Internal.Ensure.Arg(arg.Name, arg.Value).IsNotEmpty();

            return arg.Andable;
        }

        public static Andable<Arg<string>> IsNotWhitespace(this Arg<string> arg)
        {
            Internal.Ensure.Arg(nameof(arg), arg).IsNotNull();
            Internal.Ensure.Arg(arg.Name, arg.Value).IsNotWhitespace();

            return arg.Andable;
        }
    }
}
