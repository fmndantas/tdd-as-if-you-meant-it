namespace test;

public class TheGame
{
    [Test]
    public void AssumesStatusCrossPlaysWhenNoMovesArePerformed()
    {
        Assert.That(State(new int[] { }), Is.EqualTo(GameStatus.CrossPlays));
    }

    [Test]
    public void AlternatesBetweenStatusCrossPlaysAndCirclesPlaysAfterEachMoveUntilGameIsFinished()
    {
        Assert.Multiple(() =>
        {
            Assert.That(State(new[] { 0 }), Is.EqualTo(GameStatus.CirclesPlays));
            Assert.That(State(new[] { 0, 1 }), Is.EqualTo(GameStatus.CrossPlays));
        });
    }

    private GameStatus State(int[] moves)
    {
        return GameStatus.CrossPlays;
    }
}

enum GameStatus
{
    CrossPlays
}