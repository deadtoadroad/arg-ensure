# ArgEnsure

Easy to write, easy to read guard clauses for your .NET methods. Available as a [NuGet package](https://www.nuget.org/packages/DeadToadRoad.ArgEnsure/).

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

```bash
cd build
./build.sh restore
./build.sh test
./build.sh clean # or
./build.sh clean-repo
```

### Build Tools

If you have sufficient build tools installed, the standard `dotnet` CLI commands will also work.

#### Ubuntu 18.04

* [Mono](https://www.mono-project.com/download/stable/#download-lin-ubuntu), `mono-devel`
* [.NET Core SDK 2.0 or above](https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/sdk-current)
