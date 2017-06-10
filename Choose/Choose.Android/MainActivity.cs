
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System.IO;
using System.Linq;

namespace Choose.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionSend, Intent.ActionSendto },
        Categories = new[] { Intent.CategoryDefault },
        DataMimeTypes = new[] { "image/jpg", "image/jpeg", "image/png", "image/gif" })]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Stream importFile = null;
            if (new[] { Intent.ActionSend, Intent.ActionSendto }.Contains(Intent.Action))
            {
                // Get the info from ClipData 
                var image = Intent.ClipData.GetItemAt(0);

                // Open a stream from the URI 
                var imageStream = ContentResolver.OpenInputStream(image.Uri);
                importFile = imageStream;

                // Save it over 
                //var memOfPdf = new System.IO.MemoryStream();
                //imageStream.CopyTo(memOfPdf);
                //var docsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                //var filePath = System.IO.Path.Combine(docsPath, "temp.jpg");

                //System.IO.File.WriteAllBytes(filePath, memOfPdf.ToArray());

                //importFile = filePath;
            }

            var app = new App(importFile);
            LoadApplication(app);
        }
    }
}
