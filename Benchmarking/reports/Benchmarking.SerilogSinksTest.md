
# Serilog Sinks Benchmark Test

## Debian 11 (container)
``` ini

BenchmarkDotNet=v0.13.1, OS=debian 11 (container)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

```
### LogEventLevel.Warning

|             Method |        Mean |       Error |      StdDev |      Median | Rank |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------------- |------------:|------------:|------------:|------------:|-----:|-------:|-------:|-------:|----------:|
|         FileLogger |    275.1 ns |     5.53 ns |     9.08 ns |    271.9 ns |    I | 0.0458 |      - |      - |     288 B |
|    AsyncFileLogger |    769.4 ns |    44.34 ns |   130.04 ns |    809.3 ns |   II | 0.0458 |      - |      - |     288 B |
| AsyncConsoleLogger |  1,445.1 ns |   147.17 ns |   405.35 ns |  1,350.1 ns |  III | 0.0534 | 0.0019 | 0.0019 |     336 B |
|      ConsoleLogger | 23,351.7 ns | 1,216.14 ns | 3,369.92 ns | 24,039.0 ns |   IV | 0.5798 |      - |      - |   3,728 


## JMeter

![image](https://user-images.githubusercontent.com/104366166/172455228-8ab18f72-0e08-44d9-ba52-4295ca53ed4b.png)

### ConsoleLogger
![image](https://user-images.githubusercontent.com/104366166/172464632-dd49e91b-fc1d-4c6d-9ad8-ce00d262b6ee.png)

### AsyncConsoleLogger
![image](https://user-images.githubusercontent.com/104366166/172464758-dd43d8a6-3663-41b0-87d1-2d090d4248b8.png)

-----------------------------------------------------------------------------------------------------------------
![image](https://user-images.githubusercontent.com/104366166/172473315-ab68b738-e60d-45b8-8653-2dd238f12d68.png)

### ConsoleLogger
![image](https://user-images.githubusercontent.com/104366166/172473252-84ed10a4-fad2-43be-8533-f665c29b3202.png)

### AsyncConsoleLogger
![image](https://user-images.githubusercontent.com/104366166/172473140-673820f5-99b7-4964-858e-e779c92959f8.png)







