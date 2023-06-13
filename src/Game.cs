namespace src;

public class Game
{
    public GameState State(int[] moves)
    {
        return moves.Length % 2 == 0 ? GameState.CrossPlays : GameState.CirclePlays;
    }
}