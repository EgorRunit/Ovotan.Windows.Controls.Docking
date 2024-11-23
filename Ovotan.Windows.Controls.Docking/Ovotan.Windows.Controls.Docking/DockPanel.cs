using Ovotan.Windows.Controls.Controls;
using Ovotan.Windows.Controls.Docking.Enums;
using Ovotan.Windows.Controls.Docking.Interfaces;
using System.Windows;
using System.Windows.Controls;

namespace Ovotan.Windows.Controls.Docking
{
    public class DockPanel : ContentControl, IDockPanel
    {
        public static DependencyProperty IsPanelFocusedProperty;
        public static readonly RoutedEvent CloseEvent;

        Grid _panelGrid;

        public event RoutedEventHandler Close
        {
            add { AddHandler(CloseEvent, value); }
            remove { RemoveHandler(CloseEvent, value); }
        }

        public virtual void OnClose()
        {
            RaiseEvent(new RoutedEventArgs(routedEvent: CloseEvent));
        }


        public bool IsPanelFocused
        {
            get
            {
                return (bool)GetValue(IsPanelFocusedProperty);
            }
            set
            {
                //Нужно сделать передачу фокуса в содержимое
                if(DockPanelContent is IDockPanelContent)
                {
                    (DockPanelContent as IDockPanelContent).ContentFocus();
                }
                SetValue(IsPanelFocusedProperty, value);
            }
        }


        //Экземпляр вставляемого содержимого панели.
        public FrameworkElement DockPanelContent;
        public string Header { get; set; }

        static DockPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockPanel), new FrameworkPropertyMetadata(typeof(DockPanel)));
         
            IsPanelFocusedProperty = DependencyProperty.Register("IsPanelFocused", typeof(bool), typeof(DockPanel),
                new PropertyMetadata(false));
            // регистрация маршрутизированного события
            CloseEvent = EventManager.RegisterRoutedEvent("OnClose", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DockPanel));
        }

        public DockPanel()
        {

        }


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var header = Template.FindName("Header", this) as Grid;
            var closeButton = Template.FindName("CloseButton", this) as ViewboxIcon;
            _panelGrid = Template.FindName("Panel", this) as Grid;
            closeButton.Command = new ButtonCommand<object>(_ => OnClose());

            if (!(DockPanelContent is ISiteHost))
            {
                if (DockPanelContent != null)
                {
                    DockPanelContent.SetValue(Grid.RowProperty, 1);
                    _panelGrid.Children.Add(DockPanelContent);
                }
            }
            else
            {
                DockPanelContent.SetValue(Grid.RowProperty, 0);
                _panelGrid.RowDefinitions.Clear();
                _panelGrid.Children.Clear();
                _panelGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100.0, GridUnitType.Star) });
                _panelGrid.Children.Add(DockPanelContent);
            }

        }
        /// <summary>
        /// Интерфейс должен быть
        /// </summary>
        /// <param name="dockPanelContent"></param>
        internal DockPanel(FrameworkElement dockPanelContent)
        {
            Header = "Object browser";
            DockPanelContent = dockPanelContent;
        }
    }
}

