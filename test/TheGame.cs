namespace test;

public class TheGame
{
    [Test]
    public void AssumesStatusCrossPlaysWhenNoMovesArePerformed()
    {
        Assert.That(State(new int[] { }), Is.EqualTo(GameStatus.CrossPlays));
    }

    [Test]
    public void AlternatesBetweenStatusCrossPlaysAndCirclePlaysAfterEachMoveUntilGameIsFinished()
    {
        Assert.Multiple(() =>
        {
            Assert.That(State(new[] { 0 }), Is.EqualTo(GameStatus.CirclePlays));
            Assert.That(State(new[] { 0, 1 }), Is.EqualTo(GameStatus.CrossPlays));
        });
    }

    private GameStatus State(int[] moves)
    {
        return moves.Length % 2 == 0 ? GameStatus.CrossPlays : GameStatus.CirclePlays;
    }
}

enum GameStatus
{
    CrossPlays,
    CirclePlays
}