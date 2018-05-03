using System;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests
{
    public class ArgTests
    {
        [Scenario]
        public void IsNotNullWithANullValueThrowsAnArgumentNullException(Arg<string> arg, Exception exception)
        {
            "Given an arg with a null value"
                .x(() => arg = Ensure.Arg<string>("name", null));

            "When IsNotNull is called"
                .x(() => exception = Record.Exception(() => arg.IsNotNull()));

            "Then an ArgumentNullException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentNullException>(exception);
                    });
        }

        [Scenario]
        public void IsNotNullWithANonNullValueThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg with a non-null value"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsNotNull is called"
                .x(() => exception = Record.Exception(() => arg.IsNotNull()));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }

        [Scenario]
        public void IsWithANullPredicateThrowsAnArgumentNullException(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When Is is called with null predicate"
                .x(() => exception = Record.Exception(() => arg.Is(null)));

            "Then an ArgumentNullException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentNullException>(exception);
                    });
        }

        [Scenario]
        public void IsWithAFailingPredicateThrowsAnArgumentException(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When Is is called with a failing predicate"
                .x(() => exception = Record.Exception(() => arg.Is(a => a.Contains("ale"))));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                        Assert.StartsWith("Argument failed the following predicate: a => a.Contains(\"ale\").", exception.Message);
                    });
        }

        [Scenario]
        public void IsWithAPassingPredicateThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When Is is called with a passing predicate"
                .x(() => exception = Record.Exception(() => arg.Is(a => a.Contains("alu"))));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }

        [Scenario]
        public void IsInRangeWithANullPredicateThrowsAnArgumentNullException(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsInRange is called with null predicate"
                .x(() => exception = Record.Exception(() => arg.IsInRange(null)));

            "Then an ArgumentNullException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentNullException>(exception);
                    });
        }

        [Scenario]
        public void IsInRangeWithAFailingPredicateThrowsAnArgumentOutOfRangeException(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsInRange is called with a failing predicate"
                .x(() => exception = Record.Exception(() => arg.IsInRange(a => a.Contains("ale"))));

            "Then an ArgumentOutOfRangeException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentOutOfRangeException>(exception);
                        Assert.StartsWith("Argument failed the following predicate: a => a.Contains(\"ale\").", exception.Message);
                    });
        }

        [Scenario]
        public void IsInRangeWithAPassingPredicateThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsInRange is called with a passing predicate"
                .x(() => exception = Record.Exception(() => arg.IsInRange(a => a.Contains("alu"))));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
