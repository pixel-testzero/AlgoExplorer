using AlgoExplorer.UI;

namespace AlgoExplorer.Theory;

public static class BstTheory
{
    public static void Show()
    {
        Console.Clear();
        ConsoleHelper.WriteLineColored("  ═══ ТЕОРИЯ: БИНАРНОЕ ДЕРЕВО ПОИСКА (BST) ═══", ConsoleColor.Yellow);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ИДЕЯ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  Бинарное дерево, где для ЛЮБОГО узла:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Все значения в ЛЕВОМ поддереве МЕНЬШЕ узла", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Все значения в ПРАВОМ поддереве БОЛЬШЕ узла", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПРИМЕР ДЕРЕВА:", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("         50", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("        /  \\", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("      30    70", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     /  \\   /  \\", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("   20   40 60   80", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  Проверка: 30 < 50 ✓, 20 < 30 ✓, 40 > 30 ✓", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("           70 > 50 ✓, 60 < 70 ✓, 80 > 70 ✓", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ОПЕРАЦИИ:", ConsoleColor.Magenta);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("  1. ПОИСК (Search):", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     Ищем 40 в дереве выше:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • 40 < 50 → идем ВЛЕВО к 30", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • 40 > 30 → идем ВПРАВО к 40", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • Нашли! ✓ (3 шага вместо 7)", ConsoleColor.Green);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("  2. ВСТАВКА (Insert):", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     Вставляем 25:", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • 25 < 50 → влево к 30", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • 25 < 30 → влево к 20", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     • 25 > 20 → вправо → создаем узел 25", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("  3. УДАЛЕНИЕ (Delete) — 3 случая:", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("     a) Лист (нет детей): просто удаляем", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     b) Один ребенок: заменяем узел ребенком", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("     c) Два ребенка: находим минимум в правом поддереве", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("        (наименьший больший), копируем его значение, удаляем", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СЛОЖНОСТЬ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Сбалансированное дерево: O(log n) — поиск, вставка, удаление", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Вырожденное (список): O(n) — худший случай", ConsoleColor.Cyan);
        ConsoleHelper.WriteLineColored("  • Память: O(n) — каждый узел хранит значение + 2 указателя", ConsoleColor.Cyan);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ОБХОДЫ ДЕРЕВА:", ConsoleColor.Magenta);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  • In-order (ЛКП):  Лево → Корень → Право", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    Результат: отсортированный массив! [20, 30, 40, 50, 60, 70, 80]", ConsoleColor.Green);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  • Pre-order (КЛП): Корень → Лево → Право", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    Используется для копирования дерева", ConsoleColor.White);
        Console.WriteLine();
        ConsoleHelper.WriteLineColored("  • Post-order (ЛПК): Лево → Право → Корень", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("    Используется для удаления дерева", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   ПЛЮСЫ:", ConsoleColor.Green);
        ConsoleHelper.WriteLineColored("  • Быстрый поиск O(log n) в среднем", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Динамическая структура (легко вставлять/удалять)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • In-order дает отсортированные данные", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   МИНУСЫ:", ConsoleColor.Red);
        ConsoleHelper.WriteLineColored("  • Может вырождаться в список O(n)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Решение: AVL-деревья, Красно-черные деревья (самобалансировка)", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   КОГДА ПРИМЕНЯТЬ:", ConsoleColor.Yellow);
        ConsoleHelper.WriteLineColored("  • Нужен быстрый поиск/вставка/удаление", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Данные динамически меняются (в отличие от отсортированного массива)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Реализация словарей, множеств, индексов в БД", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.WriteLineColored("   СВЯЗЬ С ДРУГИМИ ТЕМАМИ:", ConsoleColor.Magenta);
        ConsoleHelper.WriteLineColored("  • Рекурсия (все операции рекурсивные)", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Бинарный поиск (принцип 'отбрасывания половины')", ConsoleColor.White);
        ConsoleHelper.WriteLineColored("  • Графы (дерево — частный случай графа)", ConsoleColor.White);
        Console.WriteLine();

        ConsoleHelper.PressAnyKey();
    }
}