using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using MvvmCross;
using MvvmCross.Presenters;
using MvvmCross.Forms.Presenters;

namespace BLE.Client.Droid
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity
        : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;

            base.OnCreate(bundle);

            UserDialogs.Init(this);
            Forms.Init(this, bundle);
            var formsApp = new BleMvxFormsApp();
            LoadApplication(formsApp);

            var presenter = (MvxFormsPagePresenter) Mvx.IoCProvider.Resolve<IMvxViewPresenter>();
            presenter.FormsApplication = formsApp;

            Mvx.IoCProvider.Resolve<IMvxAppStart>().Start();
        }
    }
}