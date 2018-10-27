using Prism.Forms.Pages;
using Rg.Plugins.Popup.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prism.Services
{
    public class PopupDialogService : IPopupDialogService
    {
        protected IPopupNavigation _popupNavigation { get; }
        protected IPopupDialogFactory _popupDialogFactory { get; }

        public PopupDialogService(IPopupNavigation popupNavigation, IPopupDialogFactory popupDialogFactory)
        {
            _popupNavigation = popupNavigation;
            _popupDialogFactory = popupDialogFactory;
        }

        public async Task DisplayActionSheetAsync(ActionSheetRequest request)
        {
            var page = _popupDialogFactory.GetActionSheet(request);
            await DisplayActionSheetAsync(page, request.Animated ?? true);
        }

        protected async Task DisplayActionSheetAsync(ActionSheetPageBase actionSheetPage, bool animated)
        {
            await _popupNavigation.PushAsync(actionSheetPage, animated);
            await actionSheetPage.GetActionSheetResultAsync();
        }

        #region IPageDialogService Implementation

        public virtual Task DisplayActionSheetAsync(string title, params IActionSheetButton[] buttons) =>
            DisplayActionSheetAsync(new ActionSheetRequest
            {
                Title = title,
                Buttons = buttons
            });

        public virtual async Task<string> DisplayActionSheetAsync(string title, string cancelButton, string destroyButton, params string[] otherButtons)
        {
            List<IActionSheetButton> buttons = new List<IActionSheetButton>();
            string result = null;
            if(!string.IsNullOrWhiteSpace(cancelButton))
            {
                buttons.Add(ActionSheetButton.CreateCancelButton(cancelButton, SetResult, cancelButton));
            }

            if(!string.IsNullOrWhiteSpace(destroyButton))
            {
                buttons.Add(ActionSheetButton.CreateDestroyButton(destroyButton, SetResult, destroyButton));
            }

            foreach(var button in otherButtons)
            {
                buttons.Add(ActionSheetButton.CreateButton(button, SetResult, button));
            }

            void SetResult(string s) => result = s;

            var request = new ActionSheetRequest
            {
                Title = title,
                Buttons = buttons
            };
            await DisplayActionSheetAsync(request);

            return result;
        }

        //public virtual async Task DisplayAlertAsync( string title, string message, string cancelButton )
        //{
        //    await DisplayAlertAsync( title, message, null, cancelButton );
        //}

        public virtual async Task<bool> DisplayAlertAsync(AlertDialogRequest request)
        {
            var alertPage = _popupDialogFactory.GetAlertPage(request);
            await _popupNavigation.PushAsync(alertPage, request.Animated ?? true);
            return await alertPage.GetAlertPageResultAsync();
        }

        public virtual Task<bool> DisplayAlertAsync(string title, string message, string acceptButton, string cancelButton) =>
            DisplayAlertAsync(new AlertDialogRequest
            {
                Title = title,
                Message = message,
                AcceptButton = acceptButton,
                CancelButton = cancelButton
            });

        public Task DisplayAlertAsync(string title, string message, string cancelButton) =>
            DisplayAlertAsync(new AlertDialogRequest
            {
                Title = title,
                Message = message,
                CancelButton = cancelButton
            });

        #endregion
    }
}

