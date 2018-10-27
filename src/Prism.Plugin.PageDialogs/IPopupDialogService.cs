using System.Threading.Tasks;
using Prism.Forms.Pages;

namespace Prism.Services
{
    public interface IPopupDialogService : IPageDialogService
    {
        Task<bool> DisplayAlertAsync(AlertDialogRequest request);
        Task DisplayActionSheetAsync(ActionSheetRequest request);
    }
}
