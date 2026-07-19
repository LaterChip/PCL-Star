using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PCLStar.Core.Game
{
    public static class JavaDetector
    {
        public static List<string> FindJavaPaths()
        {
            var paths = new List<string>();

            // 1. 环境变量 JAVA_HOME
            var javaHome = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(javaHome))
            {
                var path = Path.Combine(javaHome, "bin", "java.exe");
                if (File.Exists(path)) paths.Add(path);
            }

            // 2. 注册表 (64位)
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment");
                if (key != null)
                {
                    foreach (var subName in key.GetSubKeyNames())
                    {
                        using var subKey = key.OpenSubKey(subName);
                        var home = subKey?.GetValue("JavaHome")?.ToString();
                        if (!string.IsNullOrEmpty(home))
                        {
                            var path = Path.Combine(home, "bin", "java.exe");
                            if (File.Exists(path)) paths.Add(path);
                        }
                    }
                }
            }
            catch { /* 忽略注册表访问错误 */ }

            return paths.Distinct().ToList();
        }
    }
}
