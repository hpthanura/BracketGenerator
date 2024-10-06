using BracketGenerator.Models;
using BracketGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services
{
    public class TeamService : ITeamService
    {
        public List<Team> SeedTeams(int numberOfTeams, int groupSize)
        {   
            //current team name generation supports up to 104 meaningful team names
            var teams = new List<Team>();
            int teamNo = 1;
            char teamGroup = 'A';
            for (int i = 1; i <= numberOfTeams; i++)
            {
                Team team = new Team(teamGroup.ToString() + teamNo.ToString(), i);
                teams.Add(team);
                if (teamNo % groupSize == 0)
                {
                    teamNo = 1;
                    teamGroup++;
                }
                else
                {
                    teamNo++;
                }
            }
            return teams;
        }
    }
}
