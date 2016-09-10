using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Prism.Forms.Pages
{
    public partial class ActionSheetPage : ActionSheetPageBase
    {
        public ActionSheetPage() : base()
        {
            InitializeComponent();

            CancelCommand = new DelegateCommand( () => SendSelectedOptionEvent( CancelButtonText ) );
            DestroyCommand = new DelegateCommand( () => SendSelectedOptionEvent( DestroyButtonText ) );
        }

        public ActionSheetPage( string title, string message, string cancelButton, string destroyButton, IEnumerable<string> otherButtons ) : this()
        {
            Title = title;
            Message = message;
            CancelButtonText = cancelButton;
            DestroyButtonText = destroyButton;

            if( otherButtons?.Count() > 0 )
                Options = new ObservableCollection<string>( otherButtons );
        }

        #region Bound Properties

        public Color TitleBarColor { get; set; } = DefaultTitleBarColor;

        public Color TitleColor { get; set; } = DefaultTitleColor;

        public Color ListBackgroundColor { get; set; } = DefaultListBackgroundColor;

        public Color ListTextColor { get; set; } = DefaultListTextColor;

        public Color FooterBarColor { get; set; } = DefaultFooterBarColor;

        public Style CancelButtonStyle { get; set; } = DefaultCancelButtonStyle;

        public Style DestroyButtonStyle { get; set; } = DefaultDestroyButtonStyle;

        public DelegateCommand CancelCommand { get; }

        public DelegateCommand DestroyCommand { get; }

        #endregion

        #region Static Factory Methods

        public static ActionSheetPage CreatePage( string title, string message, string cancelButton, string destroyButton, params string[] otherButtons )
        {
            return new ActionSheetPage( title, message, cancelButton, destroyButton, otherButtons );
        }

        public static ActionSheetPage CreatePage( string title, string message, string cancelButton, string destroyButton, IEnumerable<string> otherButtons,
                                                 Color titleBarColor, Color titleColor, Color listBackgroundColor, Color listTextColor, Color footerBarColor )
        {
            return new ActionSheetPage( title, message, cancelButton, destroyButton, otherButtons )
            {
                TitleBarColor = titleBarColor,
                TitleColor = titleColor,
                ListBackgroundColor = listBackgroundColor,
                ListTextColor = listTextColor,
                FooterBarColor = footerBarColor
            };
        }

        #endregion

        #region Static Members

        private static Style _defaultCancelButtonStyle;
        public static Style DefaultCancelButtonStyle
        {
            get
            {
                if( _defaultCancelButtonStyle == null )
                {
                    _defaultCancelButtonStyle = new Style( typeof( Button ) );
                    _defaultCancelButtonStyle.Setters.Add( new Setter()
                    {
                        Property = Button.HorizontalOptionsProperty,
                        Value = LayoutOptions.Start
                    } );
                    _defaultCancelButtonStyle.Setters.Add( new Setter()
                    {
                        Property = Button.MarginProperty,
                        Value = new Thickness( 5 )
                    } );
                    _defaultCancelButtonStyle.Setters.Add( new Setter()
                    {
                        Property = Button.BackgroundColorProperty,
                        Value = Color.Silver
                    } );
                    _defaultCancelButtonStyle.Setters.Add( new Setter()
                    {
                        Property = Button.TextColorProperty,
                        Value = Color.White
                    } );
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
                    _defaultDestroyButtonStyle = new Style( typeof( Button ) );
                    _defaultDestroyButtonStyle.Setters.Add( new Setter()
                    {
                        Property = Button.HorizontalOptionsProperty,
                        Value = LayoutOptions.End
                    } );
                    _defaultDestroyButtonStyle.Setters.Add( new Setter()
                    {
                        Property = Button.MarginProperty,
                        Value = new Thickness( 5 )
                    } );
                    _defaultDestroyButtonStyle.Setters.Add( new Setter()
                    {
                        Property = Button.BackgroundColorProperty,
                        Value = Color.Red
                    } );
                    _defaultDestroyButtonStyle.Setters.Add( new Setter()
                    {
                        Property = Button.TextColorProperty,
                        Value = Color.White
                    } );
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

