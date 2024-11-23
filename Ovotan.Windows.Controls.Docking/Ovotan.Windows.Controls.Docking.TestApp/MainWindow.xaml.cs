using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ovotan.Windows.Controls.Docking.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int _headerIndex;
        DockingHost _host;

        public MainWindow()
        {
            _host = new DockingHost();
            _host.SetValue(Grid.RowProperty, 1);
            InitializeComponent();
            MainGrid.Children.Add(_host);
        }


        private void _attachPanelLeft(object sender, RoutedEventArgs e)
        {
            _headerIndex++;
            _host.AttachToSiteHost(new DockPanel() { Header = $"Header {_headerIndex}"}, Dock.Left);
        }
        private void _attachPanelRight(object sender, RoutedEventArgs e)
        {
            _headerIndex++;
            _host.AttachToSiteHost(new DockPanel() { Header = $"Header {_headerIndex}" }, Dock.Right);
        }
        private void _attachPanelTop(object sender, RoutedEventArgs e)
        {
            _headerIndex++;
            _host.AttachToSiteHost(new DockPanel() { Header = $"Header {_headerIndex}" }, Dock.Top);
        }
        private void _attachPanelBottom(object sender, RoutedEventArgs e)
        {
            _headerIndex++;
            _host.AttachToSiteHost(new DockPanel() { Header = $"Header {_headerIndex}" }, Dock.Bottom);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _headerIndex++;
            //_queue.Publish(Enums.DockingMessageType.ShowDockPanelWindow, new DockPanel());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            _host.SiteHost.AddDocument(new TestDocument());
        }
    }
}