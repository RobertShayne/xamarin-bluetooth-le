﻿using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using MvvmCross.ViewModels;
using MvvmCross;
using Plugin.BLE.Abstractions.Contracts;
using MvvmCross.Logging;
using MvvmCross.Navigation;

namespace BLE.Client.ViewModels
{
    public class ServiceListViewModel : BaseViewModel
    {
        private readonly IUserDialogs _userDialogs;
        private IDevice _device;

        public IList<IService> Services { get; private set; }
        public ServiceListViewModel(IAdapter adapter, IUserDialogs userDialogs, IMvxLog log, IMvxNavigationService navigationService) : base(adapter,log, navigationService)
        {
            _userDialogs = userDialogs;
        }

        public override void Resume()
        {
            base.Resume();

            LoadServices();
        }

        private async void LoadServices()
        {
            try
            {
                _userDialogs.ShowLoading("Discovering services...");

                Services = await _device.GetServicesAsync();
                RaisePropertyChanged(() => Services);
            }
            catch (Exception ex)
            {
                _userDialogs.Alert(ex.Message, "Error while discovering services");
                _log.Trace(ex.Message);
            }
            finally
            {
                _userDialogs.HideLoading();
            }
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            _device = GetDeviceFromBundle(parameters);

            if (_device == null)
            {
                Close(this);
            }
        }


        public IService SelectedService
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    var bundle = new MvxBundle(new Dictionary<string, string>(Bundle.Data) { { ServiceIdKey, value.Id.ToString() } });
                    ShowViewModel<CharacteristicListViewModel>(bundle);
                }

                RaisePropertyChanged();

            }
        }
    }
}