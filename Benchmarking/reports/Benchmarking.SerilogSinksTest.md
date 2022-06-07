
# Serilog Sinks Benchmark Test

## Debian 11 (container)
``` ini

BenchmarkDotNet=v0.13.1, OS=debian 11 (container)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT

```
#### LogEventLevel.Warning

|             Method |        Mean |       Error |      StdDev |      Median | Rank |  Gen 0 |  Gen 1 |  Gen 2 | Allocated |
|------------------- |------------:|------------:|------------:|------------:|-----:|-------:|-------:|-------:|----------:|
|         FileLogger |    275.1 ns |     5.53 ns |     9.08 ns |    271.9 ns |    I | 0.0458 |      - |      - |     288 B |
|    AsyncFileLogger |    769.4 ns |    44.34 ns |   130.04 ns |    809.3 ns |   II | 0.0458 |      - |      - |     288 B |
| AsyncConsoleLogger |  1,445.1 ns |   147.17 ns |   405.35 ns |  1,350.1 ns |  III | 0.0534 | 0.0019 | 0.0019 |     336 B |
|      ConsoleLogger | 23,351.7 ns | 1,216.14 ns | 3,369.92 ns | 24,039.0 ns |   IV | 0.5798 |      - |      - |   3,728 


## JMeter
- Latest Sample: This is the sample time in millisecond.It is the response time for the last request
- The Throughput: is the number of requests per unit of time (seconds, minutes, hours) that are sent to server during the test.
- Average: This is the Average (Arithmetic mean) Response time of total samples.
- Median: This the midpoint of a frequency distribution.

***An important thing to understand is that the mean value can be very misleading as it does not show you how close (or far) your values are from the average.For this purpose, we need the Deviation value since Average value can be the Same for different response time of the samples!!

- Deviation: The standard deviation (σ) measures the mean distance of the values to their average (μ).It gives you a good idea of the dispersion or variability of the measures to their mean value.

![image](https://user-images.githubusercontent.com/104366166/172484000-9e138cb6-3210-4cf0-8a9c-aed6e4ab8826.png)

#### LogEventLevel.Verbose

### ConsoleLogger
**Execution Time ~= 08:30 min**
![image](https://user-images.githubusercontent.com/104366166/172483294-b75d3094-dc4b-409d-b96e-36525701bdcb.png)

### AsyncConsoleLogger
**Execution Time ~= 01:30 min**
![image](https://user-images.githubusercontent.com/104366166/172483928-0c117e51-6b50-4689-8243-b888d3cc4020.png)








