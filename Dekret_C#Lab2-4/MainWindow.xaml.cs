using Dekret_CSharpLab2.ViewModel;
using System.Windows;


namespace Dekret_CSharpLab2
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
