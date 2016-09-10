using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prism.Forms.Pages
{
    public interface IActionSheetPage
    {
        string Title { get; set; }

        string Message { get; set; }

        string CancelButtonText { get; set; }

        string DestroyButtonText { get; set; }

        IEnumerable<string> Options { get; set; }

        event EventHandler<string> SelectedOptionEvent;

        Task<string> GetActionSheetResultAsync();
    }
}

