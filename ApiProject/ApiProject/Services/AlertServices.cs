using Acr.UserDialogs;
using ApiProject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public class AlertServices : IAlertServices
    {
        public Task ActionSheet(string title, string[] options)
        {
             
            return App.Current.MainPage.DisplayActionSheet(title, "cancel", null, options);
        }

        public Task AlertAsync(string title, string description)
        {
            return UserDialogs.Instance.AlertAsync(description, title );
        }
    }
}
