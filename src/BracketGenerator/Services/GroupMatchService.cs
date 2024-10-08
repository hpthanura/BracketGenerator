using BracketGenerator.Models;
using BracketGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services
{
    public class GroupMatchService : IGroupMatchService
    {
        private readonly ITeamService _teamService;
        private readonly ITournamentService _tournamnetService;
        private readonly ILogService _logService;
        List<Match> allMatches = new List<Match>();
        private List<Tuple<string, List<Team>>> groupTeams = new List<Tuple<string, List<Team>>>();
        private List<Tuple<string, List<Match>>> groupMatches = new List<Tuple<string, List<Match>>>();

        public GroupMatchService(ITeamService teamService, ITournamentService tournamnetService, ILogService logService)
        {
            _teamService = teamService;
            _tournamnetService = tournamnetService;
            _logService = logService;
        }

        public void InitiateGroupMatches(int noOfTeams, int groupSize)
        {
            groupTeams.Clear();
            groupMatches.Clear();
            allMatches.Clear();
            List<Team> teams = _teamService.SeedTeams(noOfTeams, groupSize);
            int groupNumber = 1;
            for (int i = 0; i < teams.Count; i += groupSize)
            {
                string groupName = "Group " + groupNumber;
                groupTeams.Add(new Tuple<string, List<Team>>(groupName, teams.GetRange(i, groupSize)));
                StartGruopMatches(groupName, teams.GetRange(i, groupSize));
                groupNumber++;
            }
            LogGroupMatchResult();
            _tournamnetService.StartTournament(GetGroupWinners());

        }

        private void StartGruopMatches(string groupName, List<Team> teams)
        {
            int matchNumber = 1;
            List<Match> matches = new List<Match>();
            foreach (Team team in teams)
            {
                foreach (Team oponent in teams)
                {
                    if (team != oponent && (!(allMatches.Exists(match => match.FirstTeam == team && match.SecondTeam == oponent) ||
                            allMatches.Exists(match => match.FirstTeam == oponent && match.SecondTeam == team))))
                    {
                        string matchName = groupName + " Match " + matchNumber.ToString();
                        Match groupMatch = new Match(matchName, team, oponent);
                        groupMatch.StartMatch();
                        matches.Add(groupMatch);
                        allMatches.Add(groupMatch);
                        matchNumber++;
                    }

                }
            }
            groupMatches.Add(new Tuple<string, List<Match>>(groupName, matches));
        }

        public List<Team> GetGroupWinners()
        {
            List<Team> winners = new List<Team>();
            foreach (var groupTeam in groupTeams)
            {
                winners.AddRange(groupTeam.Item2.OrderByDescending(team => team.Points).ToList().GetRange(0, 2));
            }
            return winners;
        }

        public List<Tuple<string, List<Team>>> GetWinnersByGroup()
        {
            List<Tuple<string, List<Team>>> winners = new List<Tuple<string, List<Team>>>();
            foreach (var groupTeam in groupTeams)
            {
                winners.Add(new Tuple<string, List<Team>>(groupTeam.Item1, groupTeam.Item2.OrderByDescending(team => team.Points).ToList().GetRange(0, 2)));
            }
            return winners;
        }

        public List<Tuple<string, List<Match>>> GetGroupMatches()
        {
            return groupMatches;
        }

        public void LogGroupMatchResult()
        {
            _logService.WriteLine("*************Group Matches*************");
            foreach (var group in GetGroupMatches())
            {
                Console.WriteLine("Group Name - " + group.Item1.ToString());
                foreach (var match in group.Item2)
                {
                    Console.WriteLine("{0} \t {1} \t {2} is the winner", match.Name, match.FirstTeam.Name + " VS " + match.SecondTeam.Name, match.Winner?.Name);
                }

            }
            _logService.WriteBlank();
            _logService.WriteLine("*************Group Winners*************");
            foreach (var group in GetWinnersByGroup())
            {
                Console.WriteLine("Group Name - " + group.Item1.ToString());
                foreach (var team in group.Item2)
                {
                    Console.WriteLine("{0} with points {1} ", team.Name, team.Points);
                }

            }
            _logService.WriteBlank();
        }

    }
}
