using AlgoExplorer.Algorithms.Graph;
using AlgoExplorer.Theory;
using AlgoExplorer.UI;

namespace AlgoExplorer.Demos;

public static class GraphDemo
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.WriteLineColored("  ═══ ГРАФЫ ═══", ConsoleColor.Yellow);
            Console.WriteLine();
            ConsoleHelper.WriteLineColored("  Выберите режим:", ConsoleColor.White);
            ConsoleHelper.WriteColored("  [1] ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("Теория (BFS, DFS, Дейкстра)", ConsoleColor.Cyan);
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
                    GraphTheory.Show();
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
        ConsoleHelper.WriteLineColored("  ═══ ГРАФЫ: ПРАКТИКА ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        var g = new Graph();
        g.AddEdge(0, 1, 4); g.AddEdge(0, 2, 1); g.AddEdge(1, 3, 1);
        g.AddEdge(2, 1, 2); g.AddEdge(2, 3, 5); g.AddEdge(3, 4, 3);

        ConsoleHelper.WriteLineColored("  Граф (список смежности):", ConsoleColor.Green);
        foreach (var v in g.Vertices.OrderBy(x => x))
        {
            var neighbors = g.GetNeighbors(v);
            var desc = string.Join(", ", neighbors.Select(n => $"{n.To}(w:{n.Weight})"));
            ConsoleHelper.WriteColored($"    {v} → ", ConsoleColor.Cyan);
            Console.WriteLine(desc);
        }
        Console.WriteLine();

        ConsoleHelper.WriteColored("  BFS из 0: ", ConsoleColor.White);
        Console.WriteLine(string.Join(" → ", Bfs.Traverse(g, 0)));

        ConsoleHelper.WriteColored("  DFS из 0: ", ConsoleColor.White);
        Console.WriteLine(string.Join(" → ", Dfs.Traverse(g, 0)));

        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Кратчайшие пути (Дейкстра) из 0:", ConsoleColor.Green);
        var (dist, parents) = Dijkstra.ShortestPaths(g, 0);
        foreach (var v in dist.Keys.OrderBy(x => x))
        {
            var path = Dijkstra.ReconstructPath(parents, v);
            ConsoleHelper.WriteColored($"    До {v}: ", ConsoleColor.White);
            ConsoleHelper.WriteColored($"дистанция={dist[v]}", ConsoleColor.Yellow);
            Console.WriteLine($", путь: {string.Join(" → ", path)}");
        }

        ConsoleHelper.PressAnyKey();
    }
}
