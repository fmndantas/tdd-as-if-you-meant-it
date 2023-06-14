namespace src;

public class Game
{
    private readonly List<HashSet<int>> _options;
    private readonly int _n;

    public Game(int n, WinnerPatternsGenerator generator)
    {
        _n = n;
        _options = generator.Generate(n);
    }

    public GameState State(int[] moves)
    {
        var parity = moves.Length % 2;
        var currentPlayerMoves = moves.Where((_, i) => i % 2 == parity).ToHashSet();
        var currentPlayerWinningPositions = _options.Count(x => x.IsSubsetOf(currentPlayerMoves));
        if (currentPlayerWinningPositions > 0)
        {
            throw new GameInInvalidState("Current player already won the game in a previous move");
        }

        var lastPlayerMoves = moves.Where((_, i) => i % 2 != parity).ToHashSet();
        var lastPlayerWinningPositions = _options.Count(x => x.IsSubsetOf(lastPlayerMoves));
        if (lastPlayerWinningPositions > 1)
        {
            throw new GameInInvalidState("There can be more than one way for the last player to have won the game");
        }

        if (lastPlayerWinningPositions == 1)
        {
            return parity == 0 ? GameState.CircleWon : GameState.CrossWon;
        }

        if (moves.Length == _n * _n)
        {
            return GameState.Tied;
        }

        return parity == 0 ? GameState.CrossPlays : GameState.CirclePlays;
    }
}