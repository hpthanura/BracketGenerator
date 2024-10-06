using BracketGenerator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.TournamentFactory
{
    public class ConcreteTournamentFactory : TournamentFactory
    {
        private readonly IGroupMatchService _groupMatchService;
        private readonly IEliminationMatchService _eliminationMatchService;
        private readonly ITournamentService _tournamentService;

        public ConcreteTournamentFactory(IGroupMatchService groupMatchService, ITournamentService tournamentService, IEliminationMatchService eliminationMatchService)
        {
            _groupMatchService = groupMatchService;
            _tournamentService = tournamentService;
            _eliminationMatchService = eliminationMatchService;
        }

        public override ITournamentFactory GetMatchTypeFactory(string matchType)
        {
            switch (matchType)
            {
                case "Elimination":
                    return new EliminationMatch(_eliminationMatchService);
                case "Group":
                    return new GroupMatch(_groupMatchService);
                default:
                    throw new ApplicationException(string.Format("Unknow Match Type '{0}' cannot be created", matchType));
            }
        }
    }
}
