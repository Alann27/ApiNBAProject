using ApiProject.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    interface IRefitNbaApiService
    {
        [Get("/data/10s/prod/v1/{year}/players.json")]
        Task<HttpResponseMessage> GetNbaPlayers(string year);
        [Get("/data/10s/prod/v1/{year}/teams.json")]
        Task<HttpResponseMessage> GetTeams(string year);
    }
}
