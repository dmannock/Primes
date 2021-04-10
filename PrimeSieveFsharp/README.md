# Primes | F# Implementation

Port of the original C++ prime number sieve to F# (thus, non-idomatic F# - for science!). 

Similar to the C# version in that it's what the compiler gives you by default. No optimisations or performance tweaks...yet.

## Requirements
- [dotnet core >= 3.1](https://dotnet.microsoft.com/download/dotnet-core)

## Run
- run ```dotnet run -c Release```

## Performance examples

### C++
```
Passes: 10480, Time: 5.000000, Avg: 0.000477, Limit: 1000000, Count1: 78498, Count2: 78498, Valid: 1
```

### F# [Recursion](PrimeSieveFsharp_Recursion)
```
Passes: 11878, Time: 5.000140, Avg: 0.000421, Limit: 1000000, Count: 78498, Valid: true
```

### F# [Port from C++](PrimeSieveFsharp_Port)
```
Passes: 7804, Time: 5.000276, Avg: 0.000641, Limit: 1000000, Count: 78498, Valid: true
```

### C#
```
Passes: 5049, Time: 5.0010085, Avg: 0.0009904948504654387, Limit: 1000000, Count: 78498, Valid: True
```
_Note: Ran the updated C# version that also matches the latest C++ version where the bitArray length = sieveSize. 

Perf improved but this still seems odd, especially compared with F#. However, further runs show the same. Atm I assume the difference is due to compiler defaults & coding styles._

### Go
```
Passes: 7508, Time: 5000622400, Avg: 0.000000, Limit: 1000000, Count1: 78498, Count2: 78498, Valid: true
```

### Python
```
Passes: 29, Time: 5.1648879, Avg: 0.1780995827586207, Limit: 1000000, Count: 78498, Valid: True
```