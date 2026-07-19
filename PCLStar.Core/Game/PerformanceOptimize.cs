namespace PCLStar.Core.Game
{
    public class PerformanceOptimize
    {
        public int MaxMemoryMB { get; set; } = 2048;
        public bool UseOptimizedGC { get; set; } = true;
        public bool EnableRenderThread { get; set; } = true;

        public string GetJvmArgs() => UseOptimizedGC ? "-XX:+UseG1GC" : "";
    }
}
