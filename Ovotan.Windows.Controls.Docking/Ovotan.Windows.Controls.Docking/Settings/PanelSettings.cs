using System.Windows.Media;
using System.Windows;

namespace Ovotan.Windows.Controls.Docking.Settings
{
    /// <summary>
    /// /Класс настроек для цветовой схемы элемента управления DockPanel.
    /// </summary>
    public class PanelSettings : DependencyObject
    {
        /// <summary>
        /// Зависимое свойство. Цвет фона заголовка панели.
        /// </summary>
        public static readonly DependencyProperty HeaderBackgroundProperty;
        /// <summary>
        /// Зависимое свойство. Цвет текста заголовка панели.
        /// </summary>
        public static readonly DependencyProperty HeaderForegroundProperty;
        /// <summary>
        /// Зависимое свойство. Цвет фона заголовка панели, кагда она становиться активной.
        /// </summary>
        public static readonly DependencyProperty HeaderActiveBackgroundProperty;
        /// <summary>
        /// Зависимое свойство. Цвет текста заголовка панели, кагда она становиться активной.
        /// </summary>
        public static readonly DependencyProperty HeaderActiveForegroundProperty;
        /// <summary>
        /// Зависимое свойство. Цвет текста для кнопок типа IconButton.
        /// </summary>
        public static readonly DependencyProperty IconButtonNormalForegroundProperty;
        /// <summary>
        /// Зависимое свойство. Цвет текста для кнопок типа IconButton при наведении мыши.
        /// </summary>
        public static readonly DependencyProperty IconBottonHoverForegroundProperty;
        /// <summary>
        /// Зависимое свойство. Цвет фона разделителя панелей
        /// </summary>
        public static readonly DependencyProperty SplitterBackgroundProperty;

        /// <summary>
        /// Зависимое свойство. Цвет фона контента панели.
        /// </summary>
        public static readonly DependencyProperty ContentBackgroundProperty;
        /// <summary>
        /// Зависимое свойство. Цвет фона Toolbar панели.
        /// </summary>
        public static readonly DependencyProperty ContentToolbarBackgroundProperty;

        /// <summary>
        /// Цвет фона Toolbar панели.
        /// </summary>
        public SolidColorBrush ContentToolbarBackground
        {
            get
            {

                return GetValue(ContentToolbarBackgroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(ContentToolbarBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Цвет фона Цвет фона контента панели.
        /// </summary>
        public SolidColorBrush ContentBackground
        {
            get
            {

                return GetValue(ContentBackgroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(ContentBackgroundProperty, value);
            }
        }


        /// <summary>
        /// Цвет фона заголовка панели.
        /// </summary>
        public SolidColorBrush SplitterBackground
        {
            get
            {

                return GetValue(SplitterBackgroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(SplitterBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Цвет фона заголовка панели.
        /// </summary>
        public SolidColorBrush HeaderBackground
        {
            get
            {

                return GetValue(HeaderBackgroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(HeaderBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Цвет текста заголовка панели.
        /// </summary>
        public SolidColorBrush HeaderForeground
        {
            get
            {

                return GetValue(HeaderForegroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(HeaderForegroundProperty, value);
            }
        }

        /// <summary>
        /// Цвет фона заголовка панели, кагда она становиться активной.
        /// </summary>
        public SolidColorBrush HeaderActiveBackground
        {
            get
            {

                return GetValue(HeaderActiveBackgroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(HeaderActiveBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Цвет текста заголовка панели, кагда она становиться активной.
        /// </summary>
        public SolidColorBrush HeaderActiveForeground
        {
            get
            {

                return GetValue(HeaderActiveForegroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(HeaderActiveForegroundProperty, value);
            }
        }

        /// <summary>
        /// Цвет текста для кнопок типа IconButton.
        /// </summary>
        public SolidColorBrush IconButtonNormalForeground
        {
            get
            {

                return GetValue(IconButtonNormalForegroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(IconButtonNormalForegroundProperty, value);
            }
        }

        /// <summary>
        /// Цвет текста для кнопок типа IconButton при наведении мыши.
        /// </summary>
        public SolidColorBrush IconBottonHoverForeground
        {
            get
            {

                return GetValue(IconBottonHoverForegroundProperty) as SolidColorBrush;
            }
            set
            {
                SetValue(IconBottonHoverForegroundProperty, value);
            }
        }

        /// <summary>
        /// Конструктов.
        /// </summary>
        static PanelSettings()
        {
            HeaderBackgroundProperty = DependencyProperty.Register("HeaderBackground", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            HeaderForegroundProperty = DependencyProperty.Register("HeaderForeground", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            HeaderActiveBackgroundProperty = DependencyProperty.Register("HeaderActiveBackground", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            HeaderActiveForegroundProperty = DependencyProperty.Register("HeaderActiveForeground", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            IconButtonNormalForegroundProperty = DependencyProperty.Register("IconButtonNormalForeground", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            IconBottonHoverForegroundProperty = DependencyProperty.Register("IconBottonHoverForeground", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            SplitterBackgroundProperty = DependencyProperty.Register("SplitterBackgroundProperty", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            ContentBackgroundProperty = DependencyProperty.Register("ContentBackgroundProperty", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
            ContentToolbarBackgroundProperty = DependencyProperty.Register("ContentToolbarBackgroundProperty", typeof(SolidColorBrush), typeof(PanelSettings),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, null, null));
        }
    }
}
