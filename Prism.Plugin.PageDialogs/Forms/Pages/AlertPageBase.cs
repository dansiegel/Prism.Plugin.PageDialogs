using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Prism.Forms.Pages
{
    public class AlertPageBase : PopupPage, IAlertPage
    {
        #region Bindable Properties

        public static readonly BindableProperty AcceptTextProperty =
            BindableProperty.Create( nameof( AcceptText ), typeof( string ), typeof( AlertPageBase ), null );

        public static readonly BindableProperty CancelTextProperty =
            BindableProperty.Create( nameof( CancelText ), typeof( string ), typeof( AlertPageBase ), null );

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create( nameof( Message ), typeof( string ), typeof( AlertPageBase ), null );

        #endregion

        public AlertPageBase()
        {
            Disappearing += OnDisappearing;
        }

        #region IAlertPage Implementation 

        public string AcceptText
        {
            get { return GetValue( AcceptTextProperty ).ToString(); }

            set { SetValue( AcceptTextProperty, value ); }
        }

        public string CancelText
        {
            get { return GetValue( CancelTextProperty ).ToString(); }

            set { SetValue( CancelTextProperty, value ); }
        }

        public string Message
        {
            get { return GetValue( MessageProperty ).ToString(); }

            set { SetValue( MessageProperty, value ); }
        }

        public event EventHandler<bool> OnOptionSelected;

        public async Task<bool> GetAlertPageResultAsync()
        {
            await Task.Run( () =>
            {
                while( !eventFired ) { }
            } );

            await PopupNavigation.PopAsync();
            return result;
        }

        public void SendOptionsSelectedEvent( bool result )
        {
            this.result = result;
            eventFired = true;
            OnOptionSelected.Invoke( this, result );
        }

        #endregion

        protected bool eventFired;

        protected bool result;

        protected void OnDisappearing( object sender, EventArgs e )
        {
            if( eventFired == false )
            {
                eventFired = true;
            }
        }
    }
}

