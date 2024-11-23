using Ovotan.Windows.Controls.Docking.Exceptions;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Diagnostics;
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
        UIElementCollection Children { get; }
        RowDefinitionCollection RowDefinitions { get; }
        ColumnDefinitionCollection ColumnDefinitions { get; }

        void Append(IDockGridChild child);
        void AppendRight(IDockGridChild child);
        void AppendBottom(IDockGridChild child);
        void AppendLeft(IDockGridChild child);
        void AppendTop(IDockGridChild child);
        void Remove(IDockGridChild child);
        DockGrid TransformToDataGrid(IDockGridChild child);
    }

    /// <summary>
    /// Enum  of types  dockgrid.
    /// </summary>
    public enum DockGridType
    {
        /// <summary>
        /// DockGrid does not contains any child.
        /// </summary>
        Empty,
        /// <summary>
        /// DockGrid contains single  child.
        /// </summary>
        Single,
        /// <summary>
        /// The DockGrid contains two vertical child elements.
        /// </summary>
        Vertical,
        /// <summary>
        /// The DockGrid contains two horizontal child elements.
        /// </summary>
        Horizontal
    }

    public class DockGrid : ContentControl, IDockGrid
    {
        Grid _mainGrid;

        public static int NewPanelHeightWidthPercent = 30;

        public UIElementCollection Children => _mainGrid.Children;

        public RowDefinitionCollection RowDefinitions => _mainGrid.RowDefinitions;

        public ColumnDefinitionCollection ColumnDefinitions => _mainGrid.ColumnDefinitions;

        /// <summary>
        /// Get - Type of DockPanel
        /// </summary>
        public DockGridType Type { get; private set; }

        static DockGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockGrid), new FrameworkPropertyMetadata(typeof(DockGrid)));
        }

        Guid _id;
        public DockGrid()
        {
            _id = Guid.NewGuid();
            _mainGrid = new Grid();
            Content = _mainGrid;
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        /// <summary>
        /// Append a child.
        /// </summary>
        /// <param name="child">Instance of DockGridChild.</param>
        /// <exception cref="TwiceAppendException">Occurs when call append twice.</exception>
        /// <exception cref="NotFrameworkElement">Occurs when the panel is not an element of the framework.</exception>
        public void Append(IDockGridChild child)
        {
            if(_mainGrid.Children.Count > 0)
            {
                throw new TwiceAppendException();
            }
            if(child is FrameworkElement frameworkElement)
            {
                if (child is IDockPanel panel)
                {
                    panel.Close += _onPanelClose;
                }
                frameworkElement.SetValue(Grid.RowProperty, 0);
                frameworkElement.SetValue(Grid.ColumnProperty, 0);
                _mainGrid.Children.Add(frameworkElement);
                _mainGrid.RowDefinitions.Add(new RowDefinition());
                _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                Type = DockGridType.Single;
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
            if (_mainGrid.Children.Count == 0)
            {
                throw new DockGridEmptyException();
            }
            if (_mainGrid.Children.Count == 3)
            {
                throw new DockGridFullException();
            }
            if (child is FrameworkElement frameworkElement)
            {
                if(child is IDockPanel panel)
                {
                    panel.Close += _onPanelClose;
                }

                var splitter = new GridSplitter()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    ResizeDirection = GridResizeDirection.Columns
                };
                _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                frameworkElement.SetValue(Grid.ColumnProperty, 0);
                splitter.SetValue(Grid.ColumnProperty, 1);
                splitter.SetValue(HeightProperty, HeightProperty.DefaultMetadata.DefaultValue);
                _mainGrid.Children[0].SetValue(Grid.ColumnProperty, 2);
                _mainGrid.Children.Insert(0,frameworkElement);
                _mainGrid.Children.Insert(1, splitter);
                _lastAppendChild = frameworkElement;
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
            if (_mainGrid.Children.Count == 0)
            {
                throw new DockGridEmptyException();
            }
            if (_mainGrid.Children.Count == 3)
            {
                throw new DockGridFullException();
            }
            if (child is FrameworkElement frameworkElement)
            {
                if (child is IDockPanel panel)
                {
                    panel.Close += _onPanelClose;
                }
                var splitter = new GridSplitter()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    ResizeDirection = GridResizeDirection.Columns
                };
                _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                frameworkElement.SetValue(Grid.ColumnProperty, 2);
                splitter.SetValue(HeightProperty, HeightProperty.DefaultMetadata.DefaultValue);
                splitter.SetValue(Grid.ColumnProperty, 1);
                _mainGrid.Children.Add(splitter);
                _mainGrid.Children.Add(frameworkElement);
                _lastAppendChild = frameworkElement;
                Type = DockGridType.Horizontal;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }
        FrameworkElement _lastAppendChild = null;
        protected override Size MeasureOverride(Size constraint)
        {
            if (_lastAppendChild != null)
            {
                Background = new SolidColorBrush(Colors.Red);
                if (Type == DockGridType.Horizontal)
                {
                    var childIndex = (int)_lastAppendChild.GetValue(Grid.ColumnProperty);
                    var contentIndex = childIndex == 2 ? 0 : 2;
                    _mainGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Auto);
                    _mainGrid.ColumnDefinitions[childIndex].Width = new GridLength(_lastAppendChild.Width, GridUnitType.Pixel);
                    _mainGrid.ColumnDefinitions[contentIndex].Width = new GridLength(100, GridUnitType.Star);
                    _lastAppendChild.ClearValue(WidthProperty);
                }
                else
                {
                    var rowIndex = (int)_lastAppendChild.GetValue(Grid.RowProperty);
                    var contentIndex = rowIndex == 2 ? 0 : 2;
                    _mainGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Auto);
                    _mainGrid.RowDefinitions[rowIndex].Height = new GridLength(_lastAppendChild.Height, GridUnitType.Pixel);
                    _mainGrid.RowDefinitions[contentIndex].Height = new GridLength(100, GridUnitType.Star);
                    _lastAppendChild.ClearValue(HeightProperty);
                }
                _lastAppendChild.HorizontalAlignment = HorizontalAlignment.Stretch;
                _lastAppendChild.VerticalAlignment = VerticalAlignment.Stretch;
                _lastAppendChild = null;
            }
            return base.MeasureOverride(constraint);
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
            if (_mainGrid.Children.Count == 0)
            {
                throw new DockGridEmptyException();
            }
            if (_mainGrid.Children.Count == 3)
            {
                throw new DockGridFullException();
            }
            if (child is FrameworkElement frameworkElement)
            {
                if (child is IDockPanel panel)
                {
                    panel.Close += _onPanelClose;
                }
                var splitter = new GridSplitter()
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Center,
                    ResizeDirection = GridResizeDirection.Rows

                };
                frameworkElement.SetValue(Grid.RowProperty, 0);
                splitter.SetValue(WidthProperty, WidthProperty.DefaultMetadata.DefaultValue);
                splitter.SetValue(Grid.RowProperty, 1);
                _mainGrid.Children[0].SetValue(Grid.RowProperty, 2);
                _mainGrid.RowDefinitions.Add(new RowDefinition());
                _mainGrid.RowDefinitions.Add(new RowDefinition());
                _mainGrid.Children.Insert(0, frameworkElement);
                _mainGrid.Children.Insert(1, splitter);
                _lastAppendChild = frameworkElement;
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
            if (_mainGrid.Children.Count == 0)
            {
                throw new DockGridEmptyException();
            }
            if (_mainGrid.Children.Count == 3)
            {
                throw new DockGridFullException();
            }
            if (child is FrameworkElement frameworkElement)
            {
                if (child is IDockPanel panel)
                {
                    panel.Close += _onPanelClose;
                }
                var splitter = new GridSplitter()
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Center,
                    ResizeDirection = GridResizeDirection.Rows

                };
                splitter.SetValue(WidthProperty, WidthProperty.DefaultMetadata.DefaultValue);
                _mainGrid.RowDefinitions.Add(new RowDefinition());
                _mainGrid.RowDefinitions.Add(new RowDefinition());
                splitter.SetValue(Grid.RowProperty, 1);
                frameworkElement.SetValue(Grid.RowProperty, 2);
                _mainGrid.Children.Add(splitter);
                _mainGrid.Children.Add(frameworkElement);
                _lastAppendChild = frameworkElement;
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
            throw new Exception("");
            if (child is FrameworkElement frameworkElement)
            {
                var childIndex = _mainGrid.Children.IndexOf(frameworkElement);
                if(childIndex == -1)
                {
                    throw new ItemNotFoundException();
                }
                var grid = new DockGrid();
                grid.SetValue(Grid.RowProperty, frameworkElement.GetValue(Grid.RowProperty));
                grid.SetValue(Grid.ColumnProperty, frameworkElement.GetValue(Grid.ColumnProperty));
                //grid.SetValue(HeightProperty, frameworkElement.GetValue(HeightProperty));
                //grid.SetValue(WidthProperty, frameworkElement.GetValue(WidthProperty));
                Debug.WriteLine("transform id " + grid._id);
                _mainGrid.Children.Remove(frameworkElement);
                _mainGrid.Children.Insert(childIndex, grid);
                grid.Append(child);
                return grid;
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }

        public void Remove(IDockGridChild child)
        {
            if (child is FrameworkElement frameworkElement)
            {
                var childIndex = Children.IndexOf(frameworkElement);
                if (childIndex == -1)
                {
                    throw new ItemNotFoundException();
                }
                if (Children.Count == 3)
                {
                    _mainGrid.Children.RemoveAt(1);
                    _mainGrid.Children.Remove(frameworkElement);
                    if (Type == DockGridType.Horizontal)
                    {
                        _mainGrid.ColumnDefinitions.RemoveRange(1, 2);
                        _mainGrid.ColumnDefinitions[0].Width = new GridLength(100, GridUnitType.Star);
                    }
                    else
                    {
                        _mainGrid.RowDefinitions.RemoveRange(1, 2);
                        _mainGrid.RowDefinitions[0].Height = new GridLength(100, GridUnitType.Star);
                    }
                    Type = DockGridType.Single;
                    var lastChild = _mainGrid.Children[0];
                    lastChild.SetValue(Grid.RowProperty, 0);
                    lastChild.SetValue(Grid.ColumnProperty, 0);
                    lastChild.ClearValue(WidthProperty);
                    lastChild.ClearValue(HeightProperty);
                }
                else
                {
                    _mainGrid.RowDefinitions.Clear();
                    _mainGrid.ColumnDefinitions.Clear();
                    _mainGrid.Children.Clear();
                    Type = DockGridType.Empty;
                }
                if(child is IDockPanel panel)
                {
                    panel.Close -= _onPanelClose;
                }
            }
            else
            {
                throw new NotFrameworkElement();
            }
        }

        private void _onPanelClose(object sender, RoutedEventArgs e)
        {
            if(e.Source is IDockPanel panel)
            {
                Remove(panel);
            }
            else
            {
                throw new NotDockPanelException();
            }
        }


        public override string ToString()
        {
            return $"Type={Type}";
        }
    }
}
