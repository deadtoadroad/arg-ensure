namespace DeadToadRoad.ArgEnsure.Tests.Readme.Extensions.Example1
{
    public class Example
    {
        public void Go(int myArg)
        {
            Ensure.Arg(nameof(myArg), myArg).IsGreaterThanZero();
        }
    }
}
