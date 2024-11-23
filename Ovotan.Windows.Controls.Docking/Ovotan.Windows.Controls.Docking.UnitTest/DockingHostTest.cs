using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows.Controls;

namespace Ovotan.Windows.Controls.Docking.UnitTest
{
    public class DockingHostTest
    {
        DockingHost _host;
        IDockPanel _firstPanel;
        IDockPanel _secondPanel;

        public DockingHostTest() 
        {
            _host = new DockingHost(null);
            _firstPanel = new DockPanel();
            _secondPanel = new DockPanel();
        }

        [StaFact]
        public void Create()
        {
            //assert
            Assert.NotNull(_host.SiteHost);
        }

        #region DockGridSignle
        [StaFact]
        public void AttachToSiteHostLeft_DockGridSignle()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            _host.AttachToSiteHost(_firstPanel, Dock.Left);

            //assert
            Assert.Same(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostRight_DockGridSignle()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            _host.AttachToSiteHost(_firstPanel, Dock.Right);

            //assert
            Assert.Same(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }

        [StaFact]
        public void AttachToSiteHostTop_DockGridSignle()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            _host.AttachToSiteHost(_firstPanel, Dock.Top);

            //assert
            Assert.Same(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostBottom_DockGridSignle()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            _host.AttachToSiteHost(_firstPanel, Dock.Bottom);

            //assert
            Assert.Same(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }
        #endregion

        #region DockGridHorizontal
        [StaFact]
        public void AttachToSiteHostLeft_DockGridHorizontal_Left()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendLeft(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Left);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[0]);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostLeft_DockGridHorizontal_Right()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendRight(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Left);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[0]);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }

        [StaFact]
        public void AttachToSiteHostRight_DockGridHorizontal_Left()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendLeft(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Right);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[2]);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostRight_DockGridHorizontal_Right()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendRight(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Right);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[2]);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }

        [StaFact]
        public void AttachToSiteHostTop_DockGridHorizontal_Left()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendLeft(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Top);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[0]);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostTop_DockGridHorizontal_Right()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendRight(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Top);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[0]);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }

        [StaFact]
        public void AttachToSiteHostBottom_DockGridHorizontal_Left()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendLeft(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Bottom);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[2]);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostBottom_DockGridHorizontal_Right()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendRight(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Bottom);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[2]);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }
        #endregion

        #region DockGridVertical
        [StaFact]
        public void AttachToSiteHostLeft_DockGridVertical_Top()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendTop(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Left);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[0]);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostLeft_DockGridVertical_Bottom()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendBottom(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Left);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[0]);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }

        [StaFact]
        public void AttachToSiteHostRight_DockGridVertical_Top()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendTop(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Right);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[2]);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostRight_DockGridVertical_Bottom()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendBottom(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Right);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[2]);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }

        [StaFact]
        public void AttachToSiteHostTop_DockGridVertical_Top()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendTop(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Top);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[0]);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostTop_DockGridVertical_Bottom()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendBottom(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Top);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[0]);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }

        [StaFact]
        public void AttachToSiteHostBottom_DockGridVertical_Top()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendTop(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Bottom);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[2]);
            Assert.Same(_firstPanel, grid.Children[0]);
            Assert.Same(siteHost, grid.Children[2]);
        }

        [StaFact]
        public void AttachToSiteHostBottom_DockGridVertical_Bottom()
        {
            //arange
            var grid = _host.DockGrid;
            var siteHost = _host.SiteHost;

            //act
            grid.AppendBottom(_firstPanel);
            _host.AttachToSiteHost(_secondPanel, Dock.Bottom);

            //assert
            var newGrid = _host.DockGrid;
            Assert.NotSame(grid, _host.DockGrid);
            Assert.Same(siteHost, _host.SiteHost);
            Assert.Same(_secondPanel, newGrid.Children[2]);
            Assert.Same(_firstPanel, grid.Children[2]);
            Assert.Same(siteHost, grid.Children[0]);
        }
        #endregion
    }
}
