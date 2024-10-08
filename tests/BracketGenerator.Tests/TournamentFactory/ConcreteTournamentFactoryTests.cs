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
    public class ConcreteTournamentFactoryTests
    {
        [Test]
        public void GetMatchTypeFactory_ReturnsEliminationMatchFactory()
        {
            // Arrange
            IEliminationMatchService eliminationService = new Mock<IEliminationMatchService>().Object;
            IGroupMatchService groupService = new Mock<IGroupMatchService>().Object;
            ConcreteTournamentFactory factory = new ConcreteTournamentFactory(groupService, eliminationService);

            // Act
            ITournamentFactory tournamentFactory = factory.GetMatchTypeFactory("Elimination");

            // Assert
            Assert.IsInstanceOf<EliminationMatch>(tournamentFactory);
        }

        [Test]
        public void GetMatchTypeFactory_ReturnsGroupMatchFactory()
        {
            // Arrange
            IEliminationMatchService eliminationService = new Mock<IEliminationMatchService>().Object;
            IGroupMatchService groupeService = new Mock<IGroupMatchService>().Object;
            ConcreteTournamentFactory factory = new ConcreteTournamentFactory(groupeService, eliminationService);

            // Act
            ITournamentFactory tournamentFactory = factory.GetMatchTypeFactory("Group");

            // Assert
            Assert.IsInstanceOf<GroupMatch>(tournamentFactory);
        }

        //[Test]
        //public void GetGameMethodFactory_ThrowsExceptionForInvalidTournamentType()
        //{
        //    // Arrange
        //    ISingleEliminationStageService singleEliminationService = new Mock<ISingleEliminationStageService>().Object;
        //    IGroupStageService groupStageService = new Mock<IGroupStageService>().Object;
        //    ConcreteTournamentFactory factory = new ConcreteTournamentFactory(singleEliminationService, groupStageService);

        //    // Act and Assert
        //    Assert.Throws<ApplicationException>(() => factory.GetGameMethodFactory("InvalidTournamentType"));
        //}
    }
}
