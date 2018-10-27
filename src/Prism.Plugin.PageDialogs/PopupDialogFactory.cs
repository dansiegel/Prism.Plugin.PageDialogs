using Prism.Forms.Pages;

namespace Prism.Services
{
    public sealed class PopupDialogFactory : IPopupDialogFactory
    {
        public ActionSheetPageBase GetActionSheet(ActionSheetRequest request) =>
            ActionSheetPage.CreatePage(request);

        public AlertPageBase GetAlertPage(AlertDialogRequest request) =>
            AlertPage.CreateAlertPage(request);
    }
}
