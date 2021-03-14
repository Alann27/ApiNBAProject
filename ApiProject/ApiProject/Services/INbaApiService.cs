using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public interface INbaApiService
    {
        Task<Players> GetNbaPlayers();
        Task<Teams> GetTeams();
    }
}
