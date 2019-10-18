using Moq;
using NUnit.Framework;
using TicTacToe;

namespace BoardTests
{
    public class Tests
    {
        [Test]
        public void ShouldHaveAWinnerWhenAllSpotsInARowAreTakenBySamePlayer()
        {
            //arrange
            var consoleOperationsMock = new Mock<IConsoleService>();
            var board = new Board(consoleOperationsMock.Object);
            var game = new Game(board, consoleOperationsMock.Object);
            consoleOperationsMock.SetupSequence(s => s.Read()).Returns("0").Returns("4").Returns("1").Returns("5")
                .Returns("2");

            //act

            game.Play();


            //assert

            consoleOperationsMock.Verify(m => m.Write(It.Is<string>(c => c == "congrats! The winner is x ")));
        }

        [Test]
        public void ShouldLetOPlayAfterX()
        {
            //arrange
            var consoleOperationsMock = new Mock<IConsoleService>();
            var board = new Board(consoleOperationsMock.Object);
            var game = new Game(board, consoleOperationsMock.Object);
            consoleOperationsMock.Setup(s => s.Read()).Returns("1");

            //act
            game.Play();


            //assert

            Assert.AreEqual("o", game.Player);
        }
    }
}