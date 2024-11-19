using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Ovotan.Windows.Controls.Docking.Windows
{
    public class DockGridWindow : Window
    {
        bool _isMouseCaptured;
        FrameworkElement _owner;
        FrameworkElement _draggindElement;
        Action<MouseEventArgs> _mouseMoveCallback;
        List<OwnerRect> _dockPlaces;
        Type _dockPlaceType;
        Point _selfLoaction;
        OwnerRect _previouslyUnderMouseElement;
        Canvas _centralArrow;
        Grid _mainGrid;

        static DockGridWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockGridWindow), new FrameworkPropertyMetadata(typeof(Popup)));
            //SchemaManager.AddResource("pack://application:,,,/Ovotan.Windows.Controls.Docking;component/Resources/DockGridResource.xaml");
        }

        public DockGridWindow(FrameworkElement owner)
        {
            _owner = owner;
            MouseUp += _mouseUp;
            MouseMove += _mouseMove;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
            Visibility = Visibility.Collapsed;
            Application.Current.MainWindow.Closing += (s, a) => Close();
        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _centralArrow = Template.FindName("CentralArrow", this) as Canvas;
            _mainGrid = Template.FindName("MainGrid", this) as Grid;
        }

        public void Show<T>(FrameworkElement dockElement, Action<MouseEventArgs> mouseMoveCallback) where T : class
        {
            var foundPlaces = _owner.FindLogicalChildren<T>();
            _dockPlaces = new List<OwnerRect>(foundPlaces.Count());
            _selfLoaction = _owner.PointToScreen(new Point());

            foreach (var element in foundPlaces)
            {
                var frameworkElement = element as FrameworkElement;
                var startPoint = (element as FrameworkElement).PointToScreen(new Point());
                _dockPlaces.Add(new OwnerRect(frameworkElement, startPoint.X, startPoint.Y, startPoint.X + frameworkElement.ActualWidth, startPoint.Y + frameworkElement.ActualHeight));
            }
            //добавить хост в качестве последнего места

            _previouslyUnderMouseElement = null;
            _draggindElement = dockElement;
            _isMouseCaptured = true;
            _mouseMoveCallback = mouseMoveCallback;

            Top = _selfLoaction.Y;
            Left = _selfLoaction.X;
            Height = _owner.ActualHeight;
            Width = _owner.ActualWidth;
            Show();
            Mouse.Capture(this, CaptureMode.SubTree);
        }

        void _mouseMove(object sender, MouseEventArgs e)
        {
            if (!Application.Current.MainWindow.IsActive)
            {
                Application.Current.MainWindow.Activate();
            }

            if (_isMouseCaptured)
            {
                Point mousePosition = e.GetPosition(this);
                var x = mousePosition.X + _selfLoaction.X;
                var y = mousePosition.Y + _selfLoaction.Y;
                var foundDockPlace = _dockPlaces.FindElementFromPoint(new Point(x, y));
                if (foundDockPlace != null)
                {
                    if (foundDockPlace != _previouslyUnderMouseElement)
                    {
                        Point relativeLocation = foundDockPlace.Owner.TranslatePoint(new Point(0, 0), this);
                        var top = (foundDockPlace.Owner.ActualHeight - _centralArrow.ActualHeight) / 2 + relativeLocation.Y;
                        var left = (foundDockPlace.Owner.ActualWidth - _centralArrow.ActualWidth) / 2 + relativeLocation.X;
                        _centralArrow.SetValue(Canvas.TopProperty, top);
                        _centralArrow.SetValue(Canvas.LeftProperty, left);
                        _previouslyUnderMouseElement = foundDockPlace;
                    }
                    if (_mainGrid.Visibility != Visibility.Visible)
                    {
                        _mainGrid.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    _mainGrid.Visibility = Visibility.Hidden;
                }
                _mouseMoveCallback(e);
            }
        }

        void _mouseUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseCaptured = false;
            _previouslyUnderMouseElement = null;
            Hide();
            ReleaseMouseCapture();
        }
    }

}
