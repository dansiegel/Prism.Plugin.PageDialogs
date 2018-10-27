using Prism.Commands;
using Prism.Services;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Prism.Forms.Pages
{
    public abstract class ActionSheetPageBase : PopupPage, IActionSheetPage
    {
        protected IEnumerable<IActionSheetButton> ActionSheetButtons { get; set; }

        public ActionSheetPageBase(ActionSheetRequest request)
        {
            ActionSheetButtons = request.Buttons;
            InvokeButtonCommand = new DelegateCommand<IActionSheetButton>(OnInvokeButtonCommandExecuted);
        }

        public DelegateCommand<IActionSheetButton> InvokeButtonCommand { get; }

        #region IActionSheetPage

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public IActionSheetButton CancelButton => 
            ActionSheetButtons.FirstOrDefault(b => b.IsCancel);

        public IActionSheetButton DestroyButton => 
            ActionSheetButtons.FirstOrDefault(b => b.IsDestroy);

        public IEnumerable<IActionSheetButton> Options =>
            ActionSheetButtons.Where(b => !b.IsDestroy && !b.IsCancel);

        public event EventHandler<IActionSheetButton> SelectedOptionEvent;

        public virtual async Task<IActionSheetButton> GetActionSheetResultAsync()
        {
            await Task.Run( () =>
            {
                while( !eventInvoked )
                {
                }
            } );

            return result;
        }

        #endregion

        #region Private Properties

        protected bool eventInvoked { get; set; }

        protected IActionSheetButton result { get; set; }

        #endregion

        protected override void OnDisappearing()
        {
            if(eventInvoked == false)
            {
                eventInvoked = true;
                result = null;
            }
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            OnPropertyChanging(propertyName);
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        private void OnInvokeButtonCommandExecuted(IActionSheetButton button)
        {
            result = button;
            SelectedOptionEvent?.Invoke(this, button);
            eventInvoked = true;
        }
    }
}

