using System;
using DeadToadRoad.ArgEnsure.Extensions;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Scenario]
        public void IsNotEmptyWithANullValueThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg with a null value"
                .x(() => arg = Ensure.Arg<string>("name", null));

            "When IsNotEmpty is called"
                .x(() => exception = Record.Exception(() => arg.IsNotEmpty()));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }

        [Scenario]
        public void IsNotEmptyWithAnEmptyValueThrowsAnArgumentException(Arg<string> arg, Exception exception)
        {
            "Given an arg with an empty value"
                .x(() => arg = Ensure.Arg("name", string.Empty));

            "When IsNotEmpty is called"
                .x(() => exception = Record.Exception(() => arg.IsNotEmpty()));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                        Assert.StartsWith("Argument is empty.", exception.Message);
                    });
        }

        [Scenario]
        public void IsNotEmptyWithANonEmptyValueThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg with a non-empty value"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsNotEmpty is called"
                .x(() => exception = Record.Exception(() => arg.IsNotEmpty()));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }

        [Scenario]
        public void IsNotWhitespaceWithANullValueThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg with a null value"
                .x(() => arg = Ensure.Arg<string>("name", null));

            "When IsNotWhitespace is called"
                .x(() => exception = Record.Exception(() => arg.IsNotWhitespace()));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }

        [Scenario]
        public void IsNotWhitespaceWithAnEmptyValueThrowsAnArgumentException(Arg<string> arg, Exception exception)
        {
            "Given an arg with an empty value"
                .x(() => arg = Ensure.Arg("name", string.Empty));

            "When IsNotWhitespace is called"
                .x(() => exception = Record.Exception(() => arg.IsNotWhitespace()));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                        Assert.StartsWith("Argument is whitespace.", exception.Message);
                    });
        }

        [Scenario]
        public void IsNotWhitespaceWithAWhitespaceValueThrowsAnArgumentException(Arg<string> arg, Exception exception)
        {
            "Given an arg with an empty value"
                .x(() => arg = Ensure.Arg("name", " "));

            "When IsNotWhitespace is called"
                .x(() => exception = Record.Exception(() => arg.IsNotWhitespace()));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                        Assert.StartsWith("Argument is whitespace.", exception.Message);
                    });
        }

        [Scenario]
        public void IsNotWhitespaceWithANonWhitespaceValueThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg with a non-empty value"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsNotWhitespace is called"
                .x(() => exception = Record.Exception(() => arg.IsNotWhitespace()));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
