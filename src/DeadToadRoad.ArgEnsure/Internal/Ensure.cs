namespace DeadToadRoad.ArgEnsure.Internal
{
    public static class Ensure
    {
        public static Arg<T> Arg<T>(string name, T value)
        {
            return new Arg<T>(name, value);
        }
    }
}
