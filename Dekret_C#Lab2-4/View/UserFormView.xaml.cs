using Dekret_CSharpLab2.ViewModel;
using System.Windows.Controls;

namespace Dekret_CSharpLab2.View
{
    
    public partial class UserFormView : UserControl
    {
        public UserFormView()
        {
            DataContext = new UserFormViewModel();
            InitializeComponent();
        }
    }
}
