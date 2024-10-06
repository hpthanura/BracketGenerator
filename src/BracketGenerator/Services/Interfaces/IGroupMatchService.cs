using BracketGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services.Interfaces
{
    public interface IGroupMatchService
    {
        public void InitiateGroupMatches(int noOfTeams, int groupSize);
        public List<Tuple<string, List<Match>>> GetGroupMatches();
        public List<Tuple<string, List<Team>>> GetWinnersByGroup();
        public List<Team> GetGroupWinners();
        public void LogGroupMatchResult();
    }
}
