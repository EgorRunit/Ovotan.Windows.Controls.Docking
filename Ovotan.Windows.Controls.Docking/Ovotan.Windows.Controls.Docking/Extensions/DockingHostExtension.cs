using Ovotan.Windows.Controls.Docking.Exceptions;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;

namespace Ovotan.Windows.Controls.Docking
{
    internal static class DockingHostExtension
    {
        public static DockGrid SiteHostHorizontalAttach(this DockingHost host, IDockPanel panel, HorizontalAlignment alignment)
        {
            if (host.SiteHost == null)
            {
                throw new DockingHostSiteHostException();
            }
            if (panel is FrameworkElement panelFrameworkElement)
            {
                var siteHostFrameworkElement = host.SiteHost as FrameworkElement;
                var panelWidth = host.ActualWidth * (25 / 100.0);
                var grid = host.DockGrid;
                if (host.DockGrid.Type != DockGridType.Single)
                {
                    var dockGrid = grid;
                    grid = new DockGrid();
                    if (panelWidth >= siteHostFrameworkElement.ActualWidth)
                    {
                        panelWidth = siteHostFrameworkElement.ActualWidth * (50 / 100.0);
                    }
                    host.Content = grid;
                    grid.Append(dockGrid);
                }
                panelFrameworkElement.Width = panelWidth;
                if (alignment == HorizontalAlignment.Left)
                {
                    grid.AppendLeft(panel);
                }
                else
                {
                    grid.AppendRight(panel);
                }
                return grid;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }

        public static DockGrid SiteHostVerticalAttach(this DockingHost host, IDockPanel panel, VerticalAlignment alignment)
        {
            if (host.SiteHost == null)
            {
                throw new DockingHostSiteHostException();
            }
            if (panel is FrameworkElement panelFrameworkElement)
            {
                var siteHostFrameworkElement = host.SiteHost as FrameworkElement;
                var panelHeight = host.ActualHeight * (25 / 100.0);
                var grid = host.DockGrid;
                if (host.DockGrid.Type != DockGridType.Single)
                {
                    var dockGrid = grid;
                    grid = new DockGrid();
                    if (panelHeight >= siteHostFrameworkElement.ActualHeight)
                    {
                        panelHeight = siteHostFrameworkElement.ActualHeight * (50 / 100.0);
                    }
                    host.Content = grid;
                    grid.Append(dockGrid);
                }
                panelFrameworkElement.Height = panelHeight;
                if (alignment == VerticalAlignment.Top)
                {
                    grid.AppendTop(panel);
                }
                else
                {
                    grid.AppendBottom(panel);
                }
                return grid;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }
    }
}
