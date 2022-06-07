using Serilog;
using Serilog.Events;


namespace WebApplication1.Controllers
{
    public static class Loggers
    {

        public static Serilog.ILogger ConsoleLogger = new LoggerConfiguration()
            .MinimumLevel.Is(LogEventLevel.Information)
        .WriteTo.Console()
        .CreateLogger();

        public static Serilog.ILogger AsyncConsoleLogger = new LoggerConfiguration()
            .MinimumLevel.Is(LogEventLevel.Information)
        .WriteTo.Async(writeTo => writeTo.Console())
        .CreateLogger();

    }
}
