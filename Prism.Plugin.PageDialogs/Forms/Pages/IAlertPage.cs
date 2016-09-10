using System;
using System.Threading.Tasks;

namespace Prism.Forms.Pages
{
    public interface IAlertPage
    {
        string Title { get; set; }

        string Message { get; set; }

        string AcceptText { get; set; }

        string CancelText { get; set; }

        event EventHandler<bool> OnOptionSelected;

        void SendOptionsSelectedEvent( bool result );

        Task<bool> GetAlertPageResultAsync();
    }
}

