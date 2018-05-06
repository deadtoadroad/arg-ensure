using System.Linq;

namespace DeadToadRoad.ArgEnsure.Tests.Readme.CommonUsage.Example3
{
    public class Example
    {
        public void Go(string myArg)
        {
            // Ensure myArg contains a number.
            Ensure.Arg(nameof(myArg), myArg).Is(a => a.Any(char.IsDigit));
        }
    }
}
