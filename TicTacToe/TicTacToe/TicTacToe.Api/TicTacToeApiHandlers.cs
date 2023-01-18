using TicTacToe.Logic;

namespace TicTacToe.Api
{
    public static class TicTacToeApiHandlers
    {
        public static SquareContent[] GetBoard(IBoardContent content)
        {
            return content.Content;
        }

        public record PositionDto(int Col, int Row);

        public static IResult Set(IGame game, PositionDto position)
        {
            try
            {
                game.Set(position.Col, position.Row);
                return Results.Ok();
            }
            catch (ArgumentOutOfRangeException ex) { return Results.BadRequest(ex.Message); }
            catch (SquareAlreadyOccupiedException ex) { return Results.BadRequest(ex.Message); }
        }
    }
}
