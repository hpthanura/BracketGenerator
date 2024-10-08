using BracketGenerator.Models;
using BracketGenerator.Services.Interfaces;
using BracketGenerator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace BracketGenerator.Tests
{
    [TestFixture]
    public class TournamentServiceTests
    {
        private TournamentService _tournamentService;
        private Mock<ITeamService> _mockTeamService;

        [SetUp]
        public void Setup()
        {
            // Setup a mock for ITeamService
            _mockTeamService = new Mock<ITeamService>();

            // Initialize the TournamentService with the mocked ITeamService
            _tournamentService = new TournamentService(_mockTeamService.Object);
        }

        [Test]
        public void StartTournament_InitializesTournament()
        {
            // Arrange
            int noOfTeams = 8;
            int groupSize = 4;

            // Mock the SeedTeams method to return a list of seeded teams
            _mockTeamService.Setup(x => x.SeedTeams(noOfTeams, groupSize)).Returns(new List<Team>
            {
                new Team ("Team 1", 1),
                new Team ("Team 2", 2),
                new Team ("Team 3", 3),
                new Team ("Team 4", 4),
                new Team ("Team 5", 5),
                new Team ("Team 6", 6),
                new Team ("Team 7", 7),
                new Team ("Team 8", 8)
            });

            // Act
            _tournamentService.StartTournament(noOfTeams, groupSize);

            // Assert
            Assert.AreNotEqual(0, _tournamentService.Teams.Count, "Teams should be initialized correctly.");
            Assert.AreNotEqual(0, _tournamentService.Rounds.Count, "Rounds should be arranged correctly");
        }



        [Test]
        public void StartTournament_NoTeams_ThrowsArgumentException()
        {
            // Arrange
            int noOfTeams = 0;
            int groupSize = 2;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _tournamentService.StartTournament(noOfTeams, groupSize),
                "Starting a tournament with zero teams should throw an exception.");
        }

        [Test]
        public void StartTournament_GetTournamentWinner()
        {
            // Arrange
            int noOfTeams = 8;
            int groupSize = 4;

            // Mock the SeedTeams method to return a list of seeded teams
            _mockTeamService.Setup(x => x.SeedTeams(noOfTeams, groupSize)).Returns(new List<Team>
            {
                new Team ("Team 1", 1),
                new Team ("Team 2", 2),
                new Team ("Team 3", 3),
                new Team ("Team 4", 4),
                new Team ("Team 5", 5),
                new Team ("Team 6", 6),
                new Team ("Team 7", 7),
                new Team ("Team 8", 8)
            });

            // Act
            _tournamentService.StartTournament(noOfTeams, groupSize);

            // Assert
            Assert.AreEqual(1, _tournamentService.Teams.Count, "Teams should be initialized correctly.");
        }
    }
}
