using AlgoExplorer.Demos;
using AlgoExplorer.UI;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var menuItems = new List<MenuItem>
{
    new("1", "Сортировки",           "Merge Sort и Quick Sort с визуализацией",   SortingDemo.Run),
    new("2", "BST",                  "Бинарное дерево поиска: вставка, поиск",    BstDemo.Run),
    new("3", "Графы",                "BFS, DFS, алгоритм Дейкстры",               GraphDemo.Run),
    new("4", "Дин. программирование","Задача о рюкзаке 0/1",                       DpDemo.Run),
    new("5", "Два указателя",        "Поиск пары с заданной суммой",              TwoPointersDemo.Run),
};

bool running = true;
while (running)
{
    Banner.Show();
    Menu.Show(menuItems);

    var choice = Menu.ReadChoice(menuItems);
    if (choice is null)
    {
        running = false;
        ConsoleHelper.WriteLineColored("\n  До свидания! 👋\n", ConsoleColor.Magenta);
    }
    else
    {
        var item = menuItems.First(i => i.Key == choice);
        item.Action();
    }
}