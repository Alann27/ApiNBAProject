using ApiProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiProject.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public INbaApiService NbaApiServices { get; }
        public IAlertServices AlertServices { get; }
        public INavigationServices NavigationServices { get; }

        protected BaseViewModel(IAlertServices alertServices, INavigationServices navigationServices,INbaApiService nbaApiService)
        {
            AlertServices = alertServices;
            NavigationServices = navigationServices;
            NbaApiServices = nbaApiService;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
