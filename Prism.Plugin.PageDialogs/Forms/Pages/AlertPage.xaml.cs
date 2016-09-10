using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Prism.Forms.Pages
{
    public partial class AlertPage : AlertPageBase
    {
        public AlertPage()
        {
            InitializeComponent();
            Disappearing += OnDisappearing;
        }

        public AlertPage( string title, string message, string acceptButton, string cancelButton ) : this()
        {
            Title = title;
            Message = message;
            AcceptText = acceptButton;
            CancelText = cancelButton;

            if( string.IsNullOrWhiteSpace( acceptButton ) )
            {

            }
            else
            {
                ShowAcceptButton = true;
            }
        }

        private bool ShowAcceptButton;

        public static AlertPage CreateAlertPage( string title, string message, string acceptButton, string cancelButton ) =>
            new AlertPage( title, message, acceptButton, cancelButton );
    }
}

