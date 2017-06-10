using System.Threading.Tasks;
using System.Windows.Input;

using Choose.Models;
using Choose.Helpers;
using Choose.Services;

using Xamarin.Forms;
using ReactiveUI;
using System.Reactive.Linq;

namespace Choose.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel() : base("Login")
        {
            SignInCommand = ReactiveCommand.CreateFromTask(this.SignIn);
            NotNowCommand = ReactiveCommand.Create(()=> { });

     
        }

        string message = "Titties";
        public string Message
        {
            get { return message; }
            set { this.RaiseAndSetIfChanged(ref message, value); }
        }
        
        public ICommand NotNowCommand { get; }
        public ICommand SignInCommand { get; }

        async Task SignIn()
        {
            try
            {
                IsBusy = true;
                Message = "Signing In...";

                // Log the user in
                await TryLoginAsync();
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;

                if (Settings.IsLoggedIn)
                    App.GoToMainPage();
            }
        }

        public static async Task<bool> TryLoginAsync()
        {
            var authentication = DependencyService.Get<IAuthenticator>();
            authentication.ClearCookies();

            var dataStore = DependencyService.Get<IDataStore<Item>>() as AzureDataStore;
            await dataStore.InitializeAsync();

            if (dataStore.UseAuthentication)
            {
                var user = await authentication.LoginAsync(dataStore.MobileService, dataStore.AuthProvider, App.LoginParameters);
                if (user == null)
                {
                    MessagingCenter.Send(new MessagingCenterAlert
                    {
                        Title = "Sign In Error",
                        Message = "Unable to sign in, please check your credentials and try again.",
                        Cancel = "OK"
                    }, "message");
                    return false;
                }

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId ?? string.Empty;
            }

            return true;
        }
    }
}