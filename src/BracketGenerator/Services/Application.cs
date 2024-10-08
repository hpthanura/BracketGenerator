using BracketGenerator.Services.Interfaces;
using BracketGenerator.TournamentFactory;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services
{
    [ExcludeFromCodeCoverage]
    public class Application : IApplication
    {
        private readonly IGroupMatchService _groupMatchService;
        private readonly ITournamentService _tournamentService;
        private readonly IEliminationMatchService _eliminationMatchService;
        private readonly ILogService _logService;

        public Application(IGroupMatchService groupMatchService, ITournamentService tournamentService, ILogService logService, IEliminationMatchService eliminationMatchService)
        {
            _groupMatchService = groupMatchService;
            _tournamentService = tournamentService;
            _logService = logService;
            _eliminationMatchService = eliminationMatchService;
        }

        public void Main()
        {
            _logService.WriteLine("Welcome to Tournament Bracket Generator");
            int option = 0;
            while (option != 4)
            {
                DisplayOptions();
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    ProcessInput(option);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }
            }

        }

        private TournamentFactory.TournamentFactory CreateTournamentFactory()
        {
            return new ConcreteTournamentFactory(_groupMatchService, _eliminationMatchService);
        }

        private void ProcessInput(int option)
        {
            ITournamentFactory? matchTypeFactory = null;
            int numberOfTeams = 0;
            switch (option)
            {
                case 1:
                    matchTypeFactory = CreateTournamentFactory().GetMatchTypeFactory("Elimination");
                    numberOfTeams = 16;
                    break;
                case 2:
                    matchTypeFactory = CreateTournamentFactory().GetMatchTypeFactory("Elimination");
                    numberOfTeams = 64;
                    break;
                case 3:
                    matchTypeFactory = CreateTournamentFactory().GetMatchTypeFactory("Group");
                    numberOfTeams = 32;
                    break;
                case 4:
                    Console.WriteLine("Exiting application.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }

            if (option == 1 || option == 2 || option == 3)
            {
                matchTypeFactory?.InitiateTournament(numberOfTeams, 4);
                LogMatchResults();
                PathToVictory();
            }
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Soccer World Cup Tournament");
            Console.WriteLine("2. NCAA Soccer Tournament");
            Console.WriteLine("3. Soccer World Cup Tournament With Group Stage");
            Console.WriteLine("4. Exit \n");
            Console.WriteLine("Please enter your selection...");
        }

        private void LogMatchResults()
        {
            _logService.WriteLine("*************Tournament Matches*************");
            foreach (var round in _tournamentService.Rounds)
            {
                Console.WriteLine(round.Name);
                foreach (var match in round.Matches)
                {
                    _logService.WriteLine(String.Format("{0} \t {1} \t {2} is the winner", match.Name, match.FirstTeam.Name + " VS " + match.SecondTeam.Name, match.Winner?.Name));
                }
                _logService.WriteBlank();
            }

            _logService.WriteLine(_tournamentService.GetTournamentWinner()?.Name + " is the Tournament Winner!");
            _logService.WriteBlank();
        }

        private void PathToVictory()
        {
            _logService.WriteLine("*************Path to Victory*************");
            foreach (var match in _tournamentService.PathToVictory())
            {
                _logService.WriteLine(String.Format("{0} \t {1} \t {2} is the winner", match.Name, match.FirstTeam.Name + " VS " + match.SecondTeam.Name, match.Winner?.Name));
            }
        }
    }
}
