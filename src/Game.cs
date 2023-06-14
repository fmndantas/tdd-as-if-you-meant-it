namespace src;

public class Game
{
    private readonly List<HashSet<int>> _options;

    public Game(int n, WinnerPatternsGenerator generator)
    {
        _options = generator.Generate(n);
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