using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TicTacToe.Tests")]

namespace TicTacToe.Logic
{
    public interface IReadOnlyBoardContent
    {
        SquareContent Get(int col, int row);

        //internal SquareContent? GetWinnerFromRows()
        //{
        //    for (var row = 0; row < 3; row++)
        //    {
        //        if (Get(0, row) != SquareContent.Empty &&
        //            Get(0, row) == Get(1, row) &&
        //            Get(1, row) == Get(2, row))
        //        {
        //            return Get(0, row);
        //        }
        //    }

        //    return null;
        //}

        //internal SquareContent? GetWinnerFromCols()
        //{
        //    for (var col = 0; col < 3; col++)
        //    {
        //        if (Get(col, 0) != SquareContent.Empty &&
        //            Get(col, 0) == Get(col, 1) &&
        //            Get(col, 1) == Get(col, 2))
        //        {
        //            return Get(col, 0);
        //        }
        //    }

        //    return null;
        //}

        //internal SquareContent? GetWinnerFromDiagonals()
        //{
        //    if (Get(0, 0) != SquareContent.Empty &&
        //        Get(0, 0) == Get(1, 1) &&
        //        Get(1, 1) == Get(2, 2))
        //    {
        //        return Get(0, 0);
        //    }

        //    if (Get(2, 0) != SquareContent.Empty &&
        //        Get(2, 0) == Get(1, 1) &&
        //        Get(1, 1) == Get(0, 2))
        //    {
        //        return Get(2, 0);
        //    }

        //    return null;
        //}

        //internal SquareContent? GetWinner() =>
        //    GetWinnerFromRows() ?? GetWinnerFromCols() ?? GetWinnerFromDiagonals();
    }

    public interface IWriteableBoardContent
    {
        void Set(int col, int row, SquareContent value);
    }

    public interface IBoardContent : IReadOnlyBoardContent, IWriteableBoardContent { }

    public class BoardContent : IBoardContent
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
