using System;
using System.Linq;
using System.Threading.Tasks;
using Prism.Forms.Pages;
using Rg.Plugins.Popup.Services;

namespace Prism.Services
{
    public class CustomPageDialogService : IPageDialogService
    {
        #region IPageDialogService Implementation

        public virtual async Task DisplayActionSheetAsync( string title, params IActionSheetButton[] buttons )
        {
            if( buttons == null || buttons.All( b => b == null ) )
                throw new ArgumentException( "At least one button needs to be supplied", nameof( buttons ) );

            var destroyButton = buttons.FirstOrDefault( button => button != null && button.IsDestroy );
            var cancelButton = buttons.FirstOrDefault( button => button != null && button.IsCancel );
            var otherButtonsText = buttons.Where( button => button != null && !( button.IsDestroy || button.IsCancel ) ).Select( b => b.Text ).ToArray();

            var pressedButton = await DisplayActionSheetAsync( title, cancelButton?.Text, destroyButton?.Text, otherButtonsText );

            foreach( var button in buttons.Where( button => button != null && button.Text.Equals( pressedButton ) ) )
            {
                if( button.Command.CanExecute( button.Text ) )
                    button.Command.Execute( button.Text );

                return;
            }
        }

        public virtual async Task<string> DisplayActionSheetAsync( string title, string cancelButton, string destroyButton, params string[] otherButtons )
        {
            var actionSheet = GetActionSheet( title, null, cancelButton, destroyButton, otherButtons );
            await PopupNavigation.PushAsync( actionSheet, true );
            return await actionSheet.GetActionSheetResultAsync();
        }

        public virtual async Task DisplayAlertAsync( string title, string message, string cancelButton )
        {
            await DisplayAlertAsync( title, message, null, cancelButton );
        }

        public virtual async Task<bool> DisplayAlertAsync( string title, string message, string acceptButton, string cancelButton )
        {
            var alertPage = GetAlertPage( title, message, acceptButton, cancelButton );
            return await alertPage.GetAlertPageResultAsync();
        }

        #endregion

        protected virtual ActionSheetPageBase GetActionSheet( string title, string message, string cancelButton, string destroyButton, string[] otherButtons )
        {
            return ActionSheetPage.CreatePage( title, message, cancelButton, destroyButton, otherButtons );
        }

        protected virtual AlertPageBase GetAlertPage( string title, string message, string acceptButton, string cancelButton )
        {
            return AlertPage.CreateAlertPage( title, message, acceptButton, cancelButton );
        }
    }
}

