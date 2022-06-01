``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1706 (21H2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|             Method |         Mean |       Error |      StdDev |  Gen 0 |  Gen 1 | Allocated |
|------------------- |-------------:|------------:|------------:|-------:|-------:|----------:|
|         FileLogger |     880.4 ns |    58.31 ns |   162.53 ns | 0.0687 |      - |     432 B |
|      ConsoleLogger | 453,558.1 ns | 5,739.92 ns | 4,793.10 ns |      - |      - |   4,786 B |
| AsyncConsoleLogger |     840.5 ns |    16.19 ns |    16.62 ns | 0.0811 | 0.0076 |     512 B |
|    AsyncFileLogger |   1,467.5 ns |    26.67 ns |    30.72 ns | 0.0687 |      - |     432 B |
