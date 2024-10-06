using BracketGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.TournamentFactory
{
    public abstract class TournamentFactory
    {
        public abstract ITournamentFactory GetMatchTypeFactory(string matchType);
    }
}
