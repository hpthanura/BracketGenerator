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
        private readonly ITeamService _teamService;
        private readonly ITournamentService _tournamentService;

        public EliminationMatchService(ITeamService teamService, ITournamentService tournamentService)
        {
            _teamService = teamService;
            _tournamentService = tournamentService;
        }

        public void InitiateEliminationMatches(int noOfTeams, int groupSize)
        {
            _tournamentService.StartTournament(noOfTeams, groupSize);
        }
    }
}
