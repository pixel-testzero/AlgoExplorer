namespace AlgoExplorer.Algorithms.Sorting;

/// <summary>
/// Быстрая сортировка. O(n log n) в среднем, O(n²) в худшем. O(log n) по памяти (стек).
/// </summary>
public class QuickSort : ISorter
{
    public string Name => "Quick Sort (Быстрая сортировка)";

    public int[] Sort(int[] array)
    {
        var result = (int[])array.Clone();
        QuickSortRecursive(result, 0, result.Length - 1);
        return result;
    }

    private static void QuickSortRecursive(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSortRecursive(arr, low, pivotIndex - 1);
            QuickSortRecursive(arr, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }
}