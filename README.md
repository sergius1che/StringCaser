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


|        Type | Method |      input |      Mean |    Error |    StdDev |    Median |    Gen 0 |  Gen 1 | Allocated |
|------------ |------- |----------- |----------:|---------:|----------:|----------:|---------:|-------:|----------:|
|     Antonov |     Do | qwertyuiop | 488.48 us | 9.484 us | 13.901 us | 490.72 us | 147.4609 |      - |    604 KB |
|    Antonov2 |     Do | qwertyuiop | 470.27 us | 4.227 us |  3.747 us | 470.57 us | 142.5781 | 0.4883 |    584 KB |
| Bezruchenko |     Do | qwertyuiop | 303.21 us | 5.962 us |  5.577 us | 302.44 us | 142.5781 | 0.4883 |    584 KB |
|     Chechin |     Do | qwertyuiop |  46.03 us | 0.916 us |  1.531 us |  45.39 us |  13.6719 | 0.0610 |     56 KB |
|     Kurtsev |     Do | qwertyuiop | 349.19 us | 6.829 us |  6.388 us | 348.03 us |  83.9844 | 0.4883 |    344 KB |
|     Novikov |     Do | qwertyuiop | 240.75 us | 4.356 us |  3.862 us | 240.00 us |  70.8008 | 0.2441 |    290 KB |
|       Panov |     Do | qwertyuiop | 171.67 us | 1.992 us |  1.863 us | 171.38 us |  65.6738 | 0.2441 |    269 KB |
|  Raznopolov |     Do | qwertyuiop |  34.89 us | 0.746 us |  2.117 us |  33.88 us |  15.6860 | 0.0610 |     64 KB |
| Raznopolov2 |     Do | qwertyuiop |  34.06 us | 0.620 us |  1.164 us |  33.69 us |  13.6719 | 0.0610 |     56 KB |

// * Warnings *
MultimodalDistribution
  Chechin.Do: Default -> It seems that the distribution can have several modes (mValue = 3)

// * Hints *
Outliers
  Antonov.Do: Default     -> 2 outliers were removed, 6 outliers were detected (454.52 us..469.28 us, 537.92 us, 792.22 us)
  Antonov2.Do: Default    -> 1 outlier  was  removed (486.95 us)
  Bezruchenko.Do: Default -> 2 outliers were removed (345.41 us, 609.56 us)
  Chechin.Do: Default     -> 2 outliers were removed (53.32 us, 54.30 us)
  Kurtsev.Do: Default     -> 2 outliers were removed (470.04 us, 507.92 us)
  Novikov.Do: Default     -> 1 outlier  was  removed (257.37 us)
  Raznopolov.Do: Default  -> 7 outliers were removed (42.47 us..54.97 us)
  Raznopolov2.Do: Default -> 5 outliers were removed (38.04 us..44.46 us)

// * Legends *
  input     : Value of the 'input' parameter
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Median    : Value separating the higher half of all measurements (50th percentile)
  Gen 0     : GC Generation 0 collects per 1000 operations
  Gen 1     : GC Generation 1 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)
```