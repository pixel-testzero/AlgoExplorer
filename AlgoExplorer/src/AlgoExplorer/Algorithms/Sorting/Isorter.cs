namespace AlgoExplorer.Algorithms.Sorting;

public interface ISorter
{
    string Name { get; }
    int[] Sort(int[] array);
}