using System;
using System.IO;

namespace PCLStar.Core.Common
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Debug
    }

    public static class LogHelper
    {
        private static readonly string _logDir = Path.Combine(GlobalConst.DataDir, "logs");
        private static readonly object _lock = new object();

        static LogHelper()
        {
            if (!Directory.Exists(_logDir))
                Directory.CreateDirectory(_logDir);
        }

        // 公开的写入方法（原为 private，现改为 public）
        public static void Write(LogLevel level, string message, string module = "General")
        {
            var time = DateTime.Now;
            var logFile = Path.Combine(_logDir, $"{time:yyyy-MM-dd}.log");
            var line = $"[{time:HH:mm:ss}] [{level}] [{module}] {message}";
            
            lock (_lock)
            {
                File.AppendAllText(logFile, line + Environment.NewLine);
            }
            
            // 同时输出到控制台（调试用）
            Console.WriteLine(line);
        }

        public static void Info(string msg, string module = "General") => Write(LogLevel.Info, msg, module);
        public static void Warning(string msg, string module = "General") => Write(LogLevel.Warning, msg, module);
        public static void Error(string msg, string module = "General") => Write(LogLevel.Error, msg, module);
        public static void Exception(Exception ex, string module = "General") => Write(LogLevel.Error, ex.ToString(), module);
    }
}
