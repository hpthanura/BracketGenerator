using BracketGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services.Interfaces
{
    public interface ITeamService
    {
        public List<Team> SeedTeams(int numberOfTeams, int groupSize);
    }
}
