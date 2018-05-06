using DeadToadRoad.ArgEnsure.Extensions;

namespace DeadToadRoad.ArgEnsure.Tests.Readme.CommonUsage.Example2
{
    public class Example
    {
        public void Go(string myArg, string myOtherArg)
        {
            Ensure.Arg(nameof(myArg), myArg).IsNotEmpty();
            Ensure.Arg(nameof(myOtherArg), myOtherArg).IsNotWhitespace();
        }
    }
}
