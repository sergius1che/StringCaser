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
|     Antonov |     Do | qwertyuiop |    524.77 us |    10.449 us |    13.214 us |  147.4609 |        - |        - |    604 KB |
|    Antonov2 |     Do | qwertyuiop |    475.69 us |     1.592 us |     1.411 us |  142.5781 |   0.4883 |        - |    584 KB |
| Bezruchenko |     Do | qwertyuiop |    341.50 us |     1.139 us |     0.951 us |  142.5781 |   0.4883 |        - |    584 KB |
|     Chechin |     Do | qwertyuiop |     52.09 us |     0.375 us |     0.332 us |   13.6719 |   0.0610 |        - |     56 KB |
|     Kurtsev |     Do | qwertyuiop |    339.85 us |     3.758 us |     3.515 us |   83.9844 |   0.4883 |        - |    344 KB |
|     Novikov |     Do | qwertyuiop |    214.97 us |     2.098 us |     1.859 us |   70.8008 |   0.2441 |        - |    290 KB |
|       Panov |     Do | qwertyuiop |    204.30 us |     0.531 us |     0.443 us |   65.6738 |   0.2441 |        - |    269 KB |
|  Raznopolov |     Do | qwertyuiop |     44.84 us |     0.227 us |     0.190 us |   15.6860 |   0.0610 |        - |     64 KB |
| Raznopolov2 |     Do | qwertyuiop |     45.19 us |     0.220 us |     0.183 us |   13.6719 |   0.0610 |        - |     56 KB |
|       Yurin |     Do | qwertyuiop | 73,924.66 us | 1,412.774 us | 1,252.388 us | 9428.5714 | 857.1429 | 142.8571 | 41,416 KB |

// * Hints *
Outliers
  Antonov.Do: Default     -> 1 outlier  was  removed (689.52 us)
  Antonov2.Do: Default    -> 1 outlier  was  removed (482.02 us)
  Bezruchenko.Do: Default -> 2 outliers were removed, 3 outliers were detected (339.34 us, 346.20 us, 360.36 us)
  Chechin.Do: Default     -> 1 outlier  was  removed (54.34 us)
  Novikov.Do: Default     -> 1 outlier  was  removed (226.53 us)
  Panov.Do: Default       -> 2 outliers were removed (205.94 us, 209.39 us)
  Raznopolov.Do: Default  -> 2 outliers were removed (45.42 us, 45.51 us)
  Raznopolov2.Do: Default -> 2 outliers were removed (45.97 us, 47.28 us)
  Yurin.Do: Default       -> 1 outlier  was  removed (77.11 ms)

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