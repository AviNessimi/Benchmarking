using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using Serilog;
using Serilog.Events;


namespace Benchmarking
{
    public class TestConfig : ManualConfig
    {
        public TestConfig()
        {
            Add(RankColumn.Roman);
            Add(CsvMeasurementsExporter.Default);
            Add(RPlotExporter.Default);
            Add(PlainExporter.Default);
            Add(HtmlExporter.Default);
        }
    }

    [MemoryDiagnoser]
    [KeepBenchmarkFiles]
    //[Config(typeof(TestConfig))]
    public class SerilogSinksTest
    {
        private readonly ILogger _fileLogger;
        private readonly ILogger _consoleLogger;
        private readonly ILogger _asyncConsoleLogger;
        private readonly ILogger _asyncFileLogger;


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
                .MinimumLevel.Override("Microsoft", logEventLevel)
                .WriteTo.File("logs/fileLogger.log")
                .CreateLogger();

            _consoleLogger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", logEventLevel)
                .WriteTo.Console()
                .CreateLogger();

            _asyncConsoleLogger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", logEventLevel)
                .Enrich.FromLogContext()
                .WriteTo.Async(writeTo
                    => writeTo.Console())
                .CreateLogger();

            _asyncFileLogger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", logEventLevel)
                .Enrich.FromLogContext()
                .WriteTo.Async(a
                    => a.File("logs/asyncFileLogger.log"))
                .CreateLogger();

            //Log.Logger = log;
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
        public void ConsoleLogger() => Log(_consoleLogger);

        [Benchmark]
        public void AsyncConsoleLogger() => Log(_asyncConsoleLogger);

        [Benchmark]
        public void AsyncFileLogger() => Log(_asyncFileLogger);

        //[GlobalCleanup]
        //public void GlobalCleanup()
        //{
        //    _consoleLogger.CloseAndFlush();
        //}
    }
}
