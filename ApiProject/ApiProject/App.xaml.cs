using ApiProject.Services;
using ApiProject.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PlayersPage());
        }

        protected override /*async*/ void OnStart()
        {
            //var nbaApiService = new NbaApiService();
            //var teamInfo = await nbaApiService.GetTeams();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
