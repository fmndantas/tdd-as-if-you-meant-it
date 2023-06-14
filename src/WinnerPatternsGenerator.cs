namespace src;

public class WinnerPatternsGenerator
{
    public List<HashSet<int>> Generate(int n)
    {
        var rows = GenerateRowOptions(n);
        var columns = GenerateColumnsOptions(n);
        var diagonals = GenerateDiagonalOptions(n);
        var result = new List<HashSet<int>>();
        result.AddRange(rows);
        result.AddRange(columns);
        result.AddRange(diagonals);
        return result;
    }

    private List<HashSet<int>> GenerateRowOptions(int n)
    {
        var options = new List<HashSet<int>>();
        for (var row = 0; row < n; row++)
        {
            var option = new HashSet<int>();
            for (var col = 0; col < n; col++)
            {
                option.Add(row * n + col);
            }

            options.Add(option);
        }

        return options;
    }

    private List<HashSet<int>> GenerateColumnsOptions(int n)
    {
        var options = new List<HashSet<int>>();
        for (var col = 0; col < n; col++)
        {
            var option = new HashSet<int>();
            for (var row = 0; row < n; row++)
            {
                option.Add(col + n * row);
            }

            options.Add(option);
        }

        return options;
    }

    private List<HashSet<int>> GenerateDiagonalOptions(int n)
    {
        var firstDiagonal = new HashSet<int>();
        for (var i = 0; i < n; i++)
        {
            firstDiagonal.Add(n * i + i);
        }

        var secondDiagonal = new HashSet<int>();
        for (int row = n - 1, col = 0; row >= 0; row--, col++)
        {
            secondDiagonal.Add(row * n + col);
        }

        return new List<HashSet<int>> { firstDiagonal, secondDiagonal };
    }
}