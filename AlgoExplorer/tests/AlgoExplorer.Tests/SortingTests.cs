using AlgoExplorer.Algorithms.Sorting;
using Xunit;

namespace AlgoExplorer.Tests;

public class SortingTests
{
    public static IEnumerable<object[]> Sorters()
    {
        yield return new object[] { new MergeSort() };
        yield return new object[] { new QuickSort() };
    }

    [Theory]
    [MemberData(nameof(Sorters))]
    public void Sort_EmptyArray_ReturnsEmpty(ISorter sorter)
    {
        Assert.Empty(sorter.Sort(Array.Empty<int>()));
    }

    [Theory]
    [MemberData(nameof(Sorters))]
    public void Sort_SingleElement_ReturnsSame(ISorter sorter)
    {
        Assert.Equal(new int[] { 42 }, sorter.Sort(new int[] { 42 }));
    }

    [Theory]
    [MemberData(nameof(Sorters))]
    public void Sort_AlreadySorted_ReturnsSame(ISorter sorter)
    {
        int[] input = new int[] { 1, 2, 3, 4, 5 };
        Assert.Equal(input, sorter.Sort(input));
    }

    [Theory]
    [MemberData(nameof(Sorters))]
    public void Sort_ReverseSorted_ReturnsSorted(ISorter sorter)
    {
        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, sorter.Sort(new int[] { 5, 4, 3, 2, 1 }));
    }

    [Theory]
    [MemberData(nameof(Sorters))]
    public void Sort_Duplicates_HandlesCorrectly(ISorter sorter)
    {
        Assert.Equal(new int[] { 1, 2, 2, 3, 3, 3 }, sorter.Sort(new int[] { 3, 1, 2, 3, 2, 3 }));
    }

    [Theory]
    [MemberData(nameof(Sorters))]
    public void Sort_NegativeNumbers_HandlesCorrectly(ISorter sorter)
    {
        Assert.Equal(new int[] { -5, -3, 0, 2, 7 }, sorter.Sort(new int[] { 2, -3, 7, 0, -5 }));
    }

    [Theory]
    [MemberData(nameof(Sorters))]
    public void Sort_DoesNotMutateOriginal(ISorter sorter)
    {
        int[] original = new int[] { 3, 1, 2 };
        int[] copy = new int[] { 3, 1, 2 };
        sorter.Sort(original);
        Assert.Equal(copy, original);
    }
}
