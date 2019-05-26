# Crosscutter - [Available on nuget](https://www.nuget.org/packages/Crosscutter/) ![Build status](https://benzel.visualstudio.com/Crosscutter/_apis/build/status/Crosscutter-CD)
.NET extensions, safety &amp; convenience methods for known types.  This project is esssentially me "scratching my own itch", and writing a library of extension methods that make known .NET types safer and easier to use.  This reduces my rate of friction in all projects, and I've always wished to have a globally-available toolkit for anything and everything.  To this end, all .csproj files in this project are published to [nuget](https://www.nuget.org/packages?q=crosscutter) via continuous deployment, and open-sourced at [github](https://github.com/dbenzel/Crosscutter).  Enjoy!

# Installation
Using Package Manager Console:
```
PM> Install-Package Crosscutter
```

# Usage
All of Crosscutter's functionality is found in the Crosscutter.Extensions namespace.
```c#
using Crosscutter.Extensions;
```

### String Extensions
```c#
"".IsPopulated().ShouldBeFalse();
"".IsNullOrWhitespace().ShouldBeTrue();
"".IsNullOrEmpty().ShouldBeTrue();

"abc".IsIn("ABC", "DEF").ShouldBeTrue(); // case-insensitive
"abc".Matches("abc", "def").ShouldBeTrue(); // case-sensitive
"ABC".Matches("abc", "def").ShouldBeFalse(); // case-sensitive

"12345-6789".GetSafeSubstring(0, 5).ShouldEqual("12345");
"1234".GetSafeSubstring(0, 5).ShouldEqual("1234");

"Just  Read  The  Instructions".CollapseSpaces().ShouldEqual("Just Read The Instructions");
"of course I still love you".ToTitleCase().ShouldEqual("Of Course I Still Love You");
```

### Regex Extensions
```c#
"12345-6789".MatchesRegex(@"^\d{5}\-\d{4}$").ShouldBeTrue();

"Shortfall of Gravitas".MatchesRegex(@"FAIL", @"NOPE", @"gravit\w+$").ShouldBeTrue();

"AA AB AC".GetFirstMatch(@"A\w\b").ShouldEqual("AA");

"AA AB AC".GetAllMatches(@"A\w\b"); // [ "AA", "AB", "AC" ]
```

### Generic Extensions
```c#
var list = "Tesla".AsList();

list.ShouldNotBeNull();
list.Single().ShouldEqual("Tesla");

```