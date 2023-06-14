namespace src;

public class WinnerPatternsGenerator
{
    public List<HashSet<int>> Generate(int n)
    {
        return GenerateRowOptions(n);
    }

    private List<HashSet<int>> GenerateRowOptions(int n)
    {
        var options = new List<HashSet<int>>();
        for (var row = 0; row < n; row++)
        {
            var option = new HashSet<int>();
            for (var col = 0; col < n; col++)
            {
                option.Add(col * (row + 1));
            }

            options.Add(option);
        }

        return options;
    }
}