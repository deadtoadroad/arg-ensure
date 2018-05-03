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

            return arg.IsNot(v => v == string.Empty, "Argument is empty.");
        }

        public static Andable<Arg<string>> IsNotWhitespace(this Arg<string> arg)
        {
            // Null must be okay if it wasn't ensured not to be.
            if (arg.Value == null)
                return arg.Andable;

            // This predicate returns true for empty strings as well.
            return arg.IsNot(v => v.ToCharArray().All(char.IsWhiteSpace), "Argument is whitespace.");
        }
    }
}
