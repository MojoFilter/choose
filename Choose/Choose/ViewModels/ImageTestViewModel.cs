using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Choose.ViewModels
{
    public class ImageTestViewModel : BaseViewModel
    {
        public ImageTestViewModel(Stream image) : base("ImageTest")
        {
            this.Source = ImageSource.FromStream(() => image);
        }

        public ImageSource Source { get; }
    }
}
