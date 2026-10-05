using AlgoExplorer.Algorithms.DP;
using Xunit;

namespace AlgoExplorer.Tests;

public class DpTests
{
    [Fact]
    public void Knapsack_StandardCase_CorrectValue()
    {
        var items = new Knapsack.Item[]
        {
            new("A", 2, 3),
            new("B", 3, 4),
            new("C", 4, 5),
        };
        var (maxVal, selected) = Knapsack.Solve(5, items);
        Assert.Equal(7, maxVal); // A + B = 3 + 4
        Assert.Equal(2, selected.Count);
    }

    [Fact]
    public void Knapsack_ZeroCapacity_ReturnsZero()
    {
        var items = new Knapsack.Item[] { new("A", 1, 10) };
        var (maxVal, selected) = Knapsack.Solve(0, items);
        Assert.Equal(0, maxVal);
        Assert.Empty(selected);
    }

    [Fact]
    public void Knapsack_NoItems_ReturnsZero()
    {
        var (maxVal, selected) = Knapsack.Solve(10, []);
        Assert.Equal(0, maxVal);
        Assert.Empty(selected);
    }

    [Fact]
    public void Knapsack_AllItemsFit_TakesAll()
    {
        var items = new Knapsack.Item[]
        {
            new("A", 1, 10),
            new("B", 2, 20),
        };
        var (maxVal, selected) = Knapsack.Solve(10, items);
        Assert.Equal(30, maxVal);
        Assert.Equal(2, selected.Count);
    }

    [Fact]
    public void Knapsack_NoItemFits_ReturnsZero()
    {
        var items = new Knapsack.Item[]
        {
            new("A", 10, 100),
        };
        var (maxVal, selected) = Knapsack.Solve(5, items);
        Assert.Equal(0, maxVal);
        Assert.Empty(selected);
    }
}