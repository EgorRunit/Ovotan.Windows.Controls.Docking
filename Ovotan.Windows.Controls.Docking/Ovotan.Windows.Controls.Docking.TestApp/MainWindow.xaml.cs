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
        DockingHost _host;
        DockingMessageQueue _queue;

        public MainWindow()
        {
            _queue = new DockingMessageQueue();
            _host = new DockingHost(_queue);
            _host.SetValue(Grid.RowProperty, 1);
            InitializeComponent();
            MainGrid.Children.Add(_host);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            _host.AttachPanelDock(Enums.PanelAttachedType.Left, new TestPanel());
        }

        private void _attachPanelLeft(object sender, RoutedEventArgs e)
        {
            _host.AttachPanelDock(Enums.PanelAttachedType.Left, new TestPanel());
        }
        private void _attachPanelRight(object sender, RoutedEventArgs e)
        {
            _host.AttachPanelDock(Enums.PanelAttachedType.Right, new TestPanel());
        }
        private void _attachPanelTop(object sender, RoutedEventArgs e)
        {
            _host.AttachPanelDock(Enums.PanelAttachedType.Top, new TestPanel());
        }
        private void _attachPanelBottom(object sender, RoutedEventArgs e)
        {
            _host.AttachPanelDock(Enums.PanelAttachedType.Bottom, new TestPanel());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            _queue.Publish(Enums.DockingMessageType.ShowDockPanelWindow, new TestPanel());
        }
    }
}