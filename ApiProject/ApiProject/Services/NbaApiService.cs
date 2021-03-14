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

        //public async Task<Players> GetNbaPlayers()
        //{
        //    Players players = null;
        //    HttpClient client = new HttpClient();

        //    string urlApi = $"http://data.nba.net/data/10s/prod/v1/{DateTime.Today.Year - 1}/players.json";

        //    var playersResponse = await client.GetAsync(urlApi);

        //    if (playersResponse.IsSuccessStatusCode)
        //    {
        //        var jsonPlayers = await playersResponse.Content.ReadAsStringAsync();
        //        players = JsonSerializer.Deserialize<Players>(jsonPlayers);
        //    }

        //    return players;
        //}

        //public async Task<Teams> GetTeams()
        //{

        //    Teams teams = null;

        //    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        //    {
        //        HttpClient client = new HttpClient();

        //        string urlApi = $"http://data.nba.net/data/10s/prod/v1/{DateTime.Today.Year - 1}/teams.json";

        //        var teamsResponse = await client.GetAsync(urlApi);

        //        if (teamsResponse.IsSuccessStatusCode)
        //        {
        //            var jsonTeams = await teamsResponse.Content.ReadAsStringAsync();
        //            teams = JsonSerializer.Deserialize<Teams>(jsonTeams);
        //        }


        //    }

        //    return teams;

        //}

        public async Task<Players> GetNbaPlayers()
        {
            Players players = null;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var refitClient = RestService.For<IRefitNbaApiService>("http://data.nba.net");

                var playersResponse = await refitClient.GetNbaPlayers((DateTime.Today.Year - 1).ToString());

                if (playersResponse.IsSuccessStatusCode)
                {
                    var jsonPlayers = await playersResponse.Content.ReadAsStringAsync();
                    players = JsonSerializer.Deserialize<Players>(jsonPlayers);
                }

            }

            return players;
        }

        public async Task<Teams> GetTeams()
        {

            Teams teams = null;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var refitClient = RestService.For<IRefitNbaApiService>("http://data.nba.net");

                var teamsResponse = await refitClient.GetTeams((DateTime.Today.Year - 1).ToString());

                if (teamsResponse.IsSuccessStatusCode)
                {
                    var jsonTeams = await teamsResponse.Content.ReadAsStringAsync();
                    teams = JsonSerializer.Deserialize<Teams>(jsonTeams);
                }
            }

            return teams;

        }
    }
}
