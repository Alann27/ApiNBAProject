using ApiProject.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ApiProject.Services
{
    public class NbaApiService : INbaApiService
    {

        public async Task<Players> GetNbaPlayers()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                Players players = null;
                var refitClient = RestService.For<IRefitNbaApiService>("http://data.nba.net");

                var playersResponse = await refitClient.GetNbaPlayers((DateTime.Today.Year - 1).ToString());

                if (playersResponse.IsSuccessStatusCode)
                {
                    var jsonPlayers = await playersResponse.Content.ReadAsStringAsync();
                    players = JsonSerializer.Deserialize<Players>(jsonPlayers);
                }

                return players;

            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<Teams> GetTeams()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                Teams teams = null;

                var refitClient = RestService.For<IRefitNbaApiService>("http://data.nba.net");

                var teamsResponse = await refitClient.GetTeams((DateTime.Today.Year - 1).ToString());

                if (teamsResponse.IsSuccessStatusCode)
                {
                    var jsonTeams = await teamsResponse.Content.ReadAsStringAsync();
                    teams = JsonSerializer.Deserialize<Teams>(jsonTeams);
                }

                return teams;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
