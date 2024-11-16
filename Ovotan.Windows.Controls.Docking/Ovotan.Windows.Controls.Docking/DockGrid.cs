using Ovotan.Windows.Controls.Docking.Exceptions;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ovotan.Windows.Controls.Docking
{
    public interface IDockGridChild
    {
    }
    public interface IDockGrid : IDockGridChild
    {
        DockGridType Type { get; }
        RowDefinitionCollection RowDefinitions { get; }
        ColumnDefinitionCollection ColumnDefinitions { get; }
        UIElementCollection Children { get; }

        void Append(IDockGridChild child);
        void AppendRight(IDockGridChild child);
        void AppendBottom(IDockGridChild child);
        void AppendLeft(IDockGridChild child);
        void AppendTop(IDockGridChild child);
        DockGrid TransformToDataGrid(IDockGridChild child);
    }

    public enum DockGridType
    {
        Single,
        Vertical,
        Horizontal
    }

    public class DockGrid : Grid, IDockGrid
    {
        /// <summary>
        /// Get - Type of DockPanel
        /// </summary>
        public DockGridType Type { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DockGrid()
        {
        }

        /// <summary>
        /// Append a child.
        /// </summary>
        /// <param name="child">Instance of DockGridChild.</param>
        /// <exception cref="TwiceAppendException">Occurs when call append twice.</exception>
        /// <exception cref="NotFrameworkElement">Occurs when the panel is not an element of the framework.</exception>
        public void Append(IDockGridChild child)
        {
            if(Children.Count > 0)
            {
                throw new TwiceAppendException();
            }

            if(child is FrameworkElement frameworkElement)
            {
                SetRow(frameworkElement, 0);
                SetColumn(frameworkElement, 0);
                Children.Add(frameworkElement);
                RowDefinitions.Add(new RowDefinition());
                ColumnDefinitions.Add(new ColumnDefinition());
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }

        /// <summary>
        /// Append a child to the left side.
        /// </summary>
        /// <param name="child">Instance of DockGridChild.</param>
        /// <exception cref="DockGridEmptyException">Occurs when DockGrid have not children.</exception>
        /// <exception cref="DockGridFullException">Occurs when DockGrid full children.</exception>
        /// <exception cref="NotFrameworkElement">Occurs when the panel is not an element of the framework.</exception>
        public void AppendLeft(IDockGridChild child)
        {
            if (Children.Count == 0)
            {
                throw new DockGridEmptyException();
            }
            if (Children.Count == 3)
            {
                throw new DockGridFullException();
            }
            if (child is FrameworkElement frameworkElement)
            {
                var splitter = new GridSplitter()
                {
                    Width = 5,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    ResizeDirection = GridResizeDirection.Columns
                };
                ColumnDefinitions.Add(new ColumnDefinition(){ Width = new GridLength(0, GridUnitType.Auto) });
                ColumnDefinitions.Add(new ColumnDefinition());
                SetColumn(frameworkElement, 0);
                SetColumn(splitter, 1);
                SetColumn(Children[0], 2);
                Children.Insert(0,frameworkElement);
                Children.Insert(1, splitter);
                Type = DockGridType.Horizontal;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }

        /// <summary>
        /// Append a child to the right side.
        /// </summary>
        /// <param name="child">Instance of DockGridChild.</param>
        /// <exception cref="DockGridEmptyException">Occurs when DockGrid have not children.</exception>
        /// <exception cref="DockGridFullException">Occurs when DockGrid full children.</exception>
        /// <exception cref="NotFrameworkElement">Occurs when the panel is not an element of the framework.</exception>
        public void AppendRight(IDockGridChild child)
        {
            if (Children.Count == 0)
            {
                throw new DockGridEmptyException();
            }
            if (Children.Count == 3)
            {
                throw new DockGridFullException();
            }
            if (child is FrameworkElement frameworkElement)
            {
                var splitter = new GridSplitter()
                {
                    Width = 5,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    ResizeDirection = GridResizeDirection.Columns
                };
                ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0, GridUnitType.Auto) });
                ColumnDefinitions.Add(new ColumnDefinition());
                SetColumn(splitter, 1);
                SetColumn(frameworkElement, 2);
                Children.Add(splitter);
                Children.Add(frameworkElement);
                Type = DockGridType.Horizontal;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }

        /// <summary>
        /// Append a child to the top side.
        /// </summary>
        /// <param name="panel">Instance of panel.</param>
        /// <exception cref="DockGridEmptyException">Occurs when DockGrid have not children.</exception>
        /// <exception cref="DockGridFullException">Occurs when DockGrid full children.</exception>
        /// <exception cref="NotFrameworkElement">Occurs when the panel is not an element of the framework.</exception>
        public void AppendTop(IDockGridChild child)
        {
            if (Children.Count == 0)
            {
                throw new DockGridEmptyException();
            }
            if (Children.Count == 3)
            {
                throw new DockGridFullException();
            }
            if (child is FrameworkElement frameworkElement)
            {
                var splitter = new GridSplitter()
                {
                    Height = 5,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Center,
                    ResizeDirection = GridResizeDirection.Rows

                };
                SetRow(frameworkElement, 0);
                SetRow(splitter, 1);
                SetRow(Children[0], 2);
                RowDefinitions.Add(new RowDefinition() {  Height = new GridLength(0, GridUnitType.Auto) });
                RowDefinitions.Add(new RowDefinition());
                Children.Insert(0, frameworkElement);
                Children.Insert(1, splitter);
                Type = DockGridType.Vertical;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }

        /// <summary>
        /// Append a child to the bottom side.
        /// </summary>
        /// <param name="child">Instance of DockGridChild.</param>
        /// <exception cref="DockGridEmptyException">Occurs when DockGrid have not children.</exception>
        /// <exception cref="DockGridFullException">Occurs when DockGrid full children.</exception>
        /// <exception cref="NotFrameworkElement">Occurs when the panel is not an element of the framework.</exception>
        public void AppendBottom(IDockGridChild child)
        {
            if (Children.Count == 0)
            {
                throw new DockGridEmptyException();
            }
            if (Children.Count == 3)
            {
                throw new DockGridFullException();
            }
            if (child is FrameworkElement frameworkElement)
            {
                var splitter = new GridSplitter()
                {
                    Height = 5,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Center,
                    ResizeDirection = GridResizeDirection.Rows

                };
                RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
                RowDefinitions.Add(new RowDefinition());
                SetRow(splitter, 1);
                SetRow(frameworkElement, 2);
                Children.Add(splitter);
                Children.Add(frameworkElement);
                Type = DockGridType.Vertical;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }

        /// <summary>
        /// Transform DockGridChild to DockGrid.
        /// </summary>
        /// <param name="child">Instance of DockGridChild.</param>
        /// <returns>DockGrid with instance oanel.</returns>
        /// <exception cref="ItemNotFoundException">Occurs when the panel is not found in the child elements.</exception>
        /// <exception cref="NotFrameworkElement">Occurs when the panel is not an element of the framework.</exception>
        public DockGrid TransformToDataGrid(IDockGridChild child)
        {
            if (child is FrameworkElement frameworkElement)
            {
                var childIndex = Children.IndexOf(frameworkElement);
                if(childIndex == -1)
                {
                    throw new ItemNotFoundException();
                }
                Children.Remove(frameworkElement);
                var grid = new DockGrid();
                grid.Append(child);
                SetRow(grid, GetRow(frameworkElement));
                SetColumn(grid, GetColumn(frameworkElement));
                Children.Insert(childIndex, grid);
                return grid;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }
    }
}
