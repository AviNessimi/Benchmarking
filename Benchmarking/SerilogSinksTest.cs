using BenchmarkDotNet.Attributes;
using Serilog;
using Serilog.Events;


namespace Benchmarking
{
    [MemoryDiagnoser]
    //[SimpleJob(RuntimeMoniker.CoreRt60)]
    public class SerilogSiknsTest
    {
        private readonly ILogger _fileLogger;
        private readonly ILogger _consoleLogger;
        private readonly ILogger _asyncConsoleLogger;
        private readonly ILogger _asyncFileLogger;
        

        private static Exception ex = new ($"asdg asdg asdgf asdfgasg" +
                                                    $"gasdfgasgfasdfgh adsfghads fh dh" +
                                                    $"ads rfhgadfshadfsh a dsfhga fdhadf h" +
                                                    $"adfh gdfhadsfh" +
                                                    $" aderfhb a fdhadf hbadfhasdfh adf" +
                                                    $"adf hadfhadfh adfh" +
                                                    $"asd fhsdfsdfhsdhf");

        public SerilogSiknsTest()
        {

            var logEventLevel = LogEventLevel.Verbose;

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
                .WriteTo.Async(writeTo => writeTo.Console())
                .CreateLogger();

            _asyncFileLogger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", logEventLevel)
                .Enrich.FromLogContext()
                .WriteTo.Async(a => a.File("logs/asyncFileLogger.log"))
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
