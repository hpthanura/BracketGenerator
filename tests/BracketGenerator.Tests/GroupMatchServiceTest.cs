using BracketGenerator.Models;
using BracketGenerator.Services;
using BracketGenerator.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Tests
{
    [TestFixture]
    public class GroupMatchServiceTests
    {
        private Mock<ITeamService> _mockTeamService;
        private Mock<ITournamentService> _mockTournamentService;
        private Mock<ILogService> _mockLogService;
        private GroupMatchService _groupMatchService;

        [SetUp]
        public void Setup()
        {
            _mockTeamService = new Mock<ITeamService>();
            _mockTournamentService = new Mock<ITournamentService>();
            _mockLogService = new Mock<ILogService>();

            _groupMatchService = new GroupMatchService(_mockTeamService.Object, _mockTournamentService.Object, _mockLogService.Object);
        }

        [Test]
        public void InitiateGroupMatches_ShouldCallStartTournament()
        {
            // Arrange
            int noOfTeams = 6;
            int groupSize = 3;
            var seededTeams = new List<Team>
                {
                    new Team ("Team 1", 1),
                    new Team ("Team 2", 2),
                    new Team ("Team 3", 3),
                    new Team ("Team 4", 4),
                    new Team ("Team 5", 5),
                    new Team ("Team 6", 6)
                };
            _mockTeamService.Setup(ts => ts.SeedTeams(noOfTeams, groupSize)).Returns(seededTeams);

            // Act
            _groupMatchService.InitiateGroupMatches(noOfTeams, groupSize);

            // Assert
            _mockTeamService.Verify(ts => ts.SeedTeams(noOfTeams, groupSize), Times.Once);
            _mockTournamentService.Verify(ts => ts.StartTournament(It.IsAny<List<Team>>()), Times.Once);
            Assert.IsNotEmpty(_groupMatchService.GetGroupMatches());
        }

        [Test]
        public void GetGroupWinners_ShouldReturnTopTwoTeamsFromEachGroup()
        {
            // Arrange
            var groupTeams = new List<Tuple<string, List<Team>>>
                {
                    new Tuple<string, List<Team>>("Group 1", new List<Team>
                    {
                        new Team ("Team A", 1),
                        new Team ("Team B", 2),
                        new Team ("Team C", 3)
                    })
                };

            int point = 1;
            foreach (var team in groupTeams[0].Item2)
            {
                team.Points = point;
                point++;
            }
            // Manually set the private field using reflection or an accessible method
            _groupMatchService.GetType()
                .GetField("groupTeams", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(_groupMatchService, groupTeams);

            // Act
            var winners = _groupMatchService.GetGroupWinners();

            // Assert
            Assert.AreEqual(2, winners.Count);
            Assert.AreEqual("Team C", winners[0].Name);
            Assert.AreEqual("Team B", winners[1].Name);
        }

        [Test]
        public void LogGroupMatchResult_ShouldLogCorrectInformation()
        {
            // Act
            _groupMatchService.LogGroupMatchResult();

            // Assert
            _mockLogService.Verify(ls => ls.WriteLine(It.IsAny<string>()), Times.AtLeastOnce);
        }
    }
}
