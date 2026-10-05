namespace AlgoExplorer.UI;

public class MenuItem
{
    public string Key { get; }
    public string Title { get; }
    public string Description { get; }
    public Action Action { get; }

    public MenuItem(string key, string title, string description, Action action)
    {
        Key = key;
        Title = title;
        Description = description;
        Action = action;
    }
}

public static class Menu
{
    public static void Show(List<MenuItem> items)
    {
        ConsoleHelper.WriteSeparator();
        ConsoleHelper.WriteLineColored("  Выберите тему для изучения:\n", ConsoleColor.White);

        foreach (var item in items)
        {
            ConsoleHelper.WriteColored($"  [{item.Key}] ", ConsoleColor.Yellow);
            ConsoleHelper.WriteColored(item.Title, ConsoleColor.Green);
            ConsoleHelper.WriteLineColored($" — {item.Description}", ConsoleColor.DarkGray);
        }

        ConsoleHelper.WriteSeparator();
        ConsoleHelper.WriteColored("  [0] ", ConsoleColor.Yellow);
        ConsoleHelper.WriteLineColored("Выход", ConsoleColor.Red);
        ConsoleHelper.WriteSeparator();
    }

    public static string? ReadChoice(List<MenuItem> items)
    {
        while (true)
        {
            Console.Write("\n  Ваш выбор: ");
            var input = Console.ReadLine()?.Trim();

            if (input == "0") return null;
            if (items.Any(i => i.Key.Equals(input, StringComparison.OrdinalIgnoreCase)))
                return input;

            ConsoleHelper.WriteLineColored("  Неверный ввод. Попробуйте ещё раз.", ConsoleColor.Red);
        }
    }
}