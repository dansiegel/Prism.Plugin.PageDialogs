using System;
using System.Linq;
using System.Threading.Tasks;
using Prism.Forms.Pages;
using Rg.Plugins.Popup.Services;

namespace Prism.Services
{
    public static class CustomPageDialogServiceExtensions
    {
        public static async Task<string> DisplayActionSheetAsync( this IPageDialogService pageDialogService, string title, string message, string cancelButton, string destroyButton, params string[] otherButtons )
        {
            var page = ActionSheetPage.CreatePage( title, message, cancelButton, destroyButton, otherButtons );
            return await pageDialogService.DisplayActionSheetAsync( page );
        }

        public static async Task DisplayActionSheetAsync( this IPageDialogService pageDialogService, string title, string message, params IActionSheetButton[] buttons )
        {
            if( buttons == null || buttons.All( b => b == null ) )
                throw new ArgumentException( "At least one button needs to be supplied", nameof( buttons ) );

            var destroyButton = buttons.FirstOrDefault( button => button != null && button.IsDestroy );
            var cancelButton = buttons.FirstOrDefault( button => button != null && button.IsCancel );
            var otherButtonsText = buttons.Where( button => button != null && !( button.IsDestroy || button.IsCancel ) ).Select( b => b.Text ).ToArray();

            var pressedButton = await pageDialogService.DisplayActionSheetAsync( title, message, cancelButton?.Text, destroyButton?.Text, otherButtonsText );

            foreach( var button in buttons.Where( button => button != null && button.Text.Equals( pressedButton ) ) )
            {
                if( button.Command.CanExecute( button.Text ) )
                    button.Command.Execute( button.Text );

                return;
            }
        }

        public static async Task<string> DisplayActionSheetAsync( this IPageDialogService pageDialogService, ActionSheetPageBase actionSheetPage )
        {
            await PopupNavigation.PushAsync( actionSheetPage, true );
            return await actionSheetPage.GetActionSheetResultAsync();
        }
    }
}


