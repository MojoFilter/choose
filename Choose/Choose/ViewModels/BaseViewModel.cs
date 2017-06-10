using System;
using Choose.Helpers;
using Choose.Models;
using Choose.Services;
using ReactiveUI;
using Xamarin.Forms;
using Splat;

namespace Choose.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject, IRoutableViewModel
    {
        public BaseViewModel(string urlPathSegment)
        {
            this.UrlPathSegment = urlPathSegment;
        }

        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { this.RaiseAndSetIfChanged(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { this.RaiseAndSetIfChanged(ref title, value); }
        }

        public string UrlPathSegment { get; }

        public IScreen HostScreen => Locator.Current.GetService<IScreen>();
    }
}

