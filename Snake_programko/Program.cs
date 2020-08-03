using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Snake_programko {

    class Program {
        public static bool WallCheck(ref LinkedListNode<SnakeNode> node) {

            if ((node.Value.CooX == 0) || (node.Value.CooX == 59) || (node.Value.CooY == 0) || (node.Value.CooY == 29))
                return true;
            return false;
        }
        public static void FoodCheck(ref LinkedListNode<SnakeNode> node, Food f) {
            if ((node.Value.CooX == f.CooX) && (node.Value.CooY == f.CooY))
                f.Eaten = true;

        }
        public static void Direction(ref LinkedList<SnakeNode> Snake, LinkedListNode<SnakeNode> node, ref int dir, Random rng, Food f) {
            while (true) {
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo a = Console.ReadKey();

                if (Snake.Count >= 1) {
                    switch (a.KeyChar) {
                        case 'w': if (!(dir == 2)) dir = 1; break;
                        case 's': if (!(dir == 1)) dir = 2; break;
                        case 'a': if (!(dir == 4)) dir = 3; break;
                        case 'd': if (!(dir == 3)) dir = 4; break;
                    }
                    Move(ref Snake, node, ref dir, rng, f);
                }
                else {
                    switch (a.KeyChar) {
                        case 'w': dir = 1; break;
                        case 's': dir = 2; break;
                        case 'a': dir = 3; break;
                        case 'd': dir = 4; break;
                    }
                    Move(ref Snake, node, ref dir, rng, f);
                }
            }
        }
        public static void Move(ref LinkedList<SnakeNode> Snake, LinkedListNode<SnakeNode> node, ref int dir, Random rng, Food f) {
            while (!WallCheck(ref node)) {
                FoodCheck(ref node, f);
                Console.ForegroundColor = ConsoleColor.Black;
                if (Console.KeyAvailable)
                    break;
                switch (dir) {
                    case 1: Snake.AddFirst(new LinkedListNode<SnakeNode>(new SnakeNode(1, node.Value.CooX, node.Value.CooY--, 1, 1))); break;
                    case 2: Snake.AddFirst(new LinkedListNode<SnakeNode>(new SnakeNode(1, node.Value.CooX, node.Value.CooY++, 1, 1))); break;
                    case 3: Snake.AddFirst(new LinkedListNode<SnakeNode>(new SnakeNode(1, node.Value.CooX--, node.Value.CooY, 1, 1))); break;
                    case 4: Snake.AddFirst(new LinkedListNode<SnakeNode>(new SnakeNode(1, node.Value.CooX++, node.Value.CooY, 1, 1))); break;
                }
                if (f.Eaten) {
                    f.CooX = rng.Next(2, 58);
                    f.CooY = rng.Next(2, 28);
                    CreateFood(rng, f);
                    f.Eaten = false;
                }
                else {
                    CreateFood(rng, f);
                    Console.SetCursorPosition(Snake.Last.Value.CooX, Snake.Last.Value.CooY);
                    Console.Write(" ");
                    Snake.RemoveLast();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(node.Value.CooX, node.Value.CooY);
                Console.Write("■");
                if ((dir == 1) || (dir == 2))
                    Thread.Sleep(230);
                if ((dir == 3) || (dir == 4))
                    Thread.Sleep(180);
            }

        }
        public static void CreateFood(Random rng, Food f) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(f.CooX, f.CooY);
            Console.Write("x");
        }
        static void Main(string[] args) {
            int dir = 4;
            Random rng = new Random();

            LinkedList<SnakeNode> Snake = new LinkedList<SnakeNode>();
            LinkedListNode<SnakeNode> node = new LinkedListNode<SnakeNode>(new SnakeNode(1, 30, 15, 4, 5));

            Food f = new Food();
            f.CooX = rng.Next(2, 58);
            f.CooY = rng.Next(2, 28);

            Console.WindowWidth = 60;
            Console.WindowHeight = 30;
            Console.SetBufferSize(60, 30);
            Console.CursorVisible = false;
            Console.Title = "Snake";
            Console.SetCursorPosition(20, 12);
            Console.WriteLine("Start with W,S,A,D");
            while (true) {
               if (Console.KeyAvailable) {
                    Console.Clear();
                    Direction(ref Snake, node, ref dir, rng, f);
              }
           }
        }
    }
}
