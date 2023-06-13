namespace src;

public class Game
{
    private readonly List<HashSet<int>> options;

    public Game()
    {
        options = new List<HashSet<int>>
        {
            new() { 0, 1, 2 }, new() { 3, 4, 5 }, new() { 6, 7, 8 },
            new() { 0, 3, 6 }, new() { 1, 4, 7 }, new() { 2, 5, 8 }
        };
    }

    public GameState State(int[] moves)
    {
        var parity = moves.Length % 2;
        var selectedMoves = moves.Where((_, i) => i % 2 != parity).ToHashSet();
        if (options.Any(x => x.IsSubsetOf(selectedMoves)))
        {
            return parity == 0 ? GameState.CircleWon : GameState.CrossWon;
        }

        return parity == 0 ? GameState.CrossPlays : GameState.CirclePlays;
    }
}