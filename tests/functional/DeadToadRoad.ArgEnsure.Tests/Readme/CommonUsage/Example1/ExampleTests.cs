using System;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests.Readme.CommonUsage.Example1
{
    public class ExampleTests
    {
        [Scenario]
        public void GoWithANullMyArgThrowsAnArgumentNullException(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a null myArg"
                .x(() => exception = Record.Exception(() => example.Go(null)));

            "Then an ArgumentNullException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentNullException>(exception);
                    });
        }

        [Scenario]
        public void GoWithANonNullMyArgThrowsNothing(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a non-null myArg"
                .x(() => exception = Record.Exception(() => example.Go("value")));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
