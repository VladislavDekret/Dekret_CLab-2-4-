using System.ComponentModel;
using System.Windows;

namespace Dekret_CSharpLab2.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
