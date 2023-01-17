using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TicTacToe.Tests")]

namespace TicTacToe.Logic
{
    public interface IReadOnlyBoardContent
    {
        SquareContent Get(int col, int row);
    }

    public class BoardContent : IReadOnlyBoardContent
    {
        internal readonly SquareContent[] content;

        public BoardContent() => content = new SquareContent[9];

        public BoardContent(SquareContent[] other)
        {
            ArgumentNullException.ThrowIfNull(other);

            if (other.Length != 9)
            {
                throw new ArgumentException("Board content size must be 9", nameof(other));
            }

            content = other.ToArray();
        }

        public SquareContent[] Content =>
            // Copy array so that receiver cannot modify it
            content.ToArray();

        internal static void ThrowIfInvalid(int col, int row)
        {
            if (col is < 0 or > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(col));
            }

            if (row is < 0 or > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }
        }

        internal static int CalculateArrayIndex(int col, int row) => row * 3 + col;

        public SquareContent Get(int col, int row)
        {
            ThrowIfInvalid(col: col, row: row);
            return content[CalculateArrayIndex(col, row)];
        }

        public void Set(int col, int row, SquareContent value)
        {
            ThrowIfInvalid(col, row);

            var index = CalculateArrayIndex(col, row);
            if (content[index] != SquareContent.Empty)
            {
                throw new SquareAlreadyOccupiedException(col, row);
            }
            
            content[index] = value;
        }
    }
}
