using AlgoExplorer.Algorithms.Graph;
using Xunit;

namespace AlgoExplorer.Tests;

public class GraphTests
{
    private static Graph CreateTestGraph()
    {
        var g = new Graph();
        g.AddEdge(0, 1, 1);
        g.AddEdge(0, 2, 1);
        g.AddEdge(1, 3, 1);
        g.AddEdge(2, 3, 1);
        g.AddEdge(3, 4, 1);
        return g;
    }

    [Fact]
    public void Bfs_FromStart_VisitsAllReachable()
    {
        var g = CreateTestGraph();
        var result = Bfs.Traverse(g, 0);
        Assert.Equal(5, result.Count);
        Assert.Equal(0, result[0]);
        Assert.Contains(4, result);
    }

    [Fact]
    public void Bfs_IsolatedVertex_ReturnsOnlyItself()
    {
        var g = new Graph();
        g.AddVertex(0);
        g.AddVertex(1);
        Assert.Equal([0], Bfs.Traverse(g, 0));
    }

    [Fact]
    public void Dfs_FromStart_VisitsAllReachable()
    {
        var g = CreateTestGraph();
        var result = Dfs.Traverse(g, 0);
        Assert.Equal(5, result.Count);
        Assert.Equal(0, result[0]);
    }

    [Fact]
    public void Dijkstra_ShortestPath_CorrectDistances()
    {
        var g = new Graph();
        g.AddEdge(0, 1, 4);
        g.AddEdge(0, 2, 1);
        g.AddEdge(2, 1, 2);
        g.AddEdge(1, 3, 1);

        var (dist, _) = Dijkstra.ShortestPaths(g, 0);

        Assert.Equal(0, dist[0]);
        Assert.Equal(3, dist[1]); // 0→2→1 = 1+2 = 3, а не 0→1 = 4
        Assert.Equal(1, dist[2]);
        Assert.Equal(4, dist[3]); // 0→2→1→3 = 1+2+1 = 4
    }

    [Fact]
    public void Dijkstra_UnreachableVertex_DistanceIsMaxValue()
    {
        var g = new Graph();
        g.AddVertex(0);
        g.AddVertex(1);
        var (dist, _) = Dijkstra.ShortestPaths(g, 0);
        Assert.Equal(int.MaxValue, dist[1]);
    }

    [Fact]
    public void Dijkstra_ReconstructPath_Correct()
    {
        var g = new Graph();
        g.AddEdge(0, 1, 1);
        g.AddEdge(1, 2, 1);
        g.AddEdge(0, 2, 10);

        var (_, parents) = Dijkstra.ShortestPaths(g, 0);
        var path = Dijkstra.ReconstructPath(parents, 2);
        Assert.Equal([0, 1, 2], path);
    }
}