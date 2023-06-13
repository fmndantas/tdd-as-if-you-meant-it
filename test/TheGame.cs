namespace test;

public class TheGame
{
    [Test]
    public void AssumesStatusCrossPlaysWhenNoMovesArePerformed()
    {
        Assert.That(State(new int[] { }), Is.EqualTo(GameStatus.CrossPlays));
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