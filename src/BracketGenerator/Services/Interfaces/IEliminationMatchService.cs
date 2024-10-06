using BracketGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services.Interfaces
{
    public interface IEliminationMatchService
    {
        public void InitiateEliminationMatches(int noOfTeams, int groupSize);
    }
}
