using Prism.Services;
using Xamarin.Forms;

namespace Prism.Forms.Pages
{
    public partial class AlertPage
    {
        public AlertPage(AlertDialogRequest request)
            : base(request)
        {
            InitializeComponent();
        }

        public Color TitleBarBackgroundColor { get; set; } = DefaultTitleBarBackgroundColor;

        public Style TitleStyle { get; set; } = DefaultTitleStyle;

        public Style MessageStyle { get; set; } = DefaultMessageStyle;

        public Style AcceptButtonStyle { get; set; } = DefaultAcceptButtonStyle;

        public Style CancelButtonStyle { get; set; } = DefaultCancelButtonStyle;

        public static AlertPage CreateAlertPage(AlertDialogRequest request) =>
            new AlertPage(request);

        public static Color? _defaultTitleBarBackgroundColor;
        public static Color DefaultTitleBarBackgroundColor => 
            _defaultTitleBarBackgroundColor ?? Color.Gray;

        private static Style _defaultTitleStyle;
        public static Style DefaultTitleStyle
        {
            get
            {
                if(_defaultTitleStyle == null)
                {
                    _defaultTitleStyle = Device.Styles.TitleStyle;
                    _defaultTitleStyle.Setters.Add(Label.TextColorProperty, Color.White);
                }

                return _defaultTitleStyle;
            }
        }

        private static Style _defaultMessageStyle;
        public static Style DefaultMessageStyle
        {
            get
            {
                if(_defaultMessageStyle == null)
                {
                    _defaultMessageStyle = new Style(typeof(Label));
                    _defaultMessageStyle.Setters.Add(Label.TextColorProperty, Color.Default);
                }

                return _defaultMessageStyle;
            }
        }

        private static Style _defaultAcceptButtonStyle;
        public static Style DefaultAcceptButtonStyle
        {
            get
            {
                if(_defaultAcceptButtonStyle == null)
                {
                    _defaultAcceptButtonStyle = new Style(typeof(Button));
                    _defaultAcceptButtonStyle.Setters.Add(Button.HorizontalOptionsProperty, LayoutOptions.End);
                }

                return _defaultAcceptButtonStyle;
            }
        }

        private static Style _defaultCancelButtonStyle;
        public static Style DefaultCancelButtonStyle
        {
            get
            {
                if (_defaultCancelButtonStyle == null)
                {
                    _defaultCancelButtonStyle = new Style(typeof(Button));
                    _defaultCancelButtonStyle.Setters.Add(Button.HorizontalOptionsProperty, LayoutOptions.Start);
                }

                return _defaultCancelButtonStyle;
            }
        }
    }
}

