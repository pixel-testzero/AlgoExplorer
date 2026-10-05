using AlgoExplorer.Algorithms.DP;
using AlgoExplorer.Theory;
using AlgoExplorer.UI;

namespace AlgoExplorer.Demos;

public static class DpDemo
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.WriteLineColored("  ═══ ДИНАМИЧЕСКОЕ ПРОГРАММИРОВАНИЕ ═══", ConsoleColor.Yellow);
            Console.WriteLine();
            ConsoleHelper.WriteLineColored("  Выберите режим:", ConsoleColor.White);
            ConsoleHelper.WriteColored("  [1] ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("Теория (подробное объяснение)", ConsoleColor.Cyan);
            ConsoleHelper.WriteColored("  [2] ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("Практика (задача о рюкзаке)", ConsoleColor.Green);
            ConsoleHelper.WriteColored("  [0] ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("Назад в главное меню", ConsoleColor.Red);
            Console.WriteLine();

            Console.Write("  Ваш выбор: ");
            var choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    DpTheory.Show();
                    break;
                case "2":
                    ShowPractice();
                    break;
                case "0":
                    return;
                default:
                    ConsoleHelper.WriteLineColored("  Неверный ввод!", ConsoleColor.Red);
                    ConsoleHelper.PressAnyKey();
                    break;
            }
        }
    }

    private static void ShowPractice()
    {
        Console.Clear();
        ConsoleHelper.WriteLineColored("  ═══ ДП: ПРАКТИКА (Рюкзак 0/1) ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        var items = new Knapsack.Item[]
        {
            new("Ноутбук", 3, 4), new("Книга", 1, 1), new("Камера", 2, 3),
            new("Телефон", 2, 2), new("Планшет", 4, 5),
        };
        int capacity = 6;

        ConsoleHelper.WriteLineColored($"  Вместимость рюкзака: {capacity} кг", ConsoleColor.White);
        foreach (var item in items)
            Console.WriteLine($"    • {item.Name}: вес={item.Weight}, ценность={item.Value}");

        Console.WriteLine();
        var (maxValue, selected) = Knapsack.Solve(capacity, items);

        ConsoleHelper.WriteColored("  Максимальная ценность: ", ConsoleColor.White);
        ConsoleHelper.WriteLineColored(maxValue.ToString(), ConsoleColor.Green);

        ConsoleHelper.WriteLineColored("  Оптимальный набор:", ConsoleColor.White);
        foreach (var item in selected)
            ConsoleHelper.WriteLineColored($"    ✓ {item.Name} (вес={item.Weight}, ценность={item.Value})", ConsoleColor.Cyan);

        ConsoleHelper.PressAnyKey();
    }
}