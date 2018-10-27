using System.Collections.Generic;

namespace Prism.Services
{
    public struct ActionSheetRequest
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public IEnumerable<IActionSheetButton> Buttons { get; set; }
        public string Style { get; set; }
        public bool? Animated { get; set; }
    }
}
