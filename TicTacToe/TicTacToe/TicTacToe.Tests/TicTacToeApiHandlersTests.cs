using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using TicTacToe.Api;
using TicTacToe.Logic;

namespace TicTacToe.Tests
{
    public class TicTacToeApiHandlersTests
    {
        [Fact]
        public void SetColRowOutOfRange()
        {
            var gameMock = new Mock<IGame>();
            gameMock.Setup(x => x.Set(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new ArgumentOutOfRangeException());

            var result = TicTacToeApiHandlers.Set(gameMock.Object, new(0, 0));
            Assert.IsType<BadRequest<string>>(result);
        }

        [Fact]
        public void SetSquareOccupied()
        {
            var gameMock = new Mock<IGame>();
            gameMock.Setup(x => x.Set(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new SquareAlreadyOccupiedException("", 0, 0));

            var result = TicTacToeApiHandlers.Set(gameMock.Object, new(0, 0));
            Assert.IsType<BadRequest<string>>(result);
        }
    }
}
