namespace DeadToadRoad.ArgEnsure.Tests.Readme.Extensions.Example1
{
    public static class ArgExtensions
    {
        public static Andable<Arg<int>> IsGreaterThanZero(this Arg<int> arg)
        {
            Ensure.Arg(nameof(arg), arg).IsNotNull();

            return Ensure.Arg(arg.Name, arg.Value).Is(a => a > 0);
        }
    }
}
