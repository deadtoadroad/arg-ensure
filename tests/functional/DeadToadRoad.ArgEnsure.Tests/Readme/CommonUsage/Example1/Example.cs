namespace DeadToadRoad.ArgEnsure.Tests.Readme.CommonUsage.Example1
{
    public class Example
    {
        public void Go(string myArg)
        {
            Ensure.Arg(nameof(myArg), myArg).IsNotNull();
        }
    }
}
