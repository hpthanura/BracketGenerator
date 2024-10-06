using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Models
{
    public class Match
    {
        public string Name { get; set; }
        public Team FirstTeam {  get; set; }
        public Team SecondTeam { get; set; }
        public Team? Winner { get; set; }

        public Match(string name, Team team1, Team team2)
        {
            Name = name;
            FirstTeam = team1;
            SecondTeam = team2;
        }

        public void StartMatch()
        {
            Random random = new();
            Winner = random.Next(2) == 0 ? FirstTeam : SecondTeam;
            Winner.Points++;
        }
    }
}
