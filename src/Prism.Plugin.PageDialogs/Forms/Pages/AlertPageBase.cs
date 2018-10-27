using Prism.Services;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;

namespace Prism.Forms.Pages
{
    public class AlertPageBase : PopupPage, IAlertPage
    {
        public AlertPageBase(AlertDialogRequest request)
        {
            Request = request;
        }

        #region IAlertPage Implementation 

        public AlertDialogRequest Request { get; }

        public event EventHandler<bool> OnOptionSelected;

        public async Task<bool> GetAlertPageResultAsync()
        {
            await Task.Run(() =>
            {
                while(!eventFired) { }
            }).ConfigureAwait(false);

            await PopupNavigation.Instance.PopAsync();
            return result;
        }

        public void SendOptionsSelectedEvent(bool result)
        {
            this.result = result;
            eventFired = true;
            OnOptionSelected.Invoke( this, result );
        }

        #endregion

        protected bool eventFired;

        protected bool result;

        protected override void OnDisappearing()
        {
            if (eventFired == false)
            {
                eventFired = true;
            }
        }
    }
}

