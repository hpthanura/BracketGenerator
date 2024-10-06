using BracketGenerator.Models;
using BracketGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services
{
    public class TournamentService : ITournamentService
    {
        private ITeamService _teamService;
        public List<Round> Rounds { get; set; } = new List<Round>();
        public List<Team> Teams { get; set; } = new List<Team>();
        public Team? TournamentWinner { get; set; }

        public TournamentService(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public void StartTournament(int noOfTeams, int groupSize)
        {
            Teams.Clear();
            Rounds.Clear();
            Teams = _teamService.SeedTeams(noOfTeams, groupSize);
            int round = 1;
            while (Teams.Count != 1)
            {
                Rounds.Add(StartRoundMatches(round));
                round++;
            }
            TournamentWinner = Teams.FirstOrDefault();
        }

        public void StartTournament(List<Team> teams)
        {
            Teams.Clear();
            Rounds.Clear();
            Teams = teams;
            int round = 1;
            while (Teams.Count != 1)
            {
                Rounds.Add(StartRoundMatches(round));
                round++;
            }
            TournamentWinner = Teams.FirstOrDefault();
        }

        private Round StartRoundMatches(int roundNo)
        {
            Teams = Teams.OrderBy(team => team.Seed).ToList();
            Round round = new Round { Id = roundNo, Name = "Round " + roundNo };
            round.Matches = StartRoundTeamMatches(round.Name);
            return round;
        }

        private List<Match> StartRoundTeamMatches(string roundName)
        {
            List<Match> matches = new List<Match>();
            List<Team> teamsLost = new List<Team>();
            int totalTeams = Teams.Count;
            for (int i = 0; i < totalTeams / 2; i++)
            {
                Team team1 = Teams[i];
                Team team2 = Teams[totalTeams - i - 1];
                Match match = new Match(roundName + " Match " + (i + 1), team1, team2);
                match.StartMatch();
                if (match.Winner == team1)
                {
                    teamsLost.Add(team2);
                }
                else
                {
                    teamsLost.Add(team1);
                }
                matches.Add(match);
            }

            foreach (var losers in teamsLost) { 
                Teams.Remove(losers);
            }
            return matches;
        }

        public Team? GetTournamentWinner()
        {
            return TournamentWinner;
        }

        private List<Match> GetWinningMatches(Team? team)
        {
            List<Match> teamMatches = new List<Match>();
            foreach (var round in Rounds)
            {
                Match? winningMatch = round.Matches.FirstOrDefault(match => match.Winner == team);
                if (winningMatch != null)
                {
                    teamMatches.Add(winningMatch);
                }
            }
            return teamMatches;
        }

        public List<Match> PathToVictory()
        {
            return GetWinningMatches(GetTournamentWinner());
        }

    }
}
