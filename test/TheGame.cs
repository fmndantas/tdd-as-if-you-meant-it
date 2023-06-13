namespace test;

public class TheGame
{
    [Test]
    public void GameIsInProgressWithNoMoves()
    {
        Assert.That(State(new int[] { }), Is.EqualTo(GameStatus.InProgress));
    }

    private int State(int[] moves)
    {
        return 0;
    }
}