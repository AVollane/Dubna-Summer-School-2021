using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаём вершины
            var n01 = new Node("А");
            var n02 = new Node("Б");
            var n03 = new Node("В");
            var n04 = new Node("Г");
            var n05 = new Node("Д");
            var n06 = new Node("Е");
            var n07 = new Node("Ж");
            var n08 = new Node("З");
            var n09 = new Node("И");
            var n10 = new Node("К");
            var n11 = new Node("Л");
            var n12 = new Node("М");

            // Добавляем отношения между элементами
            n01.AddChildren(new List<Node> { n02, n03, n04, n05 }); // 02, 03, 04, 04
            n02.AddChildren(new List<Node> { n06, n03 }); // 06, 03
            n03.AddChildren(new List<Node> { n07 }); // 07
            n04.AddChildren(new List<Node> { n03, n07 }); // 03, 07
            n05.AddChildren(new List<Node> { n04, n07, n08 }); // 04, 07, 08
            n06.AddChildren(new List<Node> { n07, n09 }); // 07, 09
            n07.AddChildren(new List<Node> { n09 }); // 09
            n08.AddChildren(new List<Node> { n07, n09 }); // 07, 09
            n09.AddChildren(new List<Node> { n10, n11 }); // 10, 11
            n11.AddChildren(new List<Node> { n10, n12 }); // 10, 12

            // Создаём объект класса поиска в глубину
            var search = new DepthFirstSearch();
            // Получаем самый длинный путь
            var path = search.DFS(n01, n12);
            // Выводим информацию о самом длинном пути
            PrintPath(path);
            Console.ReadLine();
        }

        // Метод, выводящий на экран самый длинный путь
        private static void PrintPath(LinkedList<Node> path)
        {
            Console.WriteLine();
            // Если этот путь имеется, конечно же
            if (path.Count == 0)
            {
                Console.WriteLine("Путей нет!");
            }
            // Путь имеется, выводим его длину
            else
            {
                Console.WriteLine(string.Join(" -> ", path.Select(x => x.Name)));
                Console.WriteLine($"Длина самого длинного пути равна {path.Count - 1}");
            }
        }
    }

    // Класс, представляющий вершину
    class Node
    {
        // Имя вершины.
        public string Name { get; }
        // Список соседних вершин.
        public List<Node> Children { get; }

        // Конструктор задаёт имя вершины и инициализирует список отношений
        public Node(string name)
        {
            Name = name;
            Children = new List<Node>();
        }

        // Добавляет коллекцию соседних вершин
        public Node AddChildren(List<Node> children)
        {
            Children.AddRange(children);
            return this;
        }
    }

    class DepthFirstSearch
    {
        // Список посещенных вершин
        private HashSet<Node> visited;
        // Путь из начальной вершины в целевую.
        private LinkedList<Node> path;
        // Конечная точка
        private Node goal;

        /// <summary>
        /// Поиск в глубину
        /// </summary>
        /// <param name="start">Стартовая вершина</param>
        /// <param name="goal">Конечная вершина</param>
        /// <returns>Связный список, хранящий самый длинный путь</returns>
        public LinkedList<Node> DFS(Node start, Node goal)
        {
            visited = new HashSet<Node>();
            path = new LinkedList<Node>();
            this.goal = goal;
            DFS(start);
            if (path.Count > 0)
            {
                path.AddFirst(start);
            }
            return path;
        }

        // Побочный метод для проверки
        private bool DFS(Node node)
        {
            if (node == goal)
            {
                return true;
            }
            visited.Add(node);
            foreach (var child in node.Children.Where(x => !visited.Contains(x)))
            {
                if (DFS(child)) // рекурсия
                {
                    path.AddFirst(child);
                    return true;
                }
            }
            return false;
        }
    }
}
