using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PCLStar.Core.Mod
{
    public class ModManager
    {
        private readonly string _modDir;

        public ModManager(string gameDir)
        {
            _modDir = Path.Combine(gameDir, "mods");
            Directory.CreateDirectory(_modDir);
        }

        public List<string> GetModList() => Directory.GetFiles(_modDir, "*.jar").Select(Path.GetFileName).ToList();

        public void InstallMod(string jarPath)
        {
            var fileName = Path.GetFileName(jarPath);
            var dest = Path.Combine(_modDir, fileName);
            File.Copy(jarPath, dest, true);
        }

        public void DeleteMod(string fileName)
        {
            var path = Path.Combine(_modDir, fileName);
            if (File.Exists(path)) File.Delete(path);
        }
    }
}
