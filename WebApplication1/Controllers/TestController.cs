using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static Exception ex = new("asdg asdg asdgf asdfgasg" +
                                          "gasdfgasgfasdfgh adsfghads fh dh" +
                                          "ads rfhgadfshadfsh a dsfhga fdhadf h" +
                                          "adfh gdfhadsfh" +
                                          " aderfhb a fdhadf hbadfhasdfh adf" +
                                          "adf hadfhadfh adfh" +
                                          "asd fhsdfsdfhsdhf");

        private static string msg = "asdgas asgas asgas asdga sdgsad asdg";

        [HttpGet("console")]
        public void ConsoleGet()
        {
            Loggers.ConsoleLogger.Verbose(msg);
            Loggers.ConsoleLogger.Debug(msg);
            Loggers.ConsoleLogger.Information(msg);
            Loggers.ConsoleLogger.Warning(ex, msg);
            Loggers.ConsoleLogger.Error(ex, msg);
        }


        [HttpGet("asyncConsole")]
        public void AsyncConsole()
        {
            Loggers.AsyncConsoleLogger.Verbose(msg);
            Loggers.AsyncConsoleLogger.Debug(msg);
            Loggers.AsyncConsoleLogger.Information(msg);
            Loggers.AsyncConsoleLogger.Warning(ex, msg);
            Loggers.AsyncConsoleLogger.Error(ex, msg);
        }
    }
}