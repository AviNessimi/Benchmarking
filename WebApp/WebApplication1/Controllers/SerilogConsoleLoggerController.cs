using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("Test")]
    public class SerilogConsoleLoggerController : ControllerBase
    {
        private static Exception ex = new("asdg asdg asdgf asdfgasg" +
                                          "gasdfgasgfasdfgh adsfghads fh dh" +
                                          "ads rfhgadfshadfsh a dsfhga fdhadf h" +
                                          "adfh gdfhadsfh" +
                                          " aderfhb a fdhadf hbadfhasdfh adf" +
                                          "adf hadfhadfh adfh" +
                                          "asd fhsdfsdfhsdhf");

        private static string msg = "asdgas asgas asgas asdga sdgsad asdg";

        [HttpGet("console")] public void ConsoleGet() => Log(SerilogLoggers.ConsoleLogger);
        [HttpGet("asyncConsole")] public void AsyncConsole() => Log(SerilogLoggers.AsyncConsoleLogger);

        static void Log(Serilog.ILogger logger)
        {
            for (int i = 0; i < 10; i++)
            {
                logger.Verbose(msg);
                logger.Debug(msg);
                logger.Information(msg);
                logger.Warning(ex, msg);
                logger.Error(ex, msg);
            }
        }
    }
}