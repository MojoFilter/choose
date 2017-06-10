
using System;
using Choose.ViewModels;
using ReactiveUI;
using Xamarin.Forms;

namespace Choose.Views
{
    public partial class LoginPage : ContentPage, IViewFor<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
            this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.BindingContext);

            this.BindCommand(this.ViewModel, vm => vm.NotNowCommand, v => v.ButtonNotNow);
            this.BindCommand(this.ViewModel, vm => vm.SignInCommand, v => v.signInButton);

            this.Bind(ViewModel, vm => vm.IsBusy, v => v.BusyIndicator.IsRunning);
            this.Bind(ViewModel, vm => vm.Message, v => v.MessageLabel.Text);
            this.Bind(ViewModel, vm => vm.Message, v => v.ButtonNotNow.Text);
        }

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(LoginViewModel), typeof(LoginPage));

        public LoginViewModel ViewModel
        {
            get => (LoginViewModel)this.GetValue(ViewModelProperty);
            set => this.SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => this.ViewModel;
            set => this.ViewModel = value as LoginViewModel;
        }

    }
}
