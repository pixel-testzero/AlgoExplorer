namespace AlgoExplorer.Algorithms.TwoPointers;

/// <summary>
/// Техника двух указателей: поиск пары с заданной суммой в отсортированном массиве.
/// O(n) по времени, O(1) по памяти.
/// </summary>
public static class PairSum
{
    public static (int Index1, int Index2)? Find(int[] sortedArray, int target)
    {
        int left = 0;
        int right = sortedArray.Length - 1;

        while (left < right)
        {
            int sum = sortedArray[left] + sortedArray[right];
            if (sum == target)
                return (left, right);
            if (sum < target)
                left++;
            else
                right--;
        }

        return null;
    }
}