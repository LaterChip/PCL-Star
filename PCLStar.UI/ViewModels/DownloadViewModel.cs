using PCLStar.Core.Download;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System;

namespace PCLStar.UI.ViewModels
{
    public class DownloadViewModel : BaseViewModel
    {
        public ObservableCollection<string> AvailableVersions { get; set; } = new ObservableCollection<string>();

        public ICommand SearchVersionCommand => new RelayCommand(async () =>
        {
            // 模拟从 BMCLAPI 获取版本列表
            using var http = new HttpClient();
            var json = await http.GetStringAsync("https://bmclapi2.byim.top/launcher/v1/version/list");
            var arr = JObject.Parse(json)?["versions"] as JArray;
            AvailableVersions.Clear();
            if (arr != null)
            {
                foreach (var item in arr)
                    AvailableVersions.Add(item["id"]?.ToString());
            }
        });

        public ICommand DownloadVersionCommand => new RelayCommand(async () =>
        {
            // 实际调用 Core 层下载
        });
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        public RelayCommand(Action execute) => _execute = execute;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _execute?.Invoke();
        public event EventHandler CanExecuteChanged;
    }
}
