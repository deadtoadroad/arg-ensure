using System;
using DeadToadRoad.ArgEnsure.Extensions;
using Xbehave;
using Xunit;

namespace DeadToadRoad.ArgEnsure.Tests.Extensions
{
    public class PredicateExtensionsTests
    {
        [Scenario]
        public void IsNotWithAFailingPredicateThrowsAnArgumentException(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsNot is called with a failing predicate"
                .x(() => exception = Record.Exception(() => arg.IsNot(a => a.Contains("alu"))));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentException>(exception);
                        Assert.StartsWith("Argument passed the following predicate: a => a.Contains(\"alu\").", exception.Message);
                    });
        }

        [Scenario]
        public void IsNotWithAPassingPredicateThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsNot is called with a passing predicate"
                .x(() => exception = Record.Exception(() => arg.IsNot(a => a.Contains("ale"))));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }

        [Scenario]
        public void IsNotInRangeWithAFailingPredicateThrowsAnArgumentOutOfRangeException(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsNotInRange is called with a failing predicate"
                .x(() => exception = Record.Exception(() => arg.IsNotInRange(a => a.Contains("alu"))));

            "Then an ArgumentException is thrown"
                .x(
                    () =>
                    {
                        Assert.NotNull(exception);
                        Assert.IsType<ArgumentOutOfRangeException>(exception);
                        Assert.StartsWith("Argument passed the following predicate: a => a.Contains(\"alu\").", exception.Message);
                    });
        }

        [Scenario]
        public void IsNotInRangeWithAPassingPredicateThrowsNothing(Arg<string> arg, Exception exception)
        {
            "Given an arg"
                .x(() => arg = Ensure.Arg("name", "value"));

            "When IsNotInRange is called with a passing predicate"
                .x(() => exception = Record.Exception(() => arg.IsNotInRange(a => a.Contains("ale"))));

            "Then nothing is thrown"
                .x(() => Assert.Null(exception));
        }
    }
}
