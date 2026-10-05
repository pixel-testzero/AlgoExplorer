using AlgoExplorer.Algorithms.TwoPointers;
using Xunit;

namespace AlgoExplorer.Tests;

public class TwoPointersTests
{
    [Fact]
    public void Find_ExistingPair_ReturnsIndices()
    {
        int[] arr = new int[] { 1, 2, 3, 4, 5 };
        var result = PairSum.Find(arr, 7);
        Assert.NotNull(result);
        Assert.Equal(7, arr[result.Value.Index1] + arr[result.Value.Index2]);
    }

    [Fact]
    public void Find_NonExistingPair_ReturnsNull()
    {
        int[] arr = new int[] { 1, 2, 3, 4, 5 };
        Assert.Null(PairSum.Find(arr, 100));
    }

    [Fact]
    public void Find_EmptyArray_ReturnsNull()
    {
        Assert.Null(PairSum.Find(Array.Empty<int>(), 5));
    }

    [Fact]
    public void Find_SingleElement_ReturnsNull()
    {
        Assert.Null(PairSum.Find(new int[] { 5 }, 5));
    }

    [Fact]
    public void Find_SumAtEdges_Works()
    {
        int[] arr = new int[] { 1, 3, 5, 7, 9 };
        var result = PairSum.Find(arr, 10); // 1 + 9
        Assert.NotNull(result);
        Assert.Equal(10, arr[result.Value.Index1] + arr[result.Value.Index2]);
    }

    [Fact]
    public void Find_NegativeNumbers_Works()
    {
        int[] arr = new int[] { -5, -3, 0, 2, 7 };
        var result = PairSum.Find(arr, -3); // -5 + 2 = -3
        Assert.NotNull(result);
        Assert.Equal(-3, arr[result.Value.Index1] + arr[result.Value.Index2]);
    }
}
