using System;
using System.IO;

namespace PCLStar.Core.Common
{
    public static class LogHelper
    {
        private static string _logPath => Path.Combine(GlobalConst.DataDir, "logs", $"{DateTime.Now:yyyy-MM-dd}.log");
        static LogHelper() => Directory.CreateDirectory(Path.GetDirectoryName(_logPath));

        public static void Log(string msg)
        {
            var line = $"[{DateTime.Now:HH:mm:ss}] {msg}";
            Console.WriteLine(line);
            File.AppendAllText(_logPath, line + Environment.NewLine);
        }

        public static void Error(Exception ex) => Log($"ERROR: {ex.Message}\n{ex.StackTrace}");
    }
}
