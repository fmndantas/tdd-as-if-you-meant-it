namespace test;

public class TheGame
{
    [Test]
    public void GameIsInProgressWithNoMoves()
    {
        Assert.That(State(new int[] { }), Is.EqualTo(0));

        int State(int[] moves)
        {
            return 0;
        }
    }
}