namespace AlgoExplorer.UI;

public static class ConsoleHelper
{
    public static void WriteColored(string text, ConsoleColor color)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = prev;
    }

    public static void WriteLineColored(string text, ConsoleColor color)
    {
        WriteColored(text, color);
        Console.WriteLine();
    }

    public static void WriteSeparator()
    {
        WriteLineColored(new string('─', 60), ConsoleColor.DarkGray);
    }

    public static void PressAnyKey()
    {
        WriteLineColored("\n  Нажмите любую клавишу для продолжения...", ConsoleColor.DarkGray);
        Console.ReadKey(true);
    }

    public static void ClearAndShow(Action content)
    {
        Console.Clear();
        content();
    }
}