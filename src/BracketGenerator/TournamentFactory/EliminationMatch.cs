using BracketGenerator.Models;
using BracketGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.TournamentFactory
{
    public class EliminationMatch : ITournamentFactory
    {
        private readonly IEliminationMatchService _eliminationMatchService;

        public EliminationMatch(IEliminationMatchService eliminationMatchService)
        {
            _eliminationMatchService = eliminationMatchService;
        }

        public void InitiateTournament(int noOfTeams, int groupSize)
        {
            _eliminationMatchService.InitiateEliminationMatches(noOfTeams, groupSize);
        }
    }
}
