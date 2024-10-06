using BracketGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.TournamentFactory
{
    public interface ITournamentFactory
    {
        void InitiateTournament(int noOfTeams, int groupSize);
    }
}
