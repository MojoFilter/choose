using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Choose.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel() : base("About")
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
