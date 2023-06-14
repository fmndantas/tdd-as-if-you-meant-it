using src;

namespace test;

public class TheGame
{
    [Test]
    public void AssumesStatusCrossPlaysWhenNoMovesArePerformed()
    {
        var game = new Game(3);
        Assert.That(game.State(new int[] { }), Is.EqualTo(GameState.CrossPlays));
    }

    [Test]
    public void AlternatesBetweenStatusCrossPlaysAndCirclePlaysAfterEachMoveUntilGameIsFinished()
    {
        var game = new Game(3);
        Assert.Multiple(() =>
        {
            Assert.That(game.State(new[] { 0 }), Is.EqualTo(GameState.CirclePlays));
            Assert.That(game.State(new[] { 0, 1 }), Is.EqualTo(GameState.CrossPlays));
        });
    }

    [TestCase(new[] { 0, 3, 1, 4, 2 }, 3, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 0, 3, 2, 4, 1 }, 3, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 0, 4, 2, 3, 8, 5 }, 3, ExpectedResult = GameState.CircleWon)]
    [TestCase(new[] { 0, 8, 1, 6, 3, 7 }, 3, ExpectedResult = GameState.CircleWon)]
    [TestCase(new[] { 0, 12, 1, 13, 2, 14, 3 }, 4, ExpectedResult = GameState.CrossWon)]
    public GameState InformsThatCurrentPlayerWinsIfThisPlayerFillsAnEntireRow(int[] moves, int n)
    {
        return new Game(n, new WinnerPatternsGenerator()).State(moves);
    }

    [TestCase(new[] { 0, 1, 3, 2, 6 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 1, 0, 4, 3, 7 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 2, 0, 5, 3, 8 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 1, 0, 2, 3, 8, 6 }, ExpectedResult = GameState.CircleWon)]
    public GameState InformsThatCurrentPlayerWinsIfThisPlayerFillsAnEntireColumn(int[] moves)
    {
        return new Game(3).State(moves);
    }

    [TestCase(new[] { 0, 6, 8, 7, 4 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 4, 5, 2, 8, 6 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 1, 2, 7, 4, 0, 6 }, ExpectedResult = GameState.CircleWon)]
    public GameState InformsThatCurrentPlayerWinsIfThisPlayerFillsOneOfTwoDiagonals(int[] moves)
    {
        return new Game(3).State(moves);
    }

    [TestCase(new[] { 0, 1, 2, 4, 3, 5, 8, 6, 7 }, ExpectedResult = GameState.Tied)]
    [TestCase(new[] { 0, 2, 1, 3, 4, 7, 5, 8, 6 }, ExpectedResult = GameState.Tied)]
    public GameState InformsThatGameIsTiedWhenAllSpotsAreFilledAndNoPlayerHasWon(int[] moves)
    {
        return new Game(3).State(moves);
    }

    [TestCase(new[] { 0, 1, 3, 4, 6, 7 })]
    [TestCase(new[] { 0, 3, 1, 4, 2, 5 })]
    public void ThrowErrorWhenMoreThanOneWayToWinAreSpotted(int[] moves)
    {
        Assert.Throws<GameInInvalidState>(() => { new Game(3).State(moves); });
    }
}