using AlgoExplorer.UI;

namespace AlgoExplorer.Theory;

public static class GraphTheory
{
    public static void Show()
    {
        Console.Clear();
        ConsoleHelper.WriteLineColored("  ═══ ТЕОРИЯ: ГРАФЫ (BFS, DFS, Дейкстра) ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ЧТО ТАКОЕ ГРАФ?", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Граф = Вершины (V) + Рёбра (E)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Неориентированный: ребро A-B = ребро B-A", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Ориентированный: ребро A→B ≠ ребро B→A", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Взвешенный: у ребра есть 'стоимость' (вес)", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПРЕДСТАВЛЕНИЕ ГРАФА:", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  1. Матрица смежности (V×V):", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     [0 1 1]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     [1 0 0]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     [1 0 0]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     Память: O(V²), проверка ребра: O(1)", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  2. Список смежности (наш выбор):", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     0 → [1, 2]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     1 → [0]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     2 → [0]", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     Память: O(V+E), перебор соседей: O(deg(v))", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteSeparator();
        Console.WriteLine();

        // === BFS ===
        ConsoleHelper.WriteLineColored("  ┌─────────────────────────────────────────────────┐", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  │  1. BFS (Поиск в ширину)                        │", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  └─────────────────────────────────────────────────┘", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ИДЕЯ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Обходим граф 'слоями'. Сначала все соседи старта,", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  потом их соседи, и так далее. Используем ОЧЕРЕДЬ (FIFO).", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПСЕВДОКОД:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("  bfs(start):", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    queue = [start]", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    visited = {start}", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    while queue не пуста:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      v = queue.dequeue()", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      process(v)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      for each neighbor of v:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("        if neighbor not in visited:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("          visited.add(neighbor)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("          queue.enqueue(neighbor)", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПРИМЕР: Граф 0-1, 0-2, 1-3, 2-3, 3-4", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  BFS из 0:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    Слой 0: [0]", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("    Слой 1: [1, 2]  (соседи 0)", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("    Слой 2: [3]     (соседи 1 и 2, но 3 еще не посещен)", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("    Слой 3: [4]     (сосед 3)", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  Порядок: 0 → 1 → 2 → 3 → 4", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СЛОЖНОСТЬ: O(V + E) время, O(V) память", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("   ПРИМЕНЕНИЕ:", ConsoleColor.Yellow);
        ConsoleHelper.WriteLineColored("  • Кратчайший путь в НЕВЗВЕШЕННОМ графе", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Обход всех достижимых вершин", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Проверка связности", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteSeparator();
        Console.WriteLine();

        // === DFS ===
        ConsoleHelper.WriteLineColored("  ┌─────────────────────────────────────────────────┐", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  │  2. DFS (Поиск в глубину)                       │", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  └─────────────────────────────────────────────────┘", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("  💡 ИДЕЯ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Идем вглубь графа до тупика, затем откатываемся.", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Используем СТЕК (LIFO) или РЕКУРСИЮ.", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПСЕВДОКОД (рекурсия):", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("  dfs(v, visited):", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    visited.add(v)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    process(v)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    for each neighbor of v:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      if neighbor not in visited:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("        dfs(neighbor, visited)", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПРИМЕР: Тот же граф", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  DFS из 0:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    0 → 1 → 3 → 4 (тупик, откат к 3)", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("    3 → 2 (откат к 0)", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  Порядок: 0 → 1 → 3 → 4 → 2", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СЛОЖНОСТЬ: O(V + E) время, O(V) память (стек)", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("   ПРИМЕНЕНИЕ:", ConsoleColor.Yellow);
        ConsoleHelper.WriteLineColored("  • Топологическая сортировка", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Поиск компонент связности", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Поиск циклов", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Обход лабиринтов", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   BFS vs DFS:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • BFS: кратчайший путь (невзвешенный), обход слоями", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • DFS: экономит память, хорош для полного обхода", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteSeparator();
        Console.WriteLine();

        // === DIJKSTRA ===
        ConsoleHelper.WriteLineColored("  ┌─────────────────────────────────────────────────┐", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  │  3. АЛГОРИТМ ДЕЙКСТРЫ                           │", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  └─────────────────────────────────────────────────┘", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ИДЕЯ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Жадный алгоритм для КРАТЧАЙШИХ путей во ВЗВЕШЕННОМ графе.", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Всегда выбираем вершину с МИНИМАЛЬНЫМ расстоянием.", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Используем ПРИОРИТЕТНУЮ ОЧЕРЕДЬ (min-heap).", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПСЕВДОКОД:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("  dijkstra(start):", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    dist[v] = ∞ для всех v", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    dist[start] = 0", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    pq = приоритетная очередь с (start, 0)", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("    while pq не пуста:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      (u, d) = pq.extractMin()", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      if d > dist[u]: continue  // устаревшая запись", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("      for each (v, weight) neighbor of u:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("        if dist[u] + weight < dist[v]:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("          dist[v] = dist[u] + weight", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("          pq.insert(v, dist[v])", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПРИМЕР:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Граф: 0→1(4), 0→2(1), 2→1(2), 1→3(1)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  Кратчайший путь из 0 в 3:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    Шаг 1: dist = [0, ∞, ∞, ∞], pq = [(0, 0)]", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("    Шаг 2: берем 0, обновляем: dist = [0, 4, 1, ∞]", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("    Шаг 3: берем 2 (мин), обновляем: dist = [0, 3, 1, ∞]", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("           (через 2→1 дешевле: 1+2=3 < 4)", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("    Шаг 4: берем 1, обновляем: dist = [0, 3, 1, 4]", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("    Шаг 5: берем 3, готово!", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  Путь: 0 → 2 → 1 → 3, длина = 4", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СЛОЖНОСТЬ: O((V + E) log V) с приоритетной очередью", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("   ОГРАНИЧЕНИЯ:", ConsoleColor.Red);
        ConsoleHelper.WriteLineColored("  • НЕ работает с ОТРИЦАТЕЛЬНЫМИ весами!", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Для отрицательных весов используйте алгоритм Беллмана-Форда", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПРИМЕНЕНИЕ:", ConsoleColor.Yellow);
        ConsoleHelper.WriteLineColored("  • GPS-навигация (кратчайший маршрут)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Сетевая маршрутизация", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Игры (поиск пути)", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.PressAnyKey();
    }
}