using Ovotan.Windows.Controls.Docking.Enums;
using Ovotan.Windows.Controls.Docking.Interfaces;
using Ovotan.Windows.Controls.Docking.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ovotan.Windows.Controls.Docking
{
    public interface IDockingHost
    {
        /// <summary>
        /// Attach the panel to the sitehost from the specified side.
        /// </summary>
        /// <param name="panel">Instance of panel.</param>
        /// <param name="dock">The side from which it is attached.</param>
        void AttachToSiteHost(IDockPanel panel, Dock dock);
    }

    public class DockingHost : ContentControl, IDockingHost
    {
        public DockGridWindow _panelDragGrid;
        /// <summary>
        /// Ссылка на последнию активную панель.
        /// </summary>
        DockPanel _oldPanelFocused;
        /// <summary>
        /// Экземпляр сервиса очереди сообщений для DockingManager.
        /// </summary>
        public IDockingMessageQueue _dockingMessageQueue;
        public ISiteHost SiteHost { get; private set; }

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
        }

        public DockingHost(IDockingMessageQueue dockingMessageQueue)
        {
            _dockingMessageQueue = dockingMessageQueue;
            _panelDragGrid = new DockGridWindow(this);
            //_dockingMessageQueue.Register(DockingMessageType.ShowDockPanelWindow, (x) => ShowDockPanelWindow(x as FrameworkElement));

            SetSiteHost(new SiteHost());

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

        /// <summary>
        /// </summary>
        /// <param name="siteHost"></param>
        public void SetSiteHost(SiteHost siteHost)
        {
            var baseContent = new DockPanel(_dockingMessageQueue, siteHost as FrameworkElement);
            var grid = new DockGrid();
            if(SiteHost == null)
            {
                SiteHost = siteHost;
            }
            grid.Append(siteHost);
            Content = grid;
        }


        /// <summary>
        /// Attach the panel to the sitehost from the specified side.
        /// </summary>
        /// <param name="panel">Instance of panel.</param>
        /// <param name="dock">The side from which it is attached.</param>
        public void AttachToSiteHost(IDockPanel panel, Dock dock)
        {
            switch(dock)
            {
                case Dock.Left:
                    this.SiteHostHorizontalAttach(panel, HorizontalAlignment.Left);
                    break;
                case Dock.Top:
                    this.SiteHostVerticalAttach(panel, VerticalAlignment.Top);
                    break;
                case Dock.Right:
                    this.SiteHostHorizontalAttach(panel, HorizontalAlignment.Right);
                    break;
                case Dock.Bottom:
                    this.SiteHostVerticalAttach(panel, VerticalAlignment.Bottom);
                    break;

            }
        }



        public void ShowDockPanelWindow(FrameworkElement DockPanelContent)
        { 
            var window = new DockPanelWindow(_panelDragGrid, DockPanelContent);
            window.Initialize(_dockingMessageQueue);
            window.Show();
        }
    }
}
