namespace test;

public class TheGame
{
    [Test]
    public void AssumesStatusInProgressWhenNoMovesArePerformed()
    {
        Assert.That(State(new int[] { }), Is.EqualTo(GameStatus.InProgress));
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