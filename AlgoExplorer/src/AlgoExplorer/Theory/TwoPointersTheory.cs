using AlgoExplorer.UI;

namespace AlgoExplorer.Theory;

public static class TwoPointersTheory
{
    public static void Show()
    {
        Console.Clear();
        ConsoleHelper.WriteLineColored("  ═══ ТЕОРИЯ: ТЕХНИКА ДВУХ УКАЗАТЕЛЕЙ ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ИДЕЯ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Используем ДВА указателя (индекса) для обхода данных.", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Обычно один указатель в начале, другой в конце.", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Двигаем их навстречу друг другу или в одном направлении.", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ТИПИЧНЫЕ ЗАДАЧИ:", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  1. Поиск пары с заданной суммой (в отсортированном массиве)", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  2. Проверка палиндрома", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  3. Удаление дубликатов из отсортированного массива", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  4. Поиск подмассива с заданным свойством (скользящее окно)", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteSeparator();
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("  ┌─────────────────────────────────────────────────┐", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  │  ЗАДАЧА: ПАРА С ЗАДАННОЙ СУММОЙ                 │", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  └─────────────────────────────────────────────────┘", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   УСЛОВИЕ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Дан отсортированный массив", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Найти два элемента, сумма которых равна target", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   АЛГОРИТМ:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("  left = 0, right = n - 1", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("  while left < right:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    sum = arr[left] + arr[right]", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    if sum == target: НАШЛИ!", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    if sum < target: left++   (нужна бОльшая сумма)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    if sum > target: right--  (нужна мЕньшая сумма)", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПОШАГОВЫЙ ПРИМЕР:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  arr = [1, 3, 5, 7, 9, 11], target = 12", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Шаг 1: left=0 (1), right=5 (11), sum=12", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("         12 == 12 → НАШЛИ! (1 + 11 = 12) ✓", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("  Другой пример: target = 10", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Шаг 1: left=0 (1), right=5 (11), sum=12 > 10 → right--", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  Шаг 2: left=0 (1), right=4 (9), sum=10 == 10 → НАШЛИ! ✓", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("  Еще пример: target = 20", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Шаг 1: left=0 (1), right=5 (11), sum=12 < 20 → left++", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  Шаг 2: left=1 (3), right=5 (11), sum=14 < 20 → left++", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  Шаг 3: left=2 (5), right=5 (11), sum=16 < 20 → left++", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  Шаг 4: left=3 (7), right=5 (11), sum=18 < 20 → left++", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  Шаг 5: left=4 (9), right=5 (11), sum=20 == 20 → НАШЛИ! ✓", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СЛОЖНОСТЬ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Время: O(n) — каждый указатель проходит массив максимум 1 раз", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Память: O(1) — только два указателя", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   АЛЬТЕРНАТИВЫ:", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  1. Перебор всех пар (brute force):", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • Время: O(n²) — слишком медленно", ConsoleColor.Red);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  2. HashSet:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • Время: O(n)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("     • Память: O(n) — нужен дополнительный HashSet", ConsoleColor.Yellow);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  3. Бинарный поиск:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • Время: O(n log n) — для каждого элемента ищем пару", ConsoleColor.Yellow);
        ConsoleHelper.WriteLineColored("     • Память: O(1)", ConsoleColor.Green);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  ✓ Два указателя: O(n) время, O(1) память — ЛУЧШИЙ вариант!", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ВАЖНО:", ConsoleColor.Red);
        ConsoleHelper.WriteLineColored("  • Работает только для ОТСОРТИРОВАННОГО массива!", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Если массив не отсортирован: сначала сортировка O(n log n),", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    затем два указателя O(n). Итого: O(n log n)", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ДРУГИЕ ПРИМЕНЕНИЯ:", ConsoleColor.Yellow);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  1. Палиндром:", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     left=0, right=n-1, сравниваем arr[left] и arr[right]", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  2. Удаление дубликатов:", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     slow и fast указатели, slow указывает на уникальные", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  3. Скользящее окно (Sliding Window):", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     Поиск подмассива с максимальной суммой, длина ≤ k", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СВЯЗЬ С ДРУГИМИ ТЕМАМИ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Сортировка (часто нужна предварительная сортировка)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Бинарный поиск (альтернатива для поиска пары)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Скользящее окно (разновидность двух указателей)", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.PressAnyKey();
    }
}