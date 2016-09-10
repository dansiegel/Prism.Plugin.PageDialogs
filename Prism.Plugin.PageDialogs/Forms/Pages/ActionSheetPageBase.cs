using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Prism.Forms.Pages
{
    public abstract class ActionSheetPageBase : PopupPage, IActionSheetPage
    {
        public ActionSheetPageBase()
        {
            Disappearing += OnDisappearing;
        }

        #region BindableProperties

        public static readonly BindableProperty CancelButtonTextProperty =
            BindableProperty.Create( nameof( CancelButtonText ), typeof( string ), typeof( ActionSheetPageBase ), null );

        public static readonly BindableProperty DestroyButtonTextProperty =
            BindableProperty.Create( nameof( DestroyButtonText ), typeof( string ), typeof( ActionSheetPageBase ), null );

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create( nameof( Message ), typeof( string ), typeof( ActionSheetPageBase ), null );

        public static readonly BindableProperty OptionsProperty =
            BindableProperty.Create( nameof( Options ), typeof( IEnumerable<string> ), typeof( ActionSheetPageBase ), new ObservableCollection<string>() );

        #endregion

        #region IActionSheetPage

        public string CancelButtonText
        {
            get { return GetValue( CancelButtonTextProperty ).ToString(); }
            set { SetValue( CancelButtonTextProperty, value ); }
        }

        public string DestroyButtonText
        {
            get { return GetValue( DestroyButtonTextProperty ).ToString(); }
            set { SetValue( DestroyButtonTextProperty, value ); }
        }

        public string Message
        {
            get { return GetValue( MessageProperty ).ToString(); }
            set { SetValue( MessageProperty, value ); }
        }

        public IEnumerable<string> Options
        {
            get { return ( IEnumerable<string> )GetValue( OptionsProperty ); }
            set { SetValue( OptionsProperty, value ); }
        }

        public event EventHandler<string> SelectedOptionEvent;

        public virtual async Task<string> GetActionSheetResultAsync()
        {
            await Task.Run( () =>
            {
                while( !eventInvoked )
                {
                }
            } );

            await PopupNavigation.PopAsync();
            return result;
        }

        #endregion

        #region Private Properties

        protected bool eventInvoked;

        protected string result;

        #endregion

        public void SendSelectedOptionEvent( string message )
        {
            result = string.Empty;
            if( Options.Any( x => x == message ) || message == CancelButtonText || message == DestroyButtonText )
            {
                result = message;
            }

            SelectedOptionEvent.Invoke( this, result );
            eventInvoked = true;
        }

        protected void OnDisappearing( object sender, EventArgs args )
        {
            if( eventInvoked == false )
            {
                eventInvoked = true;
                result = string.Empty;
            }
        }
    }
}

