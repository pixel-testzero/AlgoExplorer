using AlgoExplorer.DataStructures.BST;
using AlgoExplorer.Theory;
using AlgoExplorer.UI;

namespace AlgoExplorer.Demos;

public static class BstDemo
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.WriteLineColored("  ═══ БИНАРНОЕ ДЕРЕВО ПОИСКА (BST) ═══", ConsoleColor.Yellow);
            Console.WriteLine();
            ConsoleHelper.WriteLineColored("  Выберите режим:", ConsoleColor.White);
            ConsoleHelper.WriteColored("  [1] ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("Теория (подробное объяснение)", ConsoleColor.Cyan);
            ConsoleHelper.WriteColored("  [2] ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("Практика (демонстрация работы)", ConsoleColor.Green);
            ConsoleHelper.WriteColored("  [0] ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("Назад в главное меню", ConsoleColor.Red);
            Console.WriteLine();

            Console.Write("  Ваш выбор: ");
            var choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    BstTheory.Show();
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
        ConsoleHelper.WriteLineColored("  ═══ BST: ПРАКТИКА ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        var bst = new BinarySearchTree();
        int[] values = [50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 45];

        ConsoleHelper.WriteColored("  Вставляем: ", ConsoleColor.White);
        Console.WriteLine(string.Join(", ", values));

        foreach (var v in values) bst.Insert(v);

        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Визуализация дерева:", ConsoleColor.Green);
        Console.WriteLine();
        foreach (var line in bst.Visualize().Split('\n'))
            ConsoleHelper.WriteLineColored("    " + line, ConsoleColor.Cyan);

        Console.WriteLine();
        ConsoleHelper.WriteColored("  In-order обход: ", ConsoleColor.White);
        Console.WriteLine(string.Join(", ", bst.InOrder()));

        Console.WriteLine();
        int searchVal = 35;
        ConsoleHelper.WriteColored($"  Поиск {searchVal}: ", ConsoleColor.White);
        ConsoleHelper.WriteLineColored(bst.Search(searchVal) ? "Найден ✓" : "Не найден ✗", ConsoleColor.Green);

        searchVal = 99;
        ConsoleHelper.WriteColored($"  Поиск {searchVal}: ", ConsoleColor.White);
        ConsoleHelper.WriteLineColored(bst.Search(searchVal) ? "Найден ✓" : "Не найден ✗", ConsoleColor.Red);

        ConsoleHelper.PressAnyKey();
    }
}