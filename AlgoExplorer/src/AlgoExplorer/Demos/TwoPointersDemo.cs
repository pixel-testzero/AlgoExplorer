using AlgoExplorer.Algorithms.TwoPointers;
using AlgoExplorer.Theory;
using AlgoExplorer.UI;

namespace AlgoExplorer.Demos;

public static class TwoPointersDemo
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.WriteLineColored("  ═══ ТЕХНИКА ДВУХ УКАЗАТЕЛЕЙ ═══", ConsoleColor.Yellow);
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
                    TwoPointersTheory.Show();
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
        ConsoleHelper.WriteLineColored("  ═══ ДВА УКАЗАТЕЛЯ: ПРАКТИКА ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        int[] arr = [1, 3, 5, 7, 9, 11, 15, 18];
        ConsoleHelper.WriteColored("  Отсортированный массив: ", ConsoleColor.White);
        Console.WriteLine(string.Join(", ", arr));
        Console.WriteLine();

        int[] targets = [12, 20, 100];
        foreach (var target in targets)
        {
            ConsoleHelper.WriteColored($"  Ищем пару с суммой {target}: ", ConsoleColor.White);
            var result = PairSum.Find(arr, target);
            if (result is var (i, j))
            {
                ConsoleHelper.WriteLineColored(
                    $"Найдена! arr[{i}]={arr[i]} + arr[{j}]={arr[j]}",
                    ConsoleColor.Green);
            }
            else
            {
                ConsoleHelper.WriteLineColored("Не найдена ✗", ConsoleColor.Red);
            }
        }

        ConsoleHelper.PressAnyKey();
    }
}