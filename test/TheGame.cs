using src;

namespace test;

public class TheGame
{
    [Test]
    public void AssumesStatusCrossPlaysWhenNoMovesArePerformed()
    {
        var game = new Game();
        Assert.That(game.State(new int[] { }), Is.EqualTo(GameState.CrossPlays));
    }

    [Test]
    public void AlternatesBetweenStatusCrossPlaysAndCirclePlaysAfterEachMoveUntilGameIsFinished()
    {
        var game = new Game();
        Assert.Multiple(() =>
        {
            Assert.That(game.State(new[] { 0 }), Is.EqualTo(GameState.CirclePlays));
            Assert.That(game.State(new[] { 0, 1 }), Is.EqualTo(GameState.CrossPlays));
        });
    }

    [TestCase(new[] { 0, 3, 1, 4, 2 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 0, 3, 2, 4, 1 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 0, 4, 2, 3, 8, 5 }, ExpectedResult = GameState.CircleWon)]
    public GameState InformsThatCurrentPlayerWinsIfThisPlayerFillsAnEntireRow(int[] moves)
    {
        var crossMoves = moves.Where((_, i) => i % 2 == 0).ToHashSet();
        if (crossMoves.IsSupersetOf(new HashSet<int> { 0, 1, 2 }))
        {
            return GameState.CrossWon;
        }

        var circleMoves = moves.Where((_, i) => i % 2 == 1).ToHashSet();
        if (circleMoves.IsSupersetOf(new HashSet<int> { 3, 4, 5 }))
        {
            return GameState.CircleWon;
        }

        return new Game().State(moves);
    }
}