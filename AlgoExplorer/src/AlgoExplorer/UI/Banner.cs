namespace AlgoExplorer.UI;

public static class Banner
{
    private static readonly string[] Logo =
    [
        @"  █████╗ ██╗      ██████╗  ██████╗ ██████╗ ",
        @" ██╔══██╗██║     ██╔════╝ ██╔═══██║██╔══██╗",
        @" ███████║██║     ██║  ███╗██║   ██║██║  ██║",
        @" ██╔══██║██║     ██║   ██║██║   ██║██║  ██║",
        @" ██║  ██║███████╗╚██████╔╝╚██████╔╝██████╔╝",
        @" ╚═╝  ╚═╝╚══════╝ ╚═════╝  ╚═════╝ ╚═════╝ "
    ];

    private const string Subtitle = "A L G O R I T H M   D A T A";
    private const string Tagline  = "Интерактивный исследователь алгоритмов и структур данных";

    public static void Show()
    {
        Console.Clear();
        ConsoleHelper.WriteLineColored("  ╔" + new string('═', 58) + "╗", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  ║" + new string(' ', 58) + "║", ConsoleColor.Cyan);

        foreach (var line in Logo)
        {
            var padded = line.PadRight(56);
            ConsoleHelper.WriteColored("  ║  ", ConsoleColor.Cyan);
            ConsoleHelper.WriteColored(padded, ConsoleColor.Yellow);
            ConsoleHelper.WriteLineColored("║", ConsoleColor.Cyan);
        }

        ConsoleHelper.WriteLineColored("  ║" + new string(' ', 58) + "║", ConsoleColor.Cyan);

        var subPadded = Subtitle.PadLeft((58 + Subtitle.Length) / 2).PadRight(58);
        ConsoleHelper.WriteColored("  ║", ConsoleColor.Cyan);
        ConsoleHelper.WriteColored(subPadded, ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("║", ConsoleColor.Cyan);

        ConsoleHelper.WriteLineColored("  ║" + new string(' ', 58) + "║", ConsoleColor.Cyan);

        var tagPadded = Tagline.PadLeft((58 + Tagline.Length) / 2).PadRight(58);
        ConsoleHelper.WriteColored("  ║", ConsoleColor.Cyan);
        ConsoleHelper.WriteColored(tagPadded, ConsoleColor.DarkGray);
        ConsoleHelper.WriteLineColored("║", ConsoleColor.Cyan);

        ConsoleHelper.WriteLineColored("  ║" + new string(' ', 58) + "║", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  ╚" + new string('═', 58) + "╝", ConsoleColor.Cyan);
        Console.WriteLine();
    }
}