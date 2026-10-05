namespace AlgoExplorer.DataStructures.BST;

public class BstNode
{
    public int Value { get; set; }
    public BstNode? Left { get; set; }
    public BstNode? Right { get; set; }

    public BstNode(int value) => Value = value;
}

/// <summary>
/// Бинарное дерево поиска (BST).
/// Вставка/поиск: O(h), где h — высота дерева.
/// В сбалансированном случае O(log n), в худшем O(n).
/// </summary>
public class BinarySearchTree
{
    public BstNode? Root { get; private set; }

    public void Insert(int value)
    {
        Root = InsertRecursive(Root, value);
    }

    private static BstNode InsertRecursive(BstNode? node, int value)
    {
        if (node is null) return new BstNode(value);

        if (value < node.Value)
            node.Left = InsertRecursive(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRecursive(node.Right, value);

        return node;
    }

    public bool Search(int value)
    {
        return SearchRecursive(Root, value);
    }

    private static bool SearchRecursive(BstNode? node, int value)
    {
        if (node is null) return false;
        if (value == node.Value) return true;
        return value < node.Value
            ? SearchRecursive(node.Left, value)
            : SearchRecursive(node.Right, value);
    }

    public List<int> InOrder()
    {
        var result = new List<int>();
        InOrderRecursive(Root, result);
        return result;
    }

    private static void InOrderRecursive(BstNode? node, List<int> result)
    {
        if (node is null) return;
        InOrderRecursive(node.Left, result);
        result.Add(node.Value);
        InOrderRecursive(node.Right, result);
    }

    /// <summary>
    /// Визуализация дерева в консоль.
    /// </summary>
    public string Visualize()
    {
        if (Root is null) return "(пустое дерево)";
        var lines = new List<string>();
        BuildVisual(Root, "", true, lines);
        return string.Join('\n', lines);
    }

    private static void BuildVisual(BstNode? node, string prefix, bool isLast, List<string> lines)
    {
        if (node is null) return;

        lines.Add(prefix + (isLast ? "└── " : "├── ") + node.Value);
        string childPrefix = prefix + (isLast ? "    " : "│   ");

        var children = new List<BstNode?>();
        if (node.Left is not null) children.Add(node.Left);
        if (node.Right is not null) children.Add(node.Right);

        for (int i = 0; i < children.Count; i++)
            BuildVisual(children[i], childPrefix, i == children.Count - 1, lines);
    }
}