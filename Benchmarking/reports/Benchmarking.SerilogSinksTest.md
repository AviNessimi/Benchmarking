
# Serilog Sinks Benchmark Test

## Win10
``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
# Verbose

|             Method |         Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Allocated |
|------------------- |-------------:|------------:|------------:|-------:|-------:|----------:|
|         FileLogger |     880.4 ns |    58.31 ns |   162.53 ns | 0.0687 |      - |     432 B |
|      ConsoleLogger | 453,558.1 ns | 5,739.92 ns | 4,793.10 ns |      - |      - |   4,786 B |
| AsyncConsoleLogger |     840.5 ns |    16.19 ns |    16.62 ns | 0.0811 | 0.0076 |     512 B |
|    AsyncFileLogger |   1,467.5 ns |    26.67 ns |    30.72 ns | 0.0687 |      - |     432 B |

|             Method |         Mean |       Error |      StdDev |       Median | Rank |
|------------------- |-------------:|------------:|------------:|-------------:|-----:|
|         FileLogger |    21.808 us |   0.4339 us |   0.7249 us |    21.913 us |  III |
|      ConsoleLogger | 1,979.253 us | 152.6930 us | 435.6418 us | 1,944.404 us |   IV |
| AsyncConsoleLogger |     1.623 us |   0.0745 us |   0.2197 us |     1.716 us |    I |
|    AsyncFileLogger |     2.266 us |   0.1057 us |   0.3117 us |     2.360 us |   II |

## Warning

|             Method |           Mean |        Error |        StdDev |  Gen 0 |  Gen 1 | Allocated |
|------------------- |---------------:|-------------:|--------------:|-------:|-------:|----------:|
|         FileLogger |       736.1 ns |     15.83 ns |      40.57 ns | 0.0687 |      - |     432 B |
|      ConsoleLogger | 1,235,428.0 ns | 43,660.74 ns | 128,049.41 ns |      - |      - |   4,789 B |
| AsyncConsoleLogger |     1,483.5 ns |     14.24 ns |      13.32 ns | 0.0801 | 0.0038 |     508 B |
|    AsyncFileLogger |     2,221.8 ns |     39.76 ns |      35.25 ns | 0.0687 |      - |     432 B |




## Debian 11 (container)
``` ini

BenchmarkDotNet=v0.13.1, OS=debian 11 (container)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

```
# Verbose
|             Method |        Mean |       Error |      StdDev |      Median |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------------- |------------:|------------:|------------:|------------:|-------:|-------:|-------:|----------:|
|         FileLogger |    444.5 ns |     6.55 ns |    13.08 ns |    443.6 ns | 0.0610 |      - |      - |     432 B |
|      ConsoleLogger | 56,532.9 ns | 1,117.83 ns | 2,333.32 ns | 56,797.5 ns | 0.7324 |      - |      - |   4,768 B |
| AsyncConsoleLogger |    690.5 ns |    24.27 ns |    69.25 ns |    671.7 ns | 0.0877 | 0.0229 | 0.0038 |     551 B |
|    AsyncFileLogger |  1,385.0 ns |    81.54 ns |   240.43 ns |  1,493.8 ns | 0.0687 | 0.0095 |      - |     433 B |


|             Method |        Mean |       Error |      StdDev |      Median | Rank |
|------------------- |------------:|------------:|------------:|------------:|-----:|
|         FileLogger |    429.9 ns |     8.59 ns |    12.85 ns |    428.6 ns |    I |
|      ConsoleLogger | 60,048.2 ns | 1,595.70 ns | 4,259.25 ns | 59,112.7 ns |   IV |
| AsyncConsoleLogger |  1,734.0 ns |    99.99 ns |   294.84 ns |  1,638.6 ns |   II |
|    AsyncFileLogger |  2,229.8 ns |   183.72 ns |   541.70 ns |  2,323.0 ns |  III |

## Warning
|             Method |         Mean |        Error |       StdDev |       Median |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------------- |-------------:|-------------:|-------------:|-------------:|-------:|-------:|-------:|----------:|
|         FileLogger |     466.5 ns |     18.85 ns |     49.66 ns |     449.3 ns | 0.0610 |      - |      - |     432 B |
|      ConsoleLogger | 338,847.7 ns | 15,662.16 ns | 45,934.42 ns | 343,868.9 ns | 0.7324 |      - |      - |   4,768 B |
| AsyncConsoleLogger |   2,534.7 ns |    125.97 ns |    369.46 ns |   2,402.7 ns | 0.0801 | 0.0114 | 0.0038 |     526 B |
|    AsyncFileLogger |   1,558.6 ns |    162.90 ns |    472.61 ns |   1,626.8 ns | 0.0687 |      - |      - |     432 B |

![image](https://user-images.githubusercontent.com/104366166/171481466-eec023ef-e723-45ad-a4fe-40d2bb02a8a8.png)

