using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.FastConsole;


namespace Benchmarking
{
    //[Config(typeof(TestConfig))]
    //[KeepBenchmarkFiles]
    //[SimpleJob(launchCount: 3, warmupCount: 3, targetCount: 10)]
    //[SimpleJob(RunStrategy.ColdStart)]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Roman)]
    public class SerilogSinksTest
    {
        private readonly ILogger _fileLogger;
        private readonly ILogger _asyncFileLogger;
        private readonly ILogger _consoleLogger;
        private readonly ILogger _asyncConsoleLogger;
        private readonly ILogger _fastConsole;
        


        private static Exception ex = new($"asdg asdg asdgf asdfgasg" +
                                                    $"gasdfgasgfasdfgh adsfghads fh dh" +
                                                    $"ads rfhgadfshadfsh a dsfhga fdhadf h" +
                                                    $"adfh gdfhadsfh" +
                                                    $" aderfhb a fdhadf hbadfhasdfh adf" +
                                                    $"adf hadfhadfh adfh" +
                                                    $"asd fhsdfsdfhsdhf");

        public SerilogSinksTest()
        {

            var logEventLevel = LogEventLevel.Warning;

            _fileLogger = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.File("logs/fileLogger.log")
                .CreateLogger();

            _asyncFileLogger = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.Async(a => a.File("logs/asyncFileLogger.log"))
                .CreateLogger();

            _consoleLogger = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.Console()
                .CreateLogger();

            _asyncConsoleLogger = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.Async(writeTo => writeTo.Console())
                .CreateLogger();

            var config = new FastConsoleSinkOptions { UseJson = true };
            _fastConsole = new LoggerConfiguration()
                .MinimumLevel.Is(logEventLevel)
                .WriteTo.FastConsole(config)
                .CreateLogger();
        }

        static void Log(ILogger logger)
        {
            logger.Verbose($"asdgas asgas asgas asdga sdgsad asdg");
            logger.Debug($"asdgas asgas asgas asdga sdgsad asdg");
            logger.Information($"asdgas asgas asgas asdga sdgsad asdg");
            logger.Warning(ex, $"asdgas asgas asgas asdga sdgsad asdg");
            logger.Error(ex, $"asdgas asgas asgas asdga sdgsad asdg");
        }


        [Benchmark]
        public void FileLogger() => Log(_fileLogger);

        [Benchmark]
        public void AsyncFileLogger() => Log(_asyncFileLogger);


        [Benchmark(Baseline = true)]
        public void ConsoleLogger() => Log(_consoleLogger);

        [Benchmark]
        public void AsyncConsoleLogger() => Log(_asyncConsoleLogger);

        [Benchmark]
        public void FastConsoleLogger() => Log(_fastConsole);

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            ((Logger)_fileLogger).Dispose();
            ((Logger)_asyncFileLogger).Dispose();
            ((Logger)_consoleLogger).Dispose();
            ((Logger)_asyncConsoleLogger).Dispose();
            ((Logger)_fastConsole).Dispose();
        }
    }
}
