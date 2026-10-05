using AlgoExplorer.Algorithms.Sorting;
using AlgoExplorer.Theory;
using AlgoExplorer.UI;

namespace AlgoExplorer.Demos;

public static class SortingDemo
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.WriteLineColored("  ═══ СОРТИРОВКИ ═══", ConsoleColor.Yellow);
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
                    SortingTheory.Show();
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
        ConsoleHelper.WriteLineColored("  ═══ СОРТИРОВКИ: ПРАКТИКА ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        int[] original = [38, 27, 43, 3, 9, 82, 10, 1, 57, 24];
        ConsoleHelper.WriteColored("  Исходный массив: ", ConsoleColor.White);
        Console.WriteLine(string.Join(", ", original));
        Console.WriteLine();

        ISorter[] sorters = [new MergeSort(), new QuickSort()];

        foreach (var sorter in sorters)
        {
            ConsoleHelper.WriteColored($"  ► {sorter.Name}", ConsoleColor.Green);
            Console.WriteLine();
            var sorted = sorter.Sort(original);
            ConsoleHelper.WriteColored("    Результат:     ", ConsoleColor.DarkGray);
            Console.WriteLine(string.Join(", ", sorted));
            Console.WriteLine();
        }

        ConsoleHelper.PressAnyKey();
    }
}