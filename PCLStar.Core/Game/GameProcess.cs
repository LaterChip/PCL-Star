using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PCLStar.Core.Game
{
    public class GameProcess
    {
        public Process Process { get; private set; }

        public async Task StartAsync(LaunchArgument args)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = args.JavaPath,
                Arguments = string.Join(" ", args.BuildJvmArgs()) + " " + string.Join(" ", args.BuildGameArgs()),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = args.GameDir
            };
            Process = Process.Start(startInfo);
            await Task.CompletedTask;
        }

        public async Task<int> WaitForExitAsync()
        {
            await Process.WaitForExitAsync();
            return Process.ExitCode;
        }
    }
}
