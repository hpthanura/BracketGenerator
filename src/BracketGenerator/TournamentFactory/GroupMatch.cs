using BracketGenerator.Models;
using BracketGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.TournamentFactory
{
    public class GroupMatch : ITournamentFactory
    {
        private readonly IGroupMatchService _groupMatchService;

        public GroupMatch(IGroupMatchService groupMatchService)
        {
            _groupMatchService = groupMatchService;
        }

        public void InitiateTournament(int noOfTeams, int groupSize)
        {
            _groupMatchService.InitiateGroupMatches(noOfTeams, groupSize);
        }
    }
}
