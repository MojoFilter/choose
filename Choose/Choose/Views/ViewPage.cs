using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Choose.Views
{
    public abstract class ViewContentPage<T> : ContentPage, IViewFor<T> where T : class
    {

        public ViewContentPage()
        {
            this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.BindingContext);
        }

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(T), typeof(ViewContentPage<T>));

        public T ViewModel
        {
            get => (T)this.GetValue(ViewModelProperty);
            set => this.SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => this.ViewModel;
            set => this.ViewModel = value as T;
        }
    }
}
