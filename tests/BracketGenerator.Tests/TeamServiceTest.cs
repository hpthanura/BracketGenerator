using BracketGenerator.Models;
using BracketGenerator.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Tests
{
    [TestFixture]
    public class TeamServiceTest
    {
        [Test]
        public void Test_SeedTeams()
        {
            TeamService teamService = new TeamService();
            int teamsCount = 16;
            int groups = 4;

            List<Team> teams = teamService.SeedTeams(teamsCount, groups);

            Assert.AreEqual(16,teams.Count);

        }
    }
}
