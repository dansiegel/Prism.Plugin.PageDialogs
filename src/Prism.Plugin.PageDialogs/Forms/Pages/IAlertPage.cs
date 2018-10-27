using Prism.Services;
using System;
using System.Threading.Tasks;

namespace Prism.Forms.Pages
{
    public interface IAlertPage
    {
        AlertDialogRequest Request { get; }

        event EventHandler<bool> OnOptionSelected;

        void SendOptionsSelectedEvent( bool result );

        Task<bool> GetAlertPageResultAsync();
    }
}

