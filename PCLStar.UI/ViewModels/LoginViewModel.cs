using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using PCLStar.Core.Auth;

namespace PCLStar.UI.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        public string Username { get => _username; set { _username = value; OnPropertyChanged(); } }
        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }

        public async Task LoginAsync(AuthType type)
        {
            YggdrasilAuthResponse auth = null;
            switch (type)
            {
                case AuthType.Offline:
                    auth = await new OfflineAuth().LoginAsync(Username);
                    break;
                case AuthType.LittleSkin:
                    auth = await new LittleSkinAuth().LoginWithLittleSkinAsync(Username, Password);
                    break;
                default:
                    MessageBox.Show("请选择有效登录方式");
                    return;
            }
            await new AuthStorage().SaveAsync(auth);
            MessageBox.Show($"登录成功，欢迎 {auth.SelectedProfile?.Name}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
