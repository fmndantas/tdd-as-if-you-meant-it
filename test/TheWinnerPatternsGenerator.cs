namespace test;

public class TheWinnerPatternsGenerator
{
    [Test]
    public void GeneratesRowPatternsForGridWithSize3()
    {
        var generator = new WinnerPatternsGenerator();
        var patterns = generator.Generate(3);
        Assert.Multiple(() =>
        {
            Assert.That(patterns, Contains.Item(new HashSet<int> { 0, 1, 2 }));
        });
    }
}