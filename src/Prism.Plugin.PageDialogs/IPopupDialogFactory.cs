using Prism.Forms.Pages;

namespace Prism.Services
{
    public interface IPopupDialogFactory
    {
        ActionSheetPageBase GetActionSheet(ActionSheetRequest request);

        AlertPageBase GetAlertPage(AlertDialogRequest request);
    }
}
