using ApiProject.Models;
using ApiProject.Services;
using ApiProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApiProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayersPage : ContentPage
    {
        public PlayersPage()
        {
            InitializeComponent();

            BindingContext = new PlayersViewModel(new AlertServices(), new NavigationServices(), new NbaApiService());
        }
    }
}