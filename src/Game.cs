namespace src;

public class Game
{
    private readonly List<HashSet<int>> _rows;

    public Game()
    {
        _rows = new List<HashSet<int>> { new() { 0, 1, 2 }, new() { 3, 4, 5 } };
    }

    public GameState State(int[] moves)
    {
        var parity = moves.Length % 2;
        var selectedMoves = moves.Where((_, i) => i % 2 != parity).ToHashSet();
        var won = _rows.Any(x => x.IsSubsetOf(selectedMoves));
        if (won)
        {
            return parity == 0 ? GameState.CircleWon : GameState.CrossWon;
        }

        return parity == 0 ? GameState.CrossPlays : GameState.CirclePlays;
    }
}