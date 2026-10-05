using AlgoExplorer.DataStructures.BST;
using Xunit;

namespace AlgoExplorer.Tests;

public class BstTests
{
    [Fact]
    public void Insert_And_InOrder_ReturnsSorted()
    {
        var bst = new BinarySearchTree();
        foreach (var v in new[] { 5, 3, 7, 1, 4, 6, 8 })
            bst.Insert(v);

        Assert.Equal([1, 3, 4, 5, 6, 7, 8], bst.InOrder());
    }

    [Fact]
    public void Search_ExistingElement_ReturnsTrue()
    {
        var bst = new BinarySearchTree();
        bst.Insert(10);
        bst.Insert(5);
        Assert.True(bst.Search(5));
    }

    [Fact]
    public void Search_NonExistingElement_ReturnsFalse()
    {
        var bst = new BinarySearchTree();
        bst.Insert(10);
        Assert.False(bst.Search(99));
    }

    [Fact]
    public void Search_EmptyTree_ReturnsFalse()
    {
        var bst = new BinarySearchTree();
        Assert.False(bst.Search(1));
    }

    [Fact]
    public void Insert_Duplicates_Ignored()
    {
        var bst = new BinarySearchTree();
        bst.Insert(5);
        bst.Insert(5);
        bst.Insert(5);
        Assert.Equal([5], bst.InOrder());
    }

    [Fact]
    public void InOrder_EmptyTree_ReturnsEmpty()
    {
        var bst = new BinarySearchTree();
        Assert.Empty(bst.InOrder());
    }
}