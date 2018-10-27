using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prism.Forms
{
    public class IsEnabledExtension : IMarkupExtension
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var button = serviceProvider.GetService<IProvideValueTarget>().TargetObject as Button;

            return button != null && !string.IsNullOrWhiteSpace(button.Text);
        }
    }
}
