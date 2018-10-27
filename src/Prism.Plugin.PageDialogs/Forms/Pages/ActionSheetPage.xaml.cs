using Prism.Commands;
using Prism.Services;
using Xamarin.Forms;

namespace Prism.Forms.Pages
{
    public partial class ActionSheetPage
    {
        public ActionSheetPage(ActionSheetRequest request)
            : base(request)
        {
            InitializeComponent();
        }

        #region Bound Properties

        public Color TitleBarColor { get; set; } = DefaultTitleBarColor;

        public Color TitleColor { get; set; } = DefaultTitleColor;

        public Color ListBackgroundColor { get; set; } = DefaultListBackgroundColor;

        public Color ListTextColor { get; set; } = DefaultListTextColor;

        public Color FooterBarColor { get; set; } = DefaultFooterBarColor;

        public Style OptionsListStyle { get; set; } = DefaultOptionsListStyle;

        public Style CancelButtonStyle { get; set; } = DefaultCancelButtonStyle;

        public Style DestroyButtonStyle { get; set; } = DefaultDestroyButtonStyle;

        #endregion

        #region Static Factory Methods

        public static ActionSheetPage CreatePage(ActionSheetRequest request) =>
            new ActionSheetPage(request);

        public static ActionSheetPage CreatePage(ActionSheetRequest request, Color titleBarColor, Color titleColor, Color listBackgroundColor, Color listTextColor, Color footerBarColor) =>
            new ActionSheetPage(request)
            {
                TitleBarColor = titleBarColor,
                TitleColor = titleColor,
                ListBackgroundColor = listBackgroundColor,
                ListTextColor = listTextColor,
                FooterBarColor = footerBarColor
            };

        #endregion

        #region Static Members

        private static Style _defaultOptionsListStyle;
        public static Style DefaultOptionsListStyle
        {
            get
            {
                if(_defaultOptionsListStyle == null)
                {
                    _defaultOptionsListStyle = new Style(typeof(ListView));
                    _defaultOptionsListStyle.Setters.Add(ListView.BackgroundColorProperty, Color.White);
                    _defaultOptionsListStyle.Setters.Add(ListView.SelectionModeProperty, ListViewSelectionMode.Single);
                    _defaultOptionsListStyle.Setters.Add(ListView.SeparatorVisibilityProperty, SeparatorVisibility.None);
                }

                return _defaultOptionsListStyle;
            }
        }

        private static Style _defaultCancelButtonStyle;
        public static Style DefaultCancelButtonStyle
        {
            get
            {
                if( _defaultCancelButtonStyle == null )
                {
                    _defaultCancelButtonStyle = new Style(typeof(Button));
                    _defaultCancelButtonStyle.Setters.Add(Button.HorizontalOptionsProperty, LayoutOptions.Start);
                    _defaultCancelButtonStyle.Setters.Add(Button.MarginProperty, new Thickness(5));
                    _defaultCancelButtonStyle.Setters.Add(Button.BackgroundColorProperty, Color.Silver);
                    _defaultCancelButtonStyle.Setters.Add(Button.TextColorProperty, Color.White);
                }
                return _defaultCancelButtonStyle;
            }
            set { _defaultCancelButtonStyle = value; }
        }

        private static Style _defaultDestroyButtonStyle;
        public static Style DefaultDestroyButtonStyle
        {
            get
            {
                if( _defaultDestroyButtonStyle == null )
                {
                    _defaultDestroyButtonStyle = new Style(typeof(Button));
                    _defaultDestroyButtonStyle.Setters.Add(Button.HorizontalOptionsProperty, LayoutOptions.End);
                    _defaultDestroyButtonStyle.Setters.Add(Button.MarginProperty, new Thickness(5));
                    _defaultDestroyButtonStyle.Setters.Add(Button.BackgroundColorProperty, Color.Red);
                    _defaultDestroyButtonStyle.Setters.Add(Button.TextColorProperty, Color.White);
                }
                return _defaultDestroyButtonStyle;
            }
            set { _defaultDestroyButtonStyle = value; }
        }

        private static Color? _defaultTitleBarColor;
        public static Color DefaultTitleBarColor
        {
            get { return _defaultTitleBarColor ?? Color.Black; }
            set { _defaultTitleBarColor = value; }
        }

        private static Color? _defaultTitleColor;
        public static Color DefaultTitleColor
        {
            get { return _defaultTitleColor ?? Color.White; }
            set { _defaultTitleColor = value; }
        }

        private static Color? _defaultListBackgroundColor;
        public static Color DefaultListBackgroundColor
        {
            get { return _defaultListBackgroundColor ?? Color.White; }
            set { _defaultListBackgroundColor = value; }
        }

        private static Color? _defaultListTextColor;
        public static Color DefaultListTextColor
        {
            get { return _defaultListTextColor ?? Color.Black; }
            set { _defaultListTextColor = value; }
        }

        private static Color? _defaultFooterBarColor;
        public static Color DefaultFooterBarColor
        {
            get { return _defaultFooterBarColor ?? Color.Accent; }
            set { _defaultFooterBarColor = value; }
        }

        #endregion
    }
}

