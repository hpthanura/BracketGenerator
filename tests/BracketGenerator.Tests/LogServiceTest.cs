using BracketGenerator.Services;
using BracketGenerator.Services.Interfaces;
using BracketGenerator.TournamentFactory;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Tests
{
    [TestFixture]
    public class LogServiceTest
    {
        [Test]
        public void LogService_Write()
        {
            // Arrange
            LogService logService = new LogService();
            string message = "Test message";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            logService.Write(message);
            string consoleOutput = sw.ToString().Trim(); // Get the console output

            // Assert
            Assert.AreEqual(message, consoleOutput);
        }

        [Test]
        public void LogService_WriteBlank()
        {
            // Arrange
            LogService logService = new LogService();
            string message = "";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            logService.WriteBlank();
            string consoleOutput = sw.ToString().Trim(); // Get the console output

            // Assert
            Assert.AreEqual(message, consoleOutput);
        }

        [Test]
        public void LogService_WriteLine()
        {
            // Arrange
            LogService logService = new LogService();
            string message = "Test Message";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            logService.WriteLine(message);
            string consoleOutput = sw.ToString().Trim(); // Get the console output

            // Assert
            Assert.AreEqual(message, consoleOutput);
        }
    }
}
