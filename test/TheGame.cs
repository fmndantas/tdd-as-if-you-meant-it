namespace test;

public class TheGame
{
    [Test]
    public void AssumesStatusXPlaysWhenNoMovesArePerformed()
    {
        Assert.That(State(new int[] { }), Is.EqualTo(GameStatus.XPlays));
    }

    private GameStatus State(int[] moves)
    {
        return GameStatus.InProgress;
    }
}

enum GameStatus
{
    InProgress
}