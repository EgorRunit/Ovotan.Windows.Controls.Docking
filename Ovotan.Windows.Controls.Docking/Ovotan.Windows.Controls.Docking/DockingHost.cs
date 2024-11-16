using Ovotan.Windows.Controls.Docking.Enums;
using Ovotan.Windows.Controls.Docking.Interfaces;
using Ovotan.Windows.Controls.Docking.Messages;
using Ovotan.Windows.Controls.Docking.Services;
using Ovotan.Windows.Controls.Docking.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ovotan.Windows.Controls.Docking
{
    public interface IDockingHost
    {
        void AttachToLeft(IDockPanel panel);
        void AttachToTop(IDockPanel panel);
        void AttachToRight(IDockPanel panel);
        void AttachToBottom(IDockPanel panel);
    }

    public class DockingHost : ContentControl, IDockingHost
    {
        public DockGridWindow _panelDragGrid;
        /// <summary>
        /// Ссылка на последнию активную панель.
        /// </summary>
        DockPanel _oldPanelFocused;
        /// <summary>
        /// Экземпляр сервиса для создания контейнеров для DockPanel.
        /// </summary>
        IDockConstractureService _dockConstractureService;
        /// <summary>
        /// Экземпляр сервиса очереди сообщений для DockingManager.
        /// </summary>
        public IDockingMessageQueue _dockingMessageQueue;
        public ISiteHost SiteHost { get; set; }

        public DockGrid DockGrid
        {
            get
            {
                return Content as DockGrid;
            }
        }

        static DockingHost()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockingHost), new FrameworkPropertyMetadata(typeof(DockingHost)));
            //SchemaManager.AddResource("pack://application:,,,/Ovotan.Windows.Controls.Docking;component/Resources/CanvasButtonResourcesDictionary.xaml");
            //SchemaManager.AddResource("pack://application:,,,/Ovotan.Windows.Controls.Docking;component/Resources/DockPanelResourcesDictionary.xaml");
            //SchemaManager.AddResource("pack://application:,,,/Ovotan.Windows.Controls.Docking;component/Resources/DockHositngSettingsResources.xaml");
        }

        public DockingHost(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
            _panelDragGrid = new DockGridWindow(this);
            _dockingMessageQueue.Register(DockingMessageType.PanelClosed, (x) => _dockConstractureService.RemovePanel(x as DockPanel));
            _dockingMessageQueue.Register(DockingMessageType.ShowDockPanelWindow, (x) => ShowDockPanelWindow(x as FrameworkElement));
            _dockConstractureService = new DockConstractureService(_dockingMessageQueue);

            SiteHost = new SiteHost(_dockingMessageQueue);

            var baseContent = new DockPanel(_dockingMessageQueue, SiteHost as FrameworkElement);
            var grid = new DockGrid();
            Content = grid;
            grid.Append(baseContent);
            
            //Padding = new Thickness(5);
            //Background = new SolidColorBrush(Colors.Red);
            Mouse.AddPreviewMouseDownHandler(this, (x, y) =>
            {
                if(_oldPanelFocused != null)
                {
                    _oldPanelFocused.IsPanelFocused = false;
                }
                _oldPanelFocused = y.Source as DockPanel;
                if (_oldPanelFocused != null)
                {
                    _oldPanelFocused.IsPanelFocused = true;
                }

            });

        }

        public void AttachToLeft(IDockPanel panel)
        {
            var grid = DockGrid;
            Content = new DockGrid();
            DockGrid.Append(grid);
            DockGrid.AppendLeft(panel);
        }

        public void AttachToTop(IDockPanel panel)
        {
            var grid = DockGrid;
            Content = new DockGrid();
            DockGrid.Append(grid);
            DockGrid.AppendTop(panel);
        }

        public void AttachToRight(IDockPanel panel)
        {
            var grid = DockGrid;
            Content = new DockGrid();
            DockGrid.Append(grid);
            DockGrid.AppendRight(panel);
        }

        public void AttachToBottom(IDockPanel panel)
        {
            var grid = DockGrid;
            Content = new DockGrid();
            DockGrid.Append(grid);
            DockGrid.AppendBottom(panel);
        }



        public void ShowDockPanelWindow(FrameworkElement DockPanelContent)
        { 
            var window = new DockPanelWindow(_panelDragGrid, DockPanelContent);
            window.Initialize(_dockingMessageQueue);
            window.Show();
        }
    }
}
