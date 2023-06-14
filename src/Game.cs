namespace src;

public class Game
{
    private readonly List<HashSet<int>> _options;

    public Game()
    {
        _options = new List<HashSet<int>>
        {
            new() { 0, 1, 2 }, new() { 3, 4, 5 }, new() { 6, 7, 8 },
            new() { 0, 3, 6 }, new() { 1, 4, 7 }, new() { 2, 5, 8 },
            new() { 0, 4, 8 }, new() { 6, 4, 2 }
        };
    }

    public GameState State(int[] moves)
    {
        var parity = moves.Length % 2;
        var lastPlayerMoves = moves.Where((_, i) => i % 2 != parity).ToHashSet();
        var currentPlayerMoves = moves.Where((_, i) => i % 2 == parity).ToHashSet();
        var lastPlayerWinningPositions = _options.Count(x => x.IsSubsetOf(lastPlayerMoves));
        var currentPlayerWinningPositions = _options.Count(x => x.IsSubsetOf(currentPlayerMoves));
        if (lastPlayerWinningPositions + currentPlayerWinningPositions > 1)
        {
            throw new GameInInvalidState("There are more than one way to win the game");
        }

        if (lastPlayerWinningPositions == 1)
        {
            return parity == 0 ? GameState.CircleWon : GameState.CrossWon;
        }

        if (moves.Length == 9)
        {
            return GameState.Tied;
        }

        return parity == 0 ? GameState.CrossPlays : GameState.CirclePlays;
    }
}