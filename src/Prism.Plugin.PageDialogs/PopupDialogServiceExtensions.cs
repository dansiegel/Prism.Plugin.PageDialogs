using System;
using System.Threading.Tasks;

namespace Prism.Services.Extensions
{
    public static class PopupDialogServiceExtensions
    {
        public static async Task DisplayActionSheetAsync(this IPageDialogService pageDialogService, ActionSheetRequest request)
        {
            if(pageDialogService is IPopupDialogService popupDialogService)
            {
                await popupDialogService.DisplayActionSheetAsync(request);
            }

            throw new NotSupportedException("The provided instance of IPageDialogService does not implement IPopupDialogService");
        }

        public static async Task<bool> DisplayAlertAsync(this IPageDialogService pageDialogService, AlertDialogRequest request)
        {
            if (pageDialogService is IPopupDialogService popupDialogService)
            {
                return await popupDialogService.DisplayAlertAsync(request);
            }

            throw new NotSupportedException("The provided instance of IPageDialogService does not implement IPopupDialogService");
        }
    }
}


