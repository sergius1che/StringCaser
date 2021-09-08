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


|        Type |                Method |      input |      Mean |    Error |    StdDev |    Gen 0 |  Gen 1 | Allocated |
|------------ |---------------------- |----------- |----------:|---------:|----------:|---------:|-------:|----------:|
|     Antonov |     'Antonov variant' | qwertyuiop | 533.00 us | 9.980 us | 10.248 us | 147.4609 |      - |    604 KB |
|    Antonov2 |    'Antonov2 variant' | qwertyuiop | 506.37 us | 6.932 us |  5.412 us | 142.5781 | 0.9766 |    584 KB |
| Bezruchenko | 'Bezruchenko variant' | qwertyuiop | 322.69 us | 4.681 us |  4.379 us | 142.5781 | 0.4883 |    584 KB |
|     Chechin |     'Chechin variant' | qwertyuiop |  47.95 us | 0.819 us |  0.726 us |  13.6719 | 0.0610 |     56 KB |
|     Kurtsev |     'Kurtsev variant' | qwertyuiop | 373.48 us | 7.207 us |  8.851 us |  83.9844 | 0.4883 |    344 KB |
|       Panov |       'Panov variant' | qwertyuiop | 182.25 us | 3.261 us |  2.891 us |  65.6738 | 0.2441 |    269 KB |
|  Raznopolov |  'Raznopolov variant' | qwertyuiop |  34.98 us | 0.425 us |  0.355 us |  15.6860 | 0.0610 |     64 KB |
| Raznopolov2 | 'Raznopolov2 variant' | qwertyuiop |  35.22 us | 0.592 us |  0.495 us |  13.6719 | 0.0610 |     56 KB |

// * Hints *
Outliers
  Antonov.'Antonov variant': Default         -> 1 outlier  was  removed (570.44 us)
  Antonov2.'Antonov2 variant': Default       -> 3 outliers were removed (546.59 us..783.31 us)
  Chechin.'Chechin variant': Default         -> 1 outlier  was  removed (50.45 us)
  Kurtsev.'Kurtsev variant': Default         -> 3 outliers were removed (400.00 us..679.12 us)
  Panov.'Panov variant': Default             -> 1 outlier  was  removed (199.85 us)
  Raznopolov.'Raznopolov variant': Default   -> 2 outliers were removed (36.10 us, 36.53 us)
  Raznopolov2.'Raznopolov2 variant': Default -> 2 outliers were removed (47.68 us, 65.12 us)

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