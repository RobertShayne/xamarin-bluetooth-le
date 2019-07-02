using MvvmCross.Forms.Core;
using MvvmCross;
using MvvmCross.Logging;

namespace BLE.Client
{
    public partial class BleMvxFormsApp : MvxFormsApplication
    {
        private readonly IMvxLog _log;

        public BleMvxFormsApp()
        {
            _log = Mvx.IoCProvider.Resolve<IMvxLog>();
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
            _log.Trace("App Start");
        }

        protected override void OnResume()
        {
            base.OnResume();
            _log.Trace("App Resume");
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            _log.Trace("App Sleep");
        }
    }
}
