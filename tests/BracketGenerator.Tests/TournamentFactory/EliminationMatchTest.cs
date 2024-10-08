using BracketGenerator.Services.Interfaces;
using BracketGenerator.TournamentFactory;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Tests.TournamentFactory
{
    [TestFixture]
    public class EliminationMatchTest
    {
        [Test]
        public void InitiateTournament_CallsEliminationMatchService()
        {
            // Arrange
            int numberOfTeams = 32;
            int groupSize = 4;
            var elimonationMatchServiceMock = new Mock<IEliminationMatchService>();
            var elimonationMatch = new EliminationMatch(elimonationMatchServiceMock.Object);

            // Act
            elimonationMatch.InitiateTournament(numberOfTeams, groupSize);

            // Assert
            elimonationMatchServiceMock.Verify(service => service.InitiateEliminationMatches(numberOfTeams, groupSize), Times.Once);
        }
    }
}
