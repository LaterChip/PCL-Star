using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace PCLStar.Core.Game
{
    public static class JavaDetector
    {
        public static List<string> FindJavaPaths()
        {
            var paths = new List<string>();
            // 环境变量
            var javaHome = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(javaHome)) paths.Add(Path.Combine(javaHome, "bin", "java.exe"));

            // 注册表 64位
            using var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment");
            if (key != null)
            {
                foreach (var sub in key.GetSubKeyNames())
                {
                    using var subKey = key.OpenSubKey(sub);
                    var home = subKey?.GetValue("JavaHome")?.ToString();
                    if (!string.IsNullOrEmpty(home)) paths.Add(Path.Combine(home, "bin", "java.exe"));
                }
            }
            return paths.Distinct().Where(File.Exists).ToList();
        }
    }
}
