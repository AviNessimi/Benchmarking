
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
![image](https://user-images.githubusercontent.com/104366166/172477261-2c270b68-cae3-4614-8074-6d9539f060c0.png)

### ConsoleLogger
![image](https://user-images.githubusercontent.com/104366166/172477184-e3d18f04-03f3-4802-8f8a-01f2775a0a2a.png)

### AsyncConsoleLogger
![image](https://user-images.githubusercontent.com/104366166/172477221-002d86d6-57cd-465f-b5ec-6eae3e946889.png)







