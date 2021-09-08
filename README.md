# String caser

Дана строка символов, длиной N. Необходимо вывести все возможные варианты исходной строки, где символы могут быть в upper case или в lower case, символы позицию не меняют. Пример, дано "ab" -> result: "ab", "Ab", "aB", "AB"
Строка будет только из букв в нижнем регистре

# Benchmark result

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
Intel Core i7-10510U CPU 1.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.303
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


|        Type | Method |      input |      Mean |     Error |    StdDev |    Gen 0 |  Gen 1 | Allocated |
|------------ |------- |----------- |----------:|----------:|----------:|---------:|-------:|----------:|
|     Antonov |     Do | qwertyuiop | 530.39 us | 10.451 us | 10.732 us | 147.4609 |      - |    604 KB |
|    Antonov2 |     Do | qwertyuiop | 506.73 us |  9.729 us | 14.857 us | 142.5781 | 0.9766 |    584 KB |
| Bezruchenko |     Do | qwertyuiop | 328.20 us |  6.488 us |  9.095 us | 142.5781 | 0.4883 |    584 KB |
|     Chechin |     Do | qwertyuiop |  48.64 us |  0.972 us |  0.909 us |  13.6719 | 0.0610 |     56 KB |
|     Kurtsev |     Do | qwertyuiop | 368.65 us |  6.649 us |  6.220 us |  83.9844 | 0.4883 |    344 KB |
|       Panov |     Do | qwertyuiop | 183.80 us |  3.651 us |  3.237 us |  65.6738 | 0.2441 |    269 KB |
|  Raznopolov |     Do | qwertyuiop |  37.41 us |  0.716 us |  0.853 us |  15.6860 | 0.0610 |     64 KB |
| Raznopolov2 |     Do | qwertyuiop |  34.31 us |  0.610 us |  0.541 us |  13.6719 | 0.0610 |     56 KB |

// * Hints *
Outliers
  Antonov2.Do: Default    -> 4 outliers were removed (563.70 us..785.70 us)
  Bezruchenko.Do: Default -> 6 outliers were removed (364.46 us..393.57 us)
  Chechin.Do: Default     -> 4 outliers were removed (54.46 us..81.17 us)
  Panov.Do: Default       -> 1 outlier  was  removed (204.39 us)
  Raznopolov.Do: Default  -> 3 outliers were removed (40.46 us..78.52 us)
  Raznopolov2.Do: Default -> 1 outlier  was  removed, 2 outliers were detected (33.11 us, 36.64 us)

// * Legends *
  input     : Value of the 'input' parameter
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen 0     : GC Generation 0 collects per 1000 operations
  Gen 1     : GC Generation 1 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)
```