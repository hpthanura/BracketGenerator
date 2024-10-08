using BracketGenerator.Services.Interfaces;
using BracketGenerator.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BracketGenerator.Models;

namespace BracketGenerator.Tests
{
    public class EliminationMatchServiceTest
    {
        private Mock<ITournamentService> _mockTournamentService;
        private EliminationMatchService _eliminationMatchService;

        [SetUp]
        public void Setup()
        {
            _mockTournamentService = new Mock<ITournamentService>();
            _eliminationMatchService = new EliminationMatchService(_mockTournamentService.Object);
        }

        [Test]
        public void Constructor_ShouldInitializeTournamentService()
        {
            // Assert
            Assert.IsNotNull(_eliminationMatchService);
        }

        [Test]
        public void InitiateEliminationMatches_ShouldCallStartTournament_WithCorrectParameters()
        {
            // Arrange
            int noOfTeams = 8;
            int groupSize = 4;

            // Act
            _eliminationMatchService.InitiateEliminationMatches(noOfTeams, groupSize);

            // Assert
            _mockTournamentService.Verify(ts => ts.StartTournament(noOfTeams, groupSize), Times.Once);
        }
    }
}
