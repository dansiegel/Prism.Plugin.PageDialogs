using System.Collections.Generic;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using Prism.Services.Extensions;

namespace PageDialogSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        IPageDialogService _pageDialogService { get; }

        public MainPageViewModel( IPageDialogService pageDialogService )
        {
            _pageDialogService = pageDialogService;

            DisplayAlertCommand = DelegateCommand.FromAsyncHandler( ExecuteDisplayAlertCommandAsync );
            DisplayActionSheetCommand = DelegateCommand<bool>.FromAsyncHandler( ExecuteDisplayActionSheetCommandAsync );
        }

        public DelegateCommand DisplayAlertCommand { get; }

        public DelegateCommand<bool> DisplayActionSheetCommand { get; } 

        public async Task ExecuteDisplayAlertCommandAsync() =>
            await _pageDialogService.DisplayAlertAsync( "Message Title", "Hello custom Alert", "Ok" );

        public async Task ExecuteDisplayActionSheetCommandAsync( bool includeMessage )
        {
            var btns = new List<IActionSheetButton>()
            {
                ActionSheetButton.CreateButton( "Button 1", null ),
                ActionSheetButton.CreateButton( "Button 2", null ),
                ActionSheetButton.CreateCancelButton( "Cancel", null ),
                ActionSheetButton.CreateDestroyButton( "Destroy", null )
            }.ToArray();

            if( includeMessage )
            {
                await _pageDialogService.DisplayActionSheetAsync( "Message Title", "Hello from the Page Dialog Extensions", btns );
            }
            else
            {
                await _pageDialogService.DisplayActionSheetAsync( "Message Title", btns );
            }
        }
    }
}
