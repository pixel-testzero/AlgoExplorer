namespace AlgoExplorer.Algorithms.DP;

/// <summary>
/// Задача о рюкзаке 0/1. Динамическое программирование.
/// O(n * W) по времени и памяти.
/// </summary>
public static class Knapsack
{
    public record Item(string Name, int Weight, int Value);

    public static (int MaxValue, List<Item> SelectedItems) Solve(int capacity, Item[] items)
    {
        int n = items.Length;
        var dp = new int[n + 1, capacity + 1];

        for (int i = 1; i <= n; i++)
        {
            for (int w = 0; w <= capacity; w++)
            {
                dp[i, w] = dp[i - 1, w]; // не берём предмет i
                if (items[i - 1].Weight <= w)
                {
                    int withItem = dp[i - 1, w - items[i - 1].Weight] + items[i - 1].Value;
                    if (withItem > dp[i, w])
                        dp[i, w] = withItem;
                }
            }
        }

        // Восстановление ответа
        var selected = new List<Item>();
        int remaining = capacity;
        for (int i = n; i >= 1; i--)
        {
            if (dp[i, remaining] != dp[i - 1, remaining])
            {
                selected.Add(items[i - 1]);
                remaining -= items[i - 1].Weight;
            }
        }

        return (dp[n, capacity], selected);
    }
}