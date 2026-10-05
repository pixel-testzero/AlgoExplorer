using AlgoExplorer.UI;

namespace AlgoExplorer.Theory;

public static class DpTheory
{
    public static void Show()
    {
        Console.Clear();
        ConsoleHelper.WriteLineColored("  ═══ ТЕОРИЯ: ДИНАМИЧЕСКОЕ ПРОГРАММИРОВАНИЕ ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ИДЕЯ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Решаем сложную задачу, разбивая её на ПОДЗАДАЧИ.", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Ключевая идея: если подзадачи ПЕРЕКРЫВАЮТСЯ,", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  сохраняем их решения, чтобы не считать дважды.", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ДВА ПОДХОДА:", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  1. СВЕРХУ ВНИЗ (Top-Down, мемоизация):", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     • Рекурсия + кэширование результатов", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • Пример: fib(n) = fib(n-1) + fib(n-2) с кэшем", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  2. СНИЗУ ВВЕРХ (Bottom-Up, табуляция):", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     • Итеративно заполняем таблицу", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • Пример: заполняем dp[0], dp[1], ..., dp[n]", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteSeparator();
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("  ┌─────────────────────────────────────────────────┐", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  │  ЗАДАЧА О РЮКЗАКЕ 0/1                           │", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  └─────────────────────────────────────────────────┘", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   УСЛОВИЕ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Есть рюкзак вместимостью W", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Есть n предметов с весом w[i] и ценностью v[i]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Каждый предмет можно взять ЦЕЛИКОМ или НЕ брать (0/1)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Цель: максимизировать суммарную ценность", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   РЕШЕНИЕ (Bottom-Up DP):", ConsoleColor.Green);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  dp[i][w] = максимальная ценность, используя первые i предметов", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("             и вместимость не более w", ConsoleColor.Green);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Базовый случай:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    dp[0][w] = 0  (нет предметов — нет ценности)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    dp[i][0] = 0  (нет вместимости — ничего не возьмем)", ConsoleColor.Green);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Переход:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    dp[i][w] = dp[i-1][w]  // не берем предмет i", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    if w[i] <= w:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      dp[i][w] = max(dp[i][w], dp[i-1][w-w[i]] + v[i])", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("                   // берем предмет i, если влезает", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПОШАГОВЫЙ ПРИМЕР:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Предметы: A(вес=2, цен=3), B(вес=3, цен=4), C(вес=4, цен=5)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Вместимость: W = 5", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Таблица dp[i][w] (строки — предметы, столбцы — вместимость):", ConsoleColor.Cyan);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("       w=0  w=1  w=2  w=3  w=4  w=5", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  i=0   0    0    0    0    0    0", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  i=1   0    0    3    3    3    3   (предмет A)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  i=2   0    0    3    4    4    7   (предмет A+B)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  i=3   0    0    3    4    5    7   (предмет A+B или A+C)", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Ответ: dp[3][5] = 7 (берем A и B: вес=2+3=5, ценность=3+4=7)", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ВОССТАНОВЛЕНИЕ ОТВЕТА:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Идем с конца: dp[3][5] = 7", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • dp[3][5] ≠ dp[2][5] (7 ≠ 7)? Нет, равны → предмет C не брали", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • dp[2][5] ≠ dp[1][5] (7 ≠ 3)? Да → предмет B взяли!", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    Осталось: w = 5 - 3 = 2", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • dp[1][2] ≠ dp[0][2] (3 ≠ 0)? Да → предмет A взяли!", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Итог: A + B ✓", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СЛОЖНОСТЬ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Время: O(n × W) — заполняем таблицу n × W", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Память: O(n × W) — таблица (можно оптимизировать до O(W))", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПОЧЕМУ НЕ ЖАДНЫЙ АЛГОРИТМ?", ConsoleColor.Red);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Жадный: берем предметы в порядке убывания v[i]/w[i]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Контрпример:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    W = 5", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    A: вес=3, цен=4 (ratio=1.33)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    B: вес=2, цен=3 (ratio=1.5)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    C: вес=2, цен=3 (ratio=1.5)", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Жадный: B + C = ценность 6, вес 4", ConsoleColor.Red);
        ConsoleHelper.WriteLineColored("  Но если бы был предмет D: вес=5, цен=7 (ratio=1.4)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Жадный: B + C = 6", ConsoleColor.Red);
        ConsoleHelper.WriteLineColored("  Оптимум: D = 7 ✓", ConsoleColor.Green);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Жадный НЕ гарантирует оптимальность для 0/1 рюкзака!", ConsoleColor.Red);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   КОГДА ПРИМЕНЯТЬ ДП:", ConsoleColor.Yellow);
        ConsoleHelper.WriteLineColored("  • Задача имеет оптимальную подструктуру", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Перекрывающиеся подзадачи", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Примеры: рюкзак, числа Фибоначчи, LCS, редакционное расстояние", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СВЯЗЬ С ДРУГИМИ ТЕМАМИ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Рекурсия (Top-Down подход)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Жадные алгоритмы (альтернатива, но не всегда работает)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Бинарный поиск (оптимизация ДП через двоичный поиск)", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.PressAnyKey();
    }
}