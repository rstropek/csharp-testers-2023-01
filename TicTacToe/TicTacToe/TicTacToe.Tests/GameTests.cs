using Moq;
using TicTacToe.Logic;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        [Fact]
        public void WinnerRow()
        {
            var bcMock = new Mock<IReadOnlyBoardContent>();
            bcMock.Setup(x => x.Get(It.IsAny<int>(), 0)).Returns(SquareContent.X);

            Assert.Equal(SquareContent.X, Game.GetWinnerFromRows(bcMock.Object));
        }

        [Fact]
        public void WinnerCol()
        {
            var bcMock = new Mock<IReadOnlyBoardContent>();
            bcMock.Setup(x => x.Get(0, It.IsAny<int>())).Returns(SquareContent.X);

            Assert.Equal(SquareContent.X, Game.GetWinnerFromCols(bcMock.Object));
        }

        [Fact]
        public void WinnerDiagnoal()
        {
            static SquareContent GetDiagonalWithX(int col, int row)
            {
                if (col == row)
                {
                    return SquareContent.X;
                }
                else
                {
                    return SquareContent.Empty;
                }
            }

            var bcMock = new Mock<IReadOnlyBoardContent>();
            bcMock.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<int>()))
                //.Returns<int, int>((col, row) => col == row ? SquareContent.X : SquareContent.Empty);
                .Returns<int, int>(GetDiagonalWithX);

            Assert.Equal(SquareContent.X, Game.GetWinnerFromDiagonals(bcMock.Object));
        }
    }
}
