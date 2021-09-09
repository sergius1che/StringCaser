# String caser

Дана строка символов, длиной N. Необходимо вывести все возможные варианты исходной строки, где символы могут быть в upper case или в lower case, символы позицию не меняют. Пример, дано "ab" -> result: "ab", "Ab", "aB", "AB"
Строка будет только из букв в нижнем регистре

# Benchmark result

```
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
AMD Ryzen 5 1500X, 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.400
  [Host]     : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  DefaultJob : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT


|        Type | Method |      input |         Mean |        Error |       StdDev |     Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------ |------- |----------- |-------------:|-------------:|-------------:|----------:|---------:|---------:|----------:|
|     Antonov |     Do | qwertyuiop |    518.68 us |     5.176 us |     4.842 us |  147.4609 |        - |        - |    604 KB |
|    Antonov2 |     Do | qwertyuiop |    497.74 us |     9.850 us |    12.808 us |  142.5781 |   0.4883 |        - |    584 KB |
| Bezruchenko |     Do | qwertyuiop |    345.96 us |     1.680 us |     1.489 us |  142.5781 |   0.4883 |        - |    584 KB |
|     Chechin |     Do | qwertyuiop |     54.07 us |     1.040 us |     1.197 us |   13.6719 |   0.0610 |        - |     56 KB |
|     Kurtsev |     Do | qwertyuiop |    351.15 us |     5.639 us |     4.709 us |   83.9844 |   0.4883 |        - |    344 KB |
|     Novikov |     Do | qwertyuiop |    224.19 us |     4.261 us |     4.376 us |   70.8008 |   0.2441 |        - |    290 KB |
|       Panov |     Do | qwertyuiop |    211.76 us |     2.842 us |     2.373 us |   65.6738 |   0.2441 |        - |    269 KB |
|  Raznopolov |     Do | qwertyuiop |     45.46 us |     0.864 us |     0.675 us |   15.6860 |   0.0610 |        - |     64 KB |
| Raznopolov2 |     Do | qwertyuiop |     46.51 us |     0.830 us |     0.776 us |   13.6719 |   0.0610 |        - |     56 KB |
|   Samarskii |     Do | qwertyuiop |    122.24 us |     0.666 us |     0.556 us |   50.7813 |   0.2441 |        - |    208 KB |
|       Yurin |     Do | qwertyuiop | 78,269.56 us | 1,518.553 us | 2,495.026 us | 9428.5714 | 714.2857 | 142.8571 | 41,416 KB |

// * Hints *
Outliers
  Bezruchenko.Do: Default -> 1 outlier  was  removed (352.83 us)
  Kurtsev.Do: Default     -> 2 outliers were removed (370.80 us, 389.41 us)
  Novikov.Do: Default     -> 1 outlier  was  removed (293.00 us)
  Panov.Do: Default       -> 2 outliers were removed (220.00 us, 221.16 us)
  Raznopolov.Do: Default  -> 3 outliers were removed (48.79 us..55.22 us)
  Samarskii.Do: Default   -> 2 outliers were removed (125.33 us, 125.54 us)

// * Legends *
  input     : Value of the 'input' parameter
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen 0     : GC Generation 0 collects per 1000 operations
  Gen 1     : GC Generation 1 collects per 1000 operations
  Gen 2     : GC Generation 2 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)
```