using BracketGenerator.Models;
using BracketGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services
{
    public class EliminationMatchService : IEliminationMatchService
    {
        private readonly ITournamentService _tournamentService;

        public EliminationMatchService(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public void InitiateEliminationMatches(int noOfTeams, int groupSize)
        {
            _tournamentService.StartTournament(noOfTeams, groupSize);
        }
    }
}
