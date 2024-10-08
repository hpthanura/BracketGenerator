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
    public class GroupMatchTest
    {
        [Test]
        public void InitiateTournament_CallsGroupMatchService()
        {
            // Arrange
            int numberOfTeams = 32;
            int groupSize = 4;
            var groupMatchServiceMock = new Mock<IGroupMatchService>();
            var groupMatch = new GroupMatch(groupMatchServiceMock.Object);

            // Act
            groupMatch.InitiateTournament(numberOfTeams, groupSize);

            // Assert
            groupMatchServiceMock.Verify(service => service.InitiateGroupMatches(numberOfTeams, groupSize), Times.Once);
        }
    }
}
