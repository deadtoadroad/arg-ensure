using System;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests.Readme.CommonUsage.Example3
{
    public class ExampleTests
    {
        [Scenario]
        public void GoWithoutANumberMyArgThrowsAnArgumentException(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called without a number myArg"
                .x(() => exception = Record.Exception(() => example.Go("value")));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                    });
        }

        [Scenario]
        public void GoWithANumberMyArgThrowsNothing(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a number myArg"
                .x(() => exception = Record.Exception(() => example.Go("valu3")));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
