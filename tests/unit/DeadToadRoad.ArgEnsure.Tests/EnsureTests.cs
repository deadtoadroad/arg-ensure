using System;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests
{
    public class EnsureTests
    {
        [Scenario]
        public void ArgWithANullNameThrowsAnArgumentNullException(Exception exception)
        {
            "Given Ensure"
                .x(() => { });

            "When Arg is called with a null name"
                .x(() => exception = Record.Exception(() => Ensure.Arg(null, "value")));

            "Then an ArgumentNullException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentNullException>(exception);
                    });
        }

        [Scenario]
        public void ArgWithAnEmptyNameThrowsAnArgumentException(Exception exception)
        {
            "Given Ensure"
                .x(() => { });

            "When Arg is called with an empty name"
                .x(() => exception = Record.Exception(() => Ensure.Arg(string.Empty, "value")));

            "Then an AgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                    });
        }

        [Scenario]
        public void ArgWithAWhitespaceNameThrowsAnArgumentException(Exception exception)
        {
            "Given Ensure"
                .x(() => { });

            "When Arg is called with a whitespace name"
                .x(() => exception = Record.Exception(() => Ensure.Arg(" ", "value")));

            "Then an AgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                    });
        }

        [Scenario]
        public void ArgWithANonWhitespaceNameThrowsNothing(Exception exception)
        {
            "Given Ensure"
                .x(() => { });

            "When Arg is called with a non-whitespace name"
                .x(() => exception = Record.Exception(() => Ensure.Arg("name", "value")));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
