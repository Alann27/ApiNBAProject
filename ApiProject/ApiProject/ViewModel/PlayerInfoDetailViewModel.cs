using ApiProject.Models;
using ApiProject.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProject.ViewModel
{
    public class PlayerInfoDetailViewModel : BaseViewModel
    {
        public Player Player { get; }
        public Team Team { get; }
        public string PlayerFullName { get; }
        public string PlayerHeight { get; }
        public string ActualTeamInfo { get; }
        public string YearDebutActualTeam { get; }
        public PlayerInfoDetailViewModel(Player player, Team team, IAlertServices alertServices, INavigationServices navigationServices, INbaApiService nbaApiService) : base(alertServices, navigationServices, nbaApiService)
        {
            Player = player;
            Team = team;

            PlayerFullName = player.FirstName + " " + player.LastName;
            PlayerHeight = $"{player.HeightFeet}.{player.HeightInches}";

            ActualTeamInfo = $"In {team.FullName} since: ";
            YearDebutActualTeam = player.Teams[player.Teams.Count - 1].SeasonStart;
        }


    }
}
