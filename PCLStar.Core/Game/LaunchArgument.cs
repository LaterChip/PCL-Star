using System.Collections.Generic;
using System.Text;

namespace PCLStar.Core.Game
{
    public class LaunchArgument
    {
        public string JavaPath { get; set; }
        public string ClassPath { get; set; }
        public string MainClass { get; set; }
        public string VersionName { get; set; }
        public string GameDir { get; set; }
        public string AssetIndex { get; set; }
        public string AuthPlayerName { get; set; }
        public string AccessToken { get; set; }
        public string UserType { get; set; } = "mojang";

        public List<string> BuildJvmArgs()
        {
            return new List<string>
            {
                "-Xmx2G",
                "-Djava.library.path=natives",
                $"-cp", ClassPath
            };
        }

        public List<string> BuildGameArgs()
        {
            return new List<string>
            {
                MainClass,
                "--version", VersionName,
                "--gameDir", GameDir,
                "--assetsDir", $"{GameDir}/assets",
                "--assetIndex", AssetIndex,
                "--uuid", AccessToken,
                "--accessToken", AccessToken,
                "--userType", UserType,
                "--username", AuthPlayerName
            };
        }
    }
}
