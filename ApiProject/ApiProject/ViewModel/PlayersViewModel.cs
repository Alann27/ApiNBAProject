using ApiProject.Models;
using ApiProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using ApiProject.Views;

namespace ApiProject.ViewModel
{
    public class PlayersViewModel : BaseViewModel
    {
        private ObservableCollection<Team> TeamList { get; set; } 
        public ObservableCollection<Player> ActivePlayers { get; set; } 
        public ObservableCollection<Player> AllActivePlayers { get; set; }
        public string PlayersFilter { get; set; }
        public bool InternetConnection { get; set; }
        public bool ShowError => !InternetConnection;
        public ICommand SelectedPlayerCommand { get; }
        public ICommand SearcherCommand { get; }
        public ICommand ClearCommand { get; }


        public PlayersViewModel(IAlertServices alertServices, INavigationServices navigationServices,INbaApiService nbaApiServices):base(alertServices, navigationServices, nbaApiServices)
        {
            GetActivePlayers();
            GetActiveTeams();

            SelectedPlayerCommand = new Command<Player>(OnSelectecPlayer);
            SearcherCommand = new Command(OnSearcher);
            ClearCommand = new Command(OnClear);
        }

        private async void GetActiveTeams()
        {
            Teams teams = await NbaApiServices.GetTeams();

            if (teams != null)
            {
                TeamList = new ObservableCollection<Team>(teams.League.Standard);
                InternetConnection = true;
            }
            else
            {
                InternetConnection = false;
                await AlertServices.AlertAsync("Error", "No hay conexión a internet");
            }
        }

        private async void OnSelectecPlayer(Player player)
        {
            Team team = TeamList.First(t => t.TeamId == player.TeamId);
            await NavigationServices.NonModalPush(new PlayerInfoDetailPage(player, team));
        }

        private void OnClear()
        {
            if (!string.IsNullOrEmpty(PlayersFilter))
            {
                if (ActivePlayers != AllActivePlayers)
                {
                    ActivePlayers = AllActivePlayers;
                }
                PlayersFilter = "";

            }
        }

        private void OnSearcher()
        {
            if (!string.IsNullOrEmpty(PlayersFilter))
            {
                List<Player> filteredPlayers = AllActivePlayers.Where(player => (player.FirstName.ToLower() + " " + player.LastName.ToLower()).Contains(PlayersFilter.ToLower())).ToList();
                ActivePlayers = new ObservableCollection<Player>(filteredPlayers);
            }
            else
            {
                if (ActivePlayers != AllActivePlayers)
                {
                    ActivePlayers = AllActivePlayers;
                }
            }
        }

        private async void GetActivePlayers()
        {
            Players players = new Players();
            players = await NbaApiServices.GetNbaPlayers();

            if (players != null)
            {
                List<Player> activlePlayersList = players.League.Standard.Where(player => player.IsActive == true).ToList();
                ActivePlayers = new ObservableCollection<Player>(activlePlayersList);
                AllActivePlayers = new ObservableCollection<Player>(activlePlayersList);
                InternetConnection = true;
            }
            else
            {
                InternetConnection = false;
                await AlertServices.AlertAsync("Error", "No hay conexión a internet");
            }

        }
    }
}
