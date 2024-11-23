using System.Windows;

namespace Ovotan.Windows.Controls.Docking.Interfaces

{
    public interface IDockPanel : IDockGridChild
    {
        event RoutedEventHandler Close;
        string Header { get; set; }
        void OnClose();
    }
}
