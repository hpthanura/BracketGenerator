using BracketGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services.Interfaces
{
    public interface ITournamentService
    {
        public List<Round> Rounds { get; set; }
        public List<Team> Teams { get; set; }
        public void StartTournament(int noOfTeams, int groupSize);
        public void StartTournament(List<Team> teams);
        public Team? GetTournamentWinner();
        public List<Match> PathToVictory();
    }
}
