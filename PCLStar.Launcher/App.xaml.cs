using System.Windows;

namespace PCLStar.Launcher
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // 全局异常捕获等
            Current.DispatcherUnhandledException += (s, args) =>
            {
                MessageBox.Show($"发生错误: {args.Exception.Message}", "PCLStar");
                args.Handled = true;
            };
        }
    }
}
