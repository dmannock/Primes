# Primes | F# Port

Port of the original C++ prime number sieve to F# (thus, non-idomatic F# - for science!). 

Similar to the C# version in that it's what the compiler gives you by default. No optimisations or performance tweaks...yet.

## Requirements
- [dotnet core >= 3.1](https://dotnet.microsoft.com/download/dotnet-core)

## Run
- run ```dotnet run -c Release```

## Performance examples

### F#
```
Passes: 5030, Time: 5.000858, Avg: 0.000994, Limit: 1000000, Count: 78498, Valid: true
```

### C#
```
Passes: 3545, Time: 5.0012068, Avg: 0.0014107776586741892, Limit: 1000000, Count: 78498, Valid: True
```
_This seemed odd, especially compared with F#. However, further runs show the same. Atm I assume the difference is due to compiler defaults & coding styles._

### C++
```
Passes: 9905, Time: 5.000000, Avg: 0.000505, Limit: 1000000, Count1: 78498, Count2: 78498, Valid: 1
```

### Python
```
Passes: 29, Time: 5.1648879, Avg: 0.1780995827586207, Limit: 1000000, Count: 78498, Valid: True
```
