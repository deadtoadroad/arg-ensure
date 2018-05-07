# ArgEnsure

Easy to write, easy to read guard clauses for your .NET methods.

## Common Usage

Guard against nulls.

```csharp
Ensure.Arg(nameof(myArg), myArg).IsNotNull();
```

Guard against empty strings or whitespace.

```csharp
Ensure.Arg(nameof(myArg), myArg).IsNotEmpty();
Ensure.Arg(nameof(myOtherArg), myOtherArg).IsNotWhitespace();
```

Guard against anything.

```csharp
// Ensure myArg contains a number.
Ensure.Arg(nameof(myArg), myArg).Is(a => a.Any(char.IsDigit));
```

Chain any of them together.

```csharp
Ensure.Arg(nameof(myArg), myArg).IsNotNull().And.IsNotWhitespace();
```

## Extensions

Creating your own guard clauses is easy to do.

```csharp
public static class ArgExtensions
{
    public static Andable<Arg<int>> IsGreaterThanZero(this Arg<int> arg)
    {
        Ensure.Arg(nameof(arg), arg).IsNotNull();

        return Ensure.Arg(arg.Name, arg.Value).Is(a => a > 0);
    }
}
```

Using them is too.

```csharp
Ensure.Arg(nameof(myArg), myArg).IsGreaterThanZero();
```

## Exceptions

ArgEnsure contains methods to throw any of the three built-in argument exceptions in .NET. The ability to throw custom exceptions is coming soon.

Exception | Methods | Extension Methods
--------- | ------- | -----------------
`System.ArgumentNullException` | `IsNotNull()` |
`System.ArgumentException` | `Is()` | `IsNot()`<br>`IsNotEmpty()`<br>`IsNotWhitespace()`
`System.ArgumentOutOfRangeException` | `IsInRange()` | `IsNotInRange()`

## Building

Building the source from scratch can be done a number of ways.

### Docker

The easiest method is by using Docker. If you have Bash, Git and Docker installed you can use the included scripts to kick off a build immediately. No other tools are required.

```
cd build
./build.sh restore
./build.sh test
./build.sh clean
```

In order to eliminate file ownership problems the Docker images are ammended with your uid and gid, and will run as you instead of root.

The scripts also assume you have a home directory containing `.nuget/packages`. It's okay if you don't, but you will after the scripts complete. This directory is not cleaned up by `./build/build.sh clean`.

### Build Tools

If you don't want to use Docker and you have sufficent build tools installed, you can make use of the scripts in `build/dotnet` and `build/mono`, or you can run your own builds via the command line or IDE. The required frameworks are currently .NET 4.5, .NET Core 1.0 and .NET Core 2.0.
