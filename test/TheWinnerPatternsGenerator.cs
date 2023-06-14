using src;

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
            Assert.That(patterns, Contains.Item(new HashSet<int> { 3, 4, 5 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 6, 7, 8 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 0, 3, 6 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 1, 4, 7 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 2, 5, 8 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 0, 4, 8 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 6, 4, 2 }));
        });
    }

    [Test]
    public void GeneratesRowPatternsForGridWithSize4()
    {
        var generator = new WinnerPatternsGenerator();
        var patterns = generator.Generate(4);
        Assert.Multiple(() =>
        {
            Assert.That(patterns, Contains.Item(new HashSet<int> { 0, 1, 2, 3 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 4, 5, 6, 7 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 8, 9, 10, 11 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 12, 13, 14, 15 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 0, 4, 8, 12 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 1, 5, 9, 13 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 2, 6, 10, 14 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 3, 7, 11, 15 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 3, 7, 11, 15 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 0, 5, 10, 15 }));
            Assert.That(patterns, Contains.Item(new HashSet<int> { 12, 9, 6, 3 }));
        });
    }
}