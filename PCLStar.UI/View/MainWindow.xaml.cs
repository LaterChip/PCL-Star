using System.Windows;
using PCLStar.UI.ViewModels;

namespace PCLStar.UI.Views
{
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
            MainFrame.Navigate(new LoginWindow());
        }
    }
}
