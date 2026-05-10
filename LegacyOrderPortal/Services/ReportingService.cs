using System;
using System.IO;
using System.Linq;
using System.Web.Configuration;
using LegacyOrderPortal.DAL;
using LegacyOrderPortal.Logging;

namespace LegacyOrderPortal.Services
{
    public class ReportingService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly FileLogger logger = new FileLogger();
        private readonly string outputPath;

        public ReportingService()
        {
            unitOfWork = new UnitOfWork();
            outputPath = WebConfigurationManager.AppSettings["ReportOutputPath"] ?? "App_Data\\reports";
        }

        public string GenerateOrderSummaryReport()
        {
            var orders = unitOfWork.Context.Orders.ToList();
            var content = $"Order summary report generated on {DateTime.Now:yyyy-MM-dd HH:mm}\r\nTotal orders: {orders.Count}\r\n";

            var path = EnsureOutputPath();
            var fileName = Path.Combine(path, $"order-summary-{DateTime.Today:yyyyMMdd}.txt");
            File.WriteAllText(fileName, content);
            logger.Log($"Report written to {fileName}");
            return fileName;
        }

        private string EnsureOutputPath()
        {
            var root = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(root, outputPath.Replace("/", "\\"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
