using TicTacToe.Logic;

namespace TicTacToe.Tests
{
    public class SquareContentTests
    {
        /// <summary>
        /// Ensure that <see cref="SquareContent.Empty"/> has the discriminant value 0.
        /// </summary>
        /// <remarks>
        /// This value is important for our algorithms to work. Lorem ipsum...
        /// </remarks>
        [Fact]
        public void EmptyHasToBeZero() => Assert.Equal(0, (int)SquareContent.Empty);

        [Fact]
        public void OGreaterThanX() => Assert.True(SquareContent.O > SquareContent.X);
    }
}
