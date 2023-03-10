namespace TicTacToe.Logic
{
    public enum Players { X, O }

    public interface IGame
    {
        Players? Winner { get; }

        void Set(int col, int row);
    }

    public class Game : IGame
    {
        private readonly IBoardContent content;
        internal Players currentPlayer = Players.X;

        public Game(IBoardContent content) { this.content = content; }
        
        internal static SquareContent? GetWinnerFromRows(IReadOnlyBoardContent content)
        {
            for (var row = 0; row < 3; row++)
            {
                if (content.Get(0, row) != SquareContent.Empty &&
                    content.Get(0, row) == content.Get(1, row) &&
                    content.Get(1, row) == content.Get(2, row))
                {
                    return content.Get(0, row);
                }
            }

            return null;
        }

        internal static SquareContent? GetWinnerFromCols(IReadOnlyBoardContent content)
        {
            for (var col = 0; col < 3; col++)
            {
                if (content.Get(col, 0) != SquareContent.Empty &&
                    content.Get(col, 0) == content.Get(col, 1) &&
                    content.Get(col, 1) == content.Get(col, 2))
                {
                    return content.Get(col, 0);
                }
            }

            return null;
        }

        internal static SquareContent? GetWinnerFromDiagonals(IReadOnlyBoardContent content)
        {
            if (content.Get(0, 0) != SquareContent.Empty &&
                content.Get(0, 0) == content.Get(1, 1) &&
                content.Get(1, 1) == content.Get(2, 2))
            {
                return content.Get(0, 0);
            }

            if (content.Get(2, 0) != SquareContent.Empty &&
                content.Get(2, 0) == content.Get(1, 1) &&
                content.Get(1, 1) == content.Get(0, 2))
            {
                return content.Get(2, 0);
            }

            return null;
        }

        internal static SquareContent? GetWinner(IReadOnlyBoardContent content) =>
            GetWinnerFromRows(content) ?? GetWinnerFromCols(content) ?? GetWinnerFromDiagonals(content);

        public void Set(int col, int row)
        {
            content.Set(col, row, currentPlayer switch
            {
                Players.X => SquareContent.X,
                Players.O => SquareContent.O,
                _ => throw new InvalidOperationException("Invalid player")
            });
            currentPlayer = currentPlayer == Players.X ? Players.O : Players.X;
        }

        public Players? Winner => GetWinner(content) switch
        { 
            SquareContent.X => Players.X, 
            SquareContent.O => Players.O, 
            _ => null
        };
    }
}
