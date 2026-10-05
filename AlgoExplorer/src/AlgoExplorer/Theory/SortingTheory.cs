using AlgoExplorer.UI;

namespace AlgoExplorer.Theory;

public static class SortingTheory
{
    public static void Show()
    {
        Console.Clear();
        ConsoleHelper.WriteLineColored("  ═══ ТЕОРИЯ: СОРТИРОВКИ ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        // === MERGE SORT ===
        ConsoleHelper.WriteLineColored("  ┌─────────────────────────────────────────────────┐", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  │  1. MERGE SORT (Сортировка слиянием)            │", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  └─────────────────────────────────────────────────┘", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ИДЕЯ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Разделяй и властвуй. Делим массив пополам до одиночных", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  элементов, затем сливаем отсортированные половины.", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПСЕВДОКОД:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  mergeSort(arr, left, right):", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    if left >= right: return", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    mid = (left + right) / 2", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    mergeSort(arr, left, mid)      // сортируем левую", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    mergeSort(arr, mid+1, right)   // сортируем правую", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    merge(arr, left, mid, right)   // сливаем", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПОШАГОВЫЙ ПРИМЕР: [38, 27, 43, 3]", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Шаг 1: Делим → [38, 27] и [43, 3]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Шаг 2: Делим дальше → [38], [27], [43], [3]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Шаг 3: Сливаем пары → [27, 38] и [3, 43]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Шаг 4: Финальное слияние → [3, 27, 38, 43] ✓", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СЛОЖНОСТЬ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Время:   O(n log n) — ВСЕГДА (лучший, средний, худший)", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Память:  O(n) — нужен временный массив для слияния", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Стабильность: ДА (равные элементы сохраняют порядок)", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПЛЮСЫ:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("  • Гарантированная сложность O(n log n)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Стабильная сортировка", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Подходит для связанных списков и внешней сортировки", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   МИНУСЫ:", ConsoleColor.Red);
        ConsoleHelper.WriteLineColored("  • Требует O(n) дополнительной памяти", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Медленнее QuickSort на практике из-за копирования", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteSeparator();
        Console.WriteLine();

        // === QUICK SORT ===
        ConsoleHelper.WriteLineColored("  ┌─────────────────────────────────────────────────┐", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  │  2. QUICK SORT (Быстрая сортировка)             │", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  └─────────────────────────────────────────────────┘", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ИДЕЯ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Выбираем опорный элемент (pivot). Все элементы меньше pivot", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  идут влево, больше — вправо. Рекурсивно сортируем части.", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПСЕВДОКОД:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  quickSort(arr, low, high):", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    if low < high:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      pivotIndex = partition(arr, low, high)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      quickSort(arr, low, pivotIndex - 1)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      quickSort(arr, pivotIndex + 1, high)", ConsoleColor.Green);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  partition(arr, low, high):", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    pivot = arr[high]  // выбираем последний элемент", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    i = low - 1", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    for j = low to high-1:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      if arr[j] <= pivot:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("        i++", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("        swap(arr[i], arr[j])", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    swap(arr[i+1], arr[high])", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    return i + 1", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПОШАГОВЫЙ ПРИМЕР: [3, 7, 2, 8, 1] (pivot = последний)", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Итерация 1: pivot = 1", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    [3, 7, 2, 8] → все > 1, ничего не меняем", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    swap(1, 3) → [1, 7, 2, 8, 3]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    pivot встал на место 0 ✓", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Итерация 2: сортируем [7, 2, 8, 3], pivot = 3", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    7 > 3, 2 < 3 → swap(2, 7) → [2, 7, 8, 3]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    8 > 3, ничего", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    swap(3, 7) → [2, 3, 8, 7]", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Продолжаем рекурсивно... Итог: [1, 2, 3, 7, 8] ✓", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СЛОЖНОСТЬ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Лучший/Средний: O(n log n) — pivot делит пополам", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Худший:         O(n²) — массив уже отсортирован", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Память:         O(log n) — стек рекурсии", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Стабильность:   НЕТ (при стандартной реализации)", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПЛЮСЫ:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("  • Работает 'на месте' (in-place) — минимум памяти", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • На практике быстрее MergeSort (меньше константа)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Хорошо кэшируется (последовательный доступ)", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   МИНУСЫ:", ConsoleColor.Red);
        ConsoleHelper.WriteLineColored("  • Худший случай O(n²) — нужен рандомизированный pivot", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Нестабильная сортировка", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   КОГДА ПРИМЕНЯТЬ:", ConsoleColor.Yellow);
        ConsoleHelper.WriteLineColored("  • QuickSort: общая сортировка в памяти, большие массивы", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • MergeSort: внешняя сортировка, связанные списки, нужна стабильность", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СВЯЗЬ С ДРУГИМИ ТЕМАМИ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Разделяй и властвуй (как MergeSort, бинарный поиск)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Рекурсия (оба алгоритма рекурсивные)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Техника двух указателей (в partition у QuickSort)", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.PressAnyKey();
    }
}