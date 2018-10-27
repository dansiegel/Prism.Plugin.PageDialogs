using Prism.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prism.Forms
{
    [ContentProperty(nameof(Path))]
    public class HasActionSheetButtonExtension : IMarkupExtension
    {
        public string Path { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var provider = serviceProvider.GetService<IProvideValueTarget>();
            var button = provider.TargetObject;
            if (button == null) return false;

            var parameterValue = button.GetType().GetProperty(Path).GetValue(button);

            return parameterValue != null && parameterValue is IActionSheetButton;
        }
    }
}
