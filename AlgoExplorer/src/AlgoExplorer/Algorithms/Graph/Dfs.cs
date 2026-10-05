namespace AlgoExplorer.Algorithms.Graph;

/// <summary>
/// Обход в глубину (DFS). O(V + E).
/// </summary>
public static class Dfs
{
    public static List<int> Traverse(Graph graph, int start)
    {
        var visited = new HashSet<int>();
        var result = new List<int>();
        DfsRecursive(graph, start, visited, result);
        return result;
    }

    private static void DfsRecursive(Graph graph, int v, HashSet<int> visited, List<int> result)
    {
        visited.Add(v);
        result.Add(v);

        foreach (var (to, _) in graph.GetNeighbors(v))
        {
            if (!visited.Contains(to))
                DfsRecursive(graph, to, visited, result);
        }
    }
}