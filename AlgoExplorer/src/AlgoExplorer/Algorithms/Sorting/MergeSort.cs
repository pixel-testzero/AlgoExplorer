namespace AlgoExplorer.Algorithms.Sorting;

/// <summary>
/// Сортировка слиянием. O(n log n) по времени, O(n) по памяти.
/// </summary>
public class MergeSort : ISorter
{
    public string Name => "Merge Sort (Сортировка слиянием)";

    public int[] Sort(int[] array)
    {
        if (array.Length <= 1)
            return (int[])array.Clone();

        var result = (int[])array.Clone();
        var temp = new int[result.Length];
        MergeSortRecursive(result, temp, 0, result.Length - 1);
        return result;
    }

    private static void MergeSortRecursive(int[] arr, int[] temp, int left, int right)
    {
        if (left >= right) return;

        int mid = left + (right - left) / 2;
        MergeSortRecursive(arr, temp, left, mid);
        MergeSortRecursive(arr, temp, mid + 1, right);
        Merge(arr, temp, left, mid, right);
    }

    private static void Merge(int[] arr, int[] temp, int left, int mid, int right)
    {
        for (int i = left; i <= right; i++)
            temp[i] = arr[i];

        int i1 = left, i2 = mid + 1;
        for (int k = left; k <= right; k++)
        {
            if (i1 > mid)              arr[k] = temp[i2++];
            else if (i2 > right)       arr[k] = temp[i1++];
            else if (temp[i1] <= temp[i2]) arr[k] = temp[i1++];
            else                       arr[k] = temp[i2++];
        }
    }
}