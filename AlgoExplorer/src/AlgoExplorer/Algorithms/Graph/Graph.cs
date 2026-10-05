namespace AlgoExplorer.Algorithms.Graph;

/// <summary>
/// Взвешенный неориентированный граф на списке смежности.
/// </summary>
public class Graph
{
    private readonly Dictionary<int, List<(int To, int Weight)>> _adj = new();

    public IReadOnlyDictionary<int, List<(int To, int Weight)>> AdjacencyList => _adj;
    public IEnumerable<int> Vertices => _adj.Keys;

    public void AddVertex(int v)
    {
        _adj.TryAdd(v, []);
    }

    public void AddEdge(int u, int v, int weight = 1)
    {
        AddVertex(u);
        AddVertex(v);
        _adj[u].Add((v, weight));
        _adj[v].Add((u, weight));
    }

    public List<(int To, int Weight)> GetNeighbors(int v)
    {
        return _adj.TryGetValue(v, out var list) ? list : [];
    }
}