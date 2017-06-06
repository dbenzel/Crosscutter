# Crosscutter - [Available on nuget](https://www.nuget.org/packages/Crosscutter/)
.NET extensions, safety &amp; convenience methods for known types.

# Installation
Using Package Manager Console:
```
PM> Install-Package Crosscutter
```

# Usage
Most all of Crosscutter's functionality is found in the Crosscutter.Extensions namespace.
```c#
using Crosscutter.Extensions;

"".IsPopulated();               //  false
"".IsNullOrWhitespace();        //  true
"".IsNullOrEmpty();             //  true

"abc".IsIn("ABC", "DEF");       //  true (case-insensitive)

"abc".Matches("abc", "def");    //  true (case-sensitive)
"ABC".Matches("abc", "def");    //  false (case-sensitive)

"12345-6789".MatchesRegex(@"^\d{5}\-\d{4}$");   //  true

"12345-6789".GetSafeSubstring(0, 5);			//	"12345"
"12345".GetSafeSubstring(0, 5);					//	"1234"
```