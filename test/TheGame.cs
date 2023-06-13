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
}