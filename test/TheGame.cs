using src;

namespace test;

public class TheGame
{
    [Test]
    public void AssumesStatusCrossPlaysWhenNoMovesArePerformed()
    {
        var game = new Game(3, new WinnerPatternsGenerator());
        Assert.That(game.State(new int[] { }), Is.EqualTo(GameState.CrossPlays));
    }

    [Test]
    public void AlternatesBetweenStatusCrossPlaysAndCirclePlaysAfterEachMoveUntilGameIsFinished()
    {
        var game = new Game(3, new WinnerPatternsGenerator());
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
    [TestCase(new[] { 0, 12, 2, 13, 3, 14, 4, 15 }, 4, ExpectedResult = GameState.CircleWon)]
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
        return new Game(3, new WinnerPatternsGenerator()).State(moves);
    }

    [TestCase(new[] { 0, 6, 8, 7, 4 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 4, 5, 2, 8, 6 }, ExpectedResult = GameState.CrossWon)]
    [TestCase(new[] { 1, 2, 7, 4, 0, 6 }, ExpectedResult = GameState.CircleWon)]
    public GameState InformsThatCurrentPlayerWinsIfThisPlayerFillsOneOfTwoDiagonals(int[] moves)
    {
        return new Game(3, new WinnerPatternsGenerator()).State(moves);
    }

    [TestCase(new[] { 0, 1, 2, 4, 3, 5, 8, 6, 7 }, 3, ExpectedResult = GameState.Tied)]
    [TestCase(new[] { 0, 2, 1, 3, 4, 7, 5, 8, 6 }, 3, ExpectedResult = GameState.Tied)]
    [TestCase(new[] { 0, 1, 2, 3, 5, 4, 7, 6, 10, 9, 11, 8, 12, 13, 14, 15 }, 4, ExpectedResult = GameState.Tied)]
    public GameState InformsThatGameIsTiedWhenAllSpotsAreFilledAndNoPlayerHasWon(int[] moves, int n)
    {
        return new Game(n, new WinnerPatternsGenerator()).State(moves);
    }

    [TestCase(new[] { 0, 1, 3, 4, 6, 7 }, 3)]
    [TestCase(new[] { 0, 3, 1, 4, 2, 5 }, 3)]
    [TestCase(new[] { 0, 3, 1, 4, 2, 5 }, 3)]
    public void ThrowErrorWhenMoreThanOneWayToWinAreSpotted(int[] moves, int n)
    {
        Assert.Throws<GameInInvalidState>(() => { new Game(n, new WinnerPatternsGenerator()).State(moves); });
    }

    [TestCase(new[] { 0, 4, 5, 8, 10, 12, 15, 1 }, 4)]
    public void ThrowErrorWhenThereIsOneWayToWinAndThisWayPertainsToTheCurrentPlayer(int[] moves, int n)
    {
        Assert.Throws<GameInInvalidState>(() => { new Game(n, new WinnerPatternsGenerator()).State(moves); });
    }
}