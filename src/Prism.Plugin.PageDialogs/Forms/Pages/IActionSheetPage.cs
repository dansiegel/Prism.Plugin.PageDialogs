using Prism.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prism.Forms.Pages
{
    public interface IActionSheetPage
    {
        string Title { get; set; }

        string Message { get; set; }

        IActionSheetButton CancelButton { get; }

        IActionSheetButton DestroyButton { get; }

        IEnumerable<IActionSheetButton> Options { get; }

        event EventHandler<IActionSheetButton> SelectedOptionEvent;

        Task<IActionSheetButton> GetActionSheetResultAsync();
    }
}

