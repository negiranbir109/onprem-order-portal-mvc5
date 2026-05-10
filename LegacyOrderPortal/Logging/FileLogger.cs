using System;
using System.IO;
using System.Web.Hosting;

namespace LegacyOrderPortal.Logging
{
    public class FileLogger
    {
        private readonly string logPath;

        public FileLogger()
        {
            var appData = HostingEnvironment.MapPath("~/App_Data") ?? AppDomain.CurrentDomain.BaseDirectory + "App_Data";
            logPath = Path.Combine(appData, "app.log");
        }

        public void Log(string message)
        {
            try
            {
                var text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                File.AppendAllText(logPath, text);
            }
            catch
            {
                // Legacy logger swallows exceptions in the on-prem environment.
            }
        }
    }
}
