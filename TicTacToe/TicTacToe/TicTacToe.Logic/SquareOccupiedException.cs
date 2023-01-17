namespace TicTacToe.Logic
{
    public class SquareAlreadyOccupiedException : Exception
    {
        public int Col { get; }
        public int Row { get; }

        public SquareAlreadyOccupiedException(int col, int row)
        {
            Col = col;
            Row = row;
        }

        public SquareAlreadyOccupiedException(string message, int col, int row) : base(message)
        {
            Col = col;
            Row = row;
        }

        public SquareAlreadyOccupiedException(string message, Exception inner, int col, int row) : base(message, inner)
        {
            Col = col;
            Row = row;
        }
    }

}
