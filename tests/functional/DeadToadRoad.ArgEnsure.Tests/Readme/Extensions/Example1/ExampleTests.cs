using System;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests.Readme.Extensions.Example1
{
    public class ExampleTests
    {
        [Scenario]
        public void GoWithAZeroMyArgThrowsAnArgumentException(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a zero myArg"
                .x(() => exception = Record.Exception(() => example.Go(0)));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                    });
        }

        [Scenario]
        public void GoWithAOneMyArgThrowsNothing(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a one myArg"
                .x(() => exception = Record.Exception(() => example.Go(1)));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
