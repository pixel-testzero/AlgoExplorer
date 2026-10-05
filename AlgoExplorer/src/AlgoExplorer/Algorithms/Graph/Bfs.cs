namespace AlgoExplorer.Algorithms.Graph;

/// <summary>
/// Обход в ширину (BFS). O(V + E).
/// </summary>
public static class Bfs
{
    public static List<int> Traverse(Graph graph, int start)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        var result = new List<int>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current);

            foreach (var (to, _) in graph.GetNeighbors(current))
            {
                if (visited.Add(to))
                    queue.Enqueue(to);
            }
        }

        return result;
    }
}