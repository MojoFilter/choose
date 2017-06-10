using Choose.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Choose.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageTestPage : ContentPage, IViewFor<ImageTestViewModel>
    {
        public ImageTestPage()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.Source, v => v.imageView.Source);
        }
        
        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(ImageTestViewModel), typeof(LoginPage));

        public ImageTestViewModel ViewModel
        {
            get => (ImageTestViewModel)this.GetValue(ViewModelProperty);
            set => this.SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => this.ViewModel;
            set => this.ViewModel = value as ImageTestViewModel;
        }
    }
}