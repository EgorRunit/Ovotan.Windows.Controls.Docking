using Ovotan.Windows.Controls.Docking;
using Ovotan.Windows.Controls.Docking.Exceptions;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows.Controls;

namespace Ovotan.Windows.Controls.Docking.UnitTest
{
    public class DockGridTest
    {
        IDockGrid _dockGrid;
        IDockGridChild _firstPanel;
        IDockGridChild _secondPanel;

        public DockGridTest()
        {
            _dockGrid = new DockGrid();
            _firstPanel = new DockPanel();
            _secondPanel = new DockPanel();
        }

        [StaFact]
        public void Create()
        {
            //assert
            Assert.Equal(DockGridType.Empty, _dockGrid.Type);
            Assert.Empty(_dockGrid.RowDefinitions);
        }

        #region Append
        [StaFact]
        public void Append()
        {
            //act
            _dockGrid.Append(_firstPanel);

            //assert
            Assert.Equal(DockGridType.Single, _dockGrid.Type);
            Assert.Single(_dockGrid.RowDefinitions);
            Assert.Single(_dockGrid.ColumnDefinitions);
            Assert.Single(_dockGrid.Children);
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.ColumnProperty));
        }

        [StaFact]
        public void AppendTwiceAppendException()
        {
            //arrange
            var secondPanel = new DockPanel();

            //act
            _dockGrid.Append(_firstPanel);

            //assert
            Assert.Throws<TwiceAppendException>(() => _dockGrid.Append(secondPanel));
        }

        [StaFact]
        public void AppendNotFrameworkElement()
        {
            //assert
            Assert.Throws<NotFrameworkElement>(() => _dockGrid.Append(new Mocks.DockPanel()));
        }
        #endregion

        #region AppendLeft
        [StaFact]
        public void AppendLeft()
        {
            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendLeft(_secondPanel);

            //assert
            Assert.Equal(DockGridType.Horizontal, _dockGrid.Type);
            Assert.Single(_dockGrid.RowDefinitions);
            Assert.Equal(3, _dockGrid.Children.Count);
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.ColumnProperty));
            Assert.Equal(0, _dockGrid.Children[1].GetValue(Grid.RowProperty));
            Assert.Equal(1, _dockGrid.Children[1].GetValue(Grid.ColumnProperty));
            Assert.Equal(0, _dockGrid.Children[2].GetValue(Grid.RowProperty));
            Assert.Equal(2, _dockGrid.Children[2].GetValue(Grid.ColumnProperty));
            Assert.Same(_secondPanel, _dockGrid.Children[0]);
            Assert.Same(_firstPanel, _dockGrid.Children[2]);
            Assert.IsType<GridSplitter>(_dockGrid.Children[1]);
            Assert.Equal(GridResizeDirection.Columns, (_dockGrid.Children[1] as GridSplitter).ResizeDirection);
            Assert.True(_dockGrid.ColumnDefinitions[1].Width.IsAuto);
        }

        [StaFact]
        public void AppendLeftEmptyException()
        {
            //assert
            Assert.Throws<DockGridEmptyException>(() => _dockGrid.AppendLeft(_firstPanel));
        }

        [StaFact]
        public void AppendLeftGridFullException()
        {
            //arrange
            var secondPanel = new DockPanel();

            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendLeft(secondPanel);

            //assert
            Assert.Throws<DockGridFullException>(() => _dockGrid.AppendLeft(secondPanel));
        }

        [StaFact]
        public void AppendLeftNotFrameworkElement()
        {
            //act
            _dockGrid.Append(_firstPanel);

            //assert
            Assert.Throws<NotFrameworkElement>(() => _dockGrid.AppendLeft(new Mocks.DockPanel()));
        }
        #endregion

        #region AppendRight
        [StaFact]
        public void AppendRight()
        {
            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendRight(_secondPanel);

            //assert
            Assert.Equal(DockGridType.Horizontal, _dockGrid.Type);
            Assert.Single(_dockGrid.RowDefinitions);
            Assert.Equal(3, _dockGrid.Children.Count);
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.ColumnProperty));
            Assert.Equal(0, _dockGrid.Children[1].GetValue(Grid.RowProperty));
            Assert.Equal(1, _dockGrid.Children[1].GetValue(Grid.ColumnProperty));
            Assert.Equal(0, _dockGrid.Children[2].GetValue(Grid.RowProperty));
            Assert.Equal(2, _dockGrid.Children[2].GetValue(Grid.ColumnProperty));
            Assert.Same(_firstPanel, _dockGrid.Children[0]);
            Assert.Same(_secondPanel, _dockGrid.Children[2]);
            Assert.IsType<GridSplitter>(_dockGrid.Children[1]);
            Assert.Equal(GridResizeDirection.Columns, (_dockGrid.Children[1] as GridSplitter).ResizeDirection);
            Assert.True(_dockGrid.ColumnDefinitions[1].Width.IsAuto);
        }

        [StaFact]
        public void AppendRightEmptyException()
        {
            //assert
            Assert.Throws<DockGridEmptyException>(() => _dockGrid.AppendRight(_firstPanel));
        }

        [StaFact]
        public void AppendRightGridFullException()
        {
            //arrange
            var secondPanel = new DockPanel();

            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendRight(secondPanel);

            //assert
            Assert.Throws<DockGridFullException>(() => _dockGrid.AppendRight(secondPanel));
        }

        [StaFact]
        public void AppendRightNotFrameworkElement()
        {
            //act
            _dockGrid.Append(_firstPanel);

            //assert
            Assert.Throws<NotFrameworkElement>(() => _dockGrid.AppendRight(new Mocks.DockPanel()));
        }
        #endregion

        #region AppendTop
        [StaFact]
        public void AppendTop()
        {
            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendTop(_secondPanel);

            //assert
            Assert.Equal(DockGridType.Vertical, _dockGrid.Type);
            Assert.Single(_dockGrid.ColumnDefinitions);
            Assert.Equal(3, _dockGrid.RowDefinitions.Count);

            Assert.Equal(3, _dockGrid.Children.Count);
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.ColumnProperty));
            Assert.Equal(1, _dockGrid.Children[1].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[1].GetValue(Grid.ColumnProperty));
            Assert.Equal(2, _dockGrid.Children[2].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[2].GetValue(Grid.ColumnProperty));
            Assert.Same(_firstPanel, _dockGrid.Children[2]);
            Assert.Same(_secondPanel, _dockGrid.Children[0]);
            Assert.IsType<GridSplitter>(_dockGrid.Children[1]);
            Assert.Equal(GridResizeDirection.Rows, (_dockGrid.Children[1] as GridSplitter).ResizeDirection);
            Assert.True(_dockGrid.RowDefinitions[1].Height.IsAuto);
        }

        [StaFact]
        public void AppendTopEmptyException()
        {
            //assert
            Assert.Throws<DockGridEmptyException>(() => _dockGrid.AppendTop(_firstPanel));
        }

        [StaFact]
        public void AppendTopGridFullException()
        {
            //arrange
            var secondPanel = new DockPanel();

            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendTop(secondPanel);

            //assert
            Assert.Throws<DockGridFullException>(() => _dockGrid.AppendTop(secondPanel));
        }

        [StaFact]
        public void AppendTopNotFrameworkElement()
        {
            //act
            _dockGrid.Append(_firstPanel);

            //assert
            Assert.Throws<NotFrameworkElement>(() => _dockGrid.AppendTop(new Mocks.DockPanel()));
        }
        #endregion

        #region AppendBottom
        [StaFact]
        public void AppendBottom()
        {
            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendBottom(_secondPanel);

            //assert
            Assert.Equal(DockGridType.Vertical, _dockGrid.Type);
            Assert.Single(_dockGrid.ColumnDefinitions);
            Assert.Equal(3, _dockGrid.RowDefinitions.Count);
            Assert.Equal(3, _dockGrid.Children.Count);
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.ColumnProperty));
            Assert.Equal(1, _dockGrid.Children[1].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[1].GetValue(Grid.ColumnProperty));
            Assert.Equal(2, _dockGrid.Children[2].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[2].GetValue(Grid.ColumnProperty));
            Assert.Same(_firstPanel, _dockGrid.Children[0]);
            Assert.Same(_secondPanel, _dockGrid.Children[2]);
            Assert.IsType<GridSplitter>(_dockGrid.Children[1]);
            Assert.Equal(GridResizeDirection.Rows, (_dockGrid.Children[1] as GridSplitter).ResizeDirection);
            Assert.True(_dockGrid.RowDefinitions[1].Height.IsAuto);
        }

        [StaFact]
        public void AppendBottomEmptyException()
        {
            //assert
            Assert.Throws<DockGridEmptyException>(() => _dockGrid.AppendBottom(_firstPanel));
        }

        [StaFact]
        public void AppendBottomGridFullException()
        {
            //arrange
            var secondPanel = new DockPanel();

            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendBottom(secondPanel);

            //assert
            Assert.Throws<DockGridFullException>(() => _dockGrid.AppendBottom(secondPanel));
        }

        [StaFact]
        public void AppendBottomNotFrameworkElement()
        {
            //act
            _dockGrid.Append(_firstPanel);

            //assert
            Assert.Throws<NotFrameworkElement>(() => _dockGrid.AppendBottom(new Mocks.DockPanel()));
        }
        #endregion

        #region Transform
        [StaFact]
        public void TransformToDockGrid()
        {
            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendRight(_secondPanel);
            var grid1 = _dockGrid.TransformToDataGrid(_firstPanel);
            var grid2 = _dockGrid.TransformToDataGrid(_secondPanel);

            //assert
            Assert.NotNull(grid1);
            Assert.Equal(DockGridType.Single, grid1.Type);
            Assert.Equal(grid1, _dockGrid.Children[0]);
            Assert.NotNull(grid2);
            Assert.Equal(DockGridType.Single, grid2.Type);
            Assert.Equal(grid2, _dockGrid.Children[2]);
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.ColumnProperty));
            Assert.Equal(0, _dockGrid.Children[2].GetValue(Grid.RowProperty));
            Assert.Equal(2, _dockGrid.Children[2].GetValue(Grid.ColumnProperty));
            Assert.Equal(0, grid1.GetValue(Grid.RowProperty));
            Assert.Equal(0, grid1.GetValue(Grid.ColumnProperty));
            Assert.Equal(0, grid2.GetValue(Grid.RowProperty));
            Assert.Equal(2, grid2.GetValue(Grid.ColumnProperty));
            Assert.Equal(grid1, _dockGrid.Children[0]);
            Assert.Equal(grid2, _dockGrid.Children[2]);
        }

        [StaFact]
        public void TransformToDockGridItemNotFoundException()
        {
            //assert
            Assert.Throws<ItemNotFoundException>(() => _dockGrid.TransformToDataGrid(_firstPanel));
        }

        [StaFact]
        public void TransformToDockGridNotFrameworkElement()
        {
            //assert
            Assert.Throws<NotFrameworkElement>(() => _dockGrid.TransformToDataGrid(new Mocks.DockPanel()));
        }
        #endregion




        [StaFact]
        public void RemoveSingle()
        {
            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.Remove(_firstPanel);

            //assert
            Assert.Empty(_dockGrid.Children);
            Assert.Equal(DockGridType.Empty, _dockGrid.Type);
            Assert.Empty(_dockGrid.RowDefinitions);
            Assert.Empty(_dockGrid.ColumnDefinitions);
        }

        [StaFact]
        public void RemoveHorizontal()
        {
            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendRight(_secondPanel);
            _dockGrid.Remove(_secondPanel);

            //assert
            Assert.Single(_dockGrid.Children);
            Assert.Equal(DockGridType.Single, _dockGrid.Type);
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.ColumnProperty));
            Assert.Single(_dockGrid.RowDefinitions);
            Assert.Single(_dockGrid.ColumnDefinitions);
            Assert.Same(_firstPanel, _dockGrid.Children[0]);
        }

        [StaFact]
        public void RemoveVertical()
        {
            //act
            _dockGrid.Append(_firstPanel);
            _dockGrid.AppendBottom(_secondPanel);
            _dockGrid.Remove(_secondPanel);

            //assert
            Assert.Single(_dockGrid.Children);
            Assert.Equal(DockGridType.Single, _dockGrid.Type);
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.RowProperty));
            Assert.Equal(0, _dockGrid.Children[0].GetValue(Grid.ColumnProperty));
            Assert.Single(_dockGrid.RowDefinitions);
            Assert.Single(_dockGrid.ColumnDefinitions);
            Assert.Same(_firstPanel, _dockGrid.Children[0]);
        }

        [StaFact]
        public void RemoveNotFoundException()
        {
            //assert
            Assert.Throws<ItemNotFoundException>(() => _dockGrid.Remove(_secondPanel));
        }

        [StaFact]
        public void RemoveNotFrameworkElement()
        {
            //assert
            Assert.Throws<NotFrameworkElement>(() => _dockGrid.Remove(new Mocks.DockPanel()));
        }
    }
}