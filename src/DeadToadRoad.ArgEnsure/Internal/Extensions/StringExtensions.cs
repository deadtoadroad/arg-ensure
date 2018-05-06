using System.Linq;

namespace DeadToadRoad.ArgEnsure.Internal.Extensions
{
    public static class StringExtensions
    {
        public static Andable<Arg<string>> IsNotEmpty(this Arg<string> arg)
        {
            // Null must be okay if it wasn't ensured not to be.
            if (arg.Value == null)
                return arg.Andable;

            return arg.IsNot(a => a == string.Empty, "Argument is empty.");
        }

        public static Andable<Arg<string>> IsNotWhitespace(this Arg<string> arg)
        {
            // Null must be okay if it wasn't ensured not to be.
            if (arg.Value == null)
                return arg.Andable;

            return arg.IsNot(a => a.ToCharArray().All(char.IsWhiteSpace), "Argument is whitespace.");
        }
    }
}
