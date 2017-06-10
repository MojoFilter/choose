using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choose.ViewModels
{
    class ViewModelFactory
    {
        public LoginViewModel NewLoginViewModel() => new LoginViewModel();
        public ImageTestViewModel NewImageTestViewModel(Stream image) => new ImageTestViewModel(image);
    }
}
