using System.Threading.Tasks;
using Prism.Forms.Pages;

namespace Prism.Services
{
    public interface IExtendedPageDialogService : IPageDialogService
    {
        Task<string> DisplayActionSheetAsync( string title, string message, string cancelButton, string destroyButton, params string[] otherButtons );
        Task DisplayActionSheetAsync( string title, string message, params IActionSheetButton[] buttons );
        Task<string> DisplayActionSheetAsync( ActionSheetPageBase actionSheetPage );
    }
}
