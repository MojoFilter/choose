using System.Collections.Generic;

using Choose.Helpers;
using Choose.Services;
using Choose.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ReactiveUI;
using System;
using Splat;
using Choose.ViewModels;
using ReactiveUI.XamForms;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Choose
{
    public partial class App : Application, IScreen
    {
        public static App CurrentApp => Current as App;

        //MUST use HTTPS, neglecting to do so will result in runtime errors on iOS
        public static bool AzureNeedsSetup => AzureMobileAppUrl == "https://CONFIGURE-THIS-URL.azurewebsites.net";
        public static string AzureMobileAppUrl = "https://Choose20170609083751.azurewebsites.net";
        public static IDictionary<string, string> LoginParameters => null;


        public App(Stream importImage = null)
        {
            InitializeComponent();
            this.Router.ThrownExceptions.Subscribe(ex => Debugger.Break());
            this.Router.Navigate.ThrownExceptions.Subscribe(ex => Debugger.Break());

            var di = Locator.CurrentMutable;
            di.RegisterConstant<IScreen>(this);

            void AssignView<TViewModel, TView>() where TView : new()
                                             where TViewModel : class
              => Locator.CurrentMutable.Register<IViewFor<TViewModel>>(() => new TView());

            AssignView<LoginViewModel, LoginPage>();
            AssignView<AboutViewModel, AboutPage>();
            AssignView<ItemsViewModel, ItemsPage>();
            AssignView<ImageTestViewModel, ImageTestPage>();

            if (AzureNeedsSetup)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            IRoutableViewModel startModel;
            if (importImage != null)
            {
                startModel = vmFactory.NewImageTestViewModel(importImage);
            }
            else
            {
                startModel = vmFactory.NewLoginViewModel();
            }
            

            Navigate(startModel);
            Current.MainPage = new RoutedViewHost() { Router = this.Router };
        }

        private readonly ViewModelFactory vmFactory = new ViewModelFactory();

        public RoutingState Router { get; set; } = new RoutingState();
        

        public void SetStartPage()
        {
            if (!AzureNeedsSetup && !Settings.IsLoggedIn)
            {
                Navigate(new LoginViewModel());
            }
            else
            {
                GoToMainPage();
            }
        }

      
        public static void GoToMainPage() => Navigate(CurrentApp.vmFactory.NewLoginViewModel());

        public static void Navigate<T>(T viewModel) where T : IRoutableViewModel
            => CurrentApp.Router.Navigate.Execute(viewModel);
    }
}
