namespace AlgoExplorer.Algorithms.Graph;

/// <summary>
/// Алгоритм Дейкстры. O((V + E) log V) с приоритетной очередью.
/// </summary>
public static class Dijkstra
{
    public static (Dictionary<int, int> Distances, Dictionary<int, int?> Parents)
        ShortestPaths(Graph graph, int start)
    {
        var dist = new Dictionary<int, int>();
        var parent = new Dictionary<int, int?>();
        var pq = new PriorityQueue<int, int>();

        foreach (var v in graph.Vertices)
        {
            dist[v] = int.MaxValue;
            parent[v] = null;
        }

        dist[start] = 0;
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            var u = pq.Dequeue();

            foreach (var (v, weight) in graph.GetNeighbors(u))
            {
                int newDist = dist[u] + weight;
                if (newDist < dist[v])
                {
                    dist[v] = newDist;
                    parent[v] = u;
                    pq.Enqueue(v, newDist);
                }
            }
        }

        return (dist, parent);
    }

    public static List<int> ReconstructPath(Dictionary<int, int?> parents, int target)
    {
        var path = new List<int>();
        int? current = target;
        while (current is not null)
        {
            path.Add(current.Value);
            current = parents[current.Value];
        }
        path.Reverse();
        return path;
    }
}