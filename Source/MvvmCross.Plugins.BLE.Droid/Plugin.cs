using MvvmCross;
using MvvmCross.Logging;
using MvvmCross.Plugin;
using MvvmCross.IoC;
using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;

namespace MvvmCross.Plugins.BLE.Droid
{
    public class Plugin
     : IMvxPlugin
    {
        private readonly IMvxLog _log;
        public Plugin(IMvxLogProvider logProvider)
        {
            _log = logProvider.GetLogFor<Plugin>();
            Trace.TraceImplementation = _log.Trace;// Mvx.Trace;
        }
        public void Load()
        {
            _log.Trace("Loading bluetooth low energy plugin");
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IBluetoothLE>(() => CrossBluetoothLE.Current);
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IAdapter>(() => Mvx.IoCProvider.Resolve<IBluetoothLE>().Adapter);
        }
    }
}