using System;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests.Readme.CommonUsage.Example2
{
    public class ExampleTests
    {
        [Scenario]
        public void GoWithAnEmptyMyArgThrowsAnArgumentException(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with an empty myArg"
                .x(() => exception = Record.Exception(() => example.Go(string.Empty, "value")));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                    });
        }

        [Scenario]
        public void GoWithANonEmptyMyArgThrowsNothing(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a non-empty myArg"
                .x(() => exception = Record.Exception(() => example.Go("value", "value")));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }

        [Scenario]
        public void GoWithAWhitespaceMyOtherArgThrowsAnArgumentException(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a whitespace myOtherArg"
                .x(() => exception = Record.Exception(() => example.Go("value", " ")));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                    });
        }

        [Scenario]
        public void GoWithANonWhitespaceMyOtherArgThrowsNothing(Example example, Exception exception)
        {
            "Given an example"
                .x(() => example = new Example());

            "When Go is called with a non-whitespace myOtherArg"
                .x(() => exception = Record.Exception(() => example.Go("value", "value")));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
