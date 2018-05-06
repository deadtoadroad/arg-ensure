using System;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests.Readme.CommonUsage.Example4
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
        public void GoWithAnEmptyMyArgThrowsAnArgumentException(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with an empty myArg"
                .x(() => exception = Record.Exception(() => example.Go(string.Empty)));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                    });
        }

        [Scenario]
        public void GoWithAWhitespaceMyArgThrowsAnArgumentException(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a whitespace myArg"
                .x(() => exception = Record.Exception(() => example.Go(" ")));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                    });
        }

        [Scenario]
        public void GoWithANonWhitespaceMyArgThrowsNothing(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a non-whitespace myArg"
                .x(() => exception = Record.Exception(() => example.Go("value")));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
