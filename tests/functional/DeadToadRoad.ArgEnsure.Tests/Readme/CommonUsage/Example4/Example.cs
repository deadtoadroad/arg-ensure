using DeadToadRoad.ArgEnsure.Extensions;

namespace DeadToadRoad.ArgEnsure.Tests.Readme.CommonUsage.Example4
{
    public class Example
    {
        public void Go(string myArg)
        {
            Ensure.Arg(nameof(myArg), myArg).IsNotNull().And.IsNotWhitespace();
        }
    }
}
