using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Logic;

namespace TicTacToe.Tests
{
    public class BoardContentTests
    {
        [Fact]
        public void AllSquaresAreEmptyAfterCreation()
        {
            var bc = new BoardContent();
            Assert.All(bc.Content, c => Assert.Equal(SquareContent.Empty, c));
            //Assert.True(bc.Content.All(c => c == SquareContent.Empty));
            //for (var i = 0; i < 9; i++)
            //{
            //    Assert.Equal(SquareContent.Empty, bc.Content[i]);
            //}
        }

        [Fact]
        public void EnsureThatContentPropertyCopiesState()
        {
            var bc = new BoardContent();
            Assert.NotStrictEqual(bc.content, bc.Content);
        }

        [Fact]
        public void ConstructorHandlesNull()
        {
            Assert.Throws<ArgumentNullException>(() => new BoardContent(null!));
        }

        [Fact]
        public void ConstructorThrowsIfWrongLength()
        {
            Assert.Throws<ArgumentException>(() => new BoardContent(new SquareContent[8]));
        }

        [Fact]
        public void ConstructorCopiesState()
        {
            var content = new SquareContent[9];
            content[0] = SquareContent.X;
            var bc = new BoardContent(content);
            Assert.NotStrictEqual(content, bc.content);
            Assert.Equal(content, bc.content);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(3, 0)]
        [InlineData(0, 3)]
        public void ThrowIfInvalid(int col, int row)
        {
            // Check if ThrowIfInvalid works properly
            Assert.Throws<ArgumentOutOfRangeException>(() => BoardContent.ThrowIfInvalid(col, row));

            // Ensure that Get method calls ThrowIfInvalid internally
            var bc = new BoardContent();
            Assert.Throws<ArgumentOutOfRangeException>(() => bc.Get(col, row));

            // Ensure that Set method calls ThrowIfInvalid internally
            Assert.Throws<ArgumentOutOfRangeException>(() => bc.Set(col, row, SquareContent.X));
        }

        [Fact]
        public void CalculateArrayIndex()
        {
            Assert.Equal(4, BoardContent.CalculateArrayIndex(1, 1));
        }

        [Fact]
        public void SetWhenSquareAlreadyOccupied()
        {
            var bc = new BoardContent();
            bc.Set(0, 0, SquareContent.X);
            Assert.Throws<SquareAlreadyOccupiedException>(() => bc.Set(0, 0, SquareContent.O));
        }
    }
}
