using Acr.UserDialogs;
using Android.Content;
using MvvmCross;
using Plugin.Settings;
using Plugin.Permissions;
using MvvmCross.ViewModels;
using MvvmCross.Presenters;
using MvvmCross.Platforms.Android.Core;

namespace BLE.Client.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base()
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new BleMvxApplication();
        }

        /*
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new MvxFormsDroidPagePresenter();
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);
            return presenter;
        }

    */
        protected override void InitializeIoC()
        {
            base.InitializeIoC();

            Mvx.RegisterSingleton(() => UserDialogs.Instance);
            Mvx.RegisterSingleton(() => CrossSettings.Current);
            Mvx.RegisterSingleton(() => CrossPermissions.Current);
        }
    }
}
