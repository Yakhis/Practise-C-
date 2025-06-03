using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;         // Почитать про потоки и асинхронную работу 

namespace ZmeikaGame
{
    class ZmeikaG
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Game game = new Game(20, 40);
            game.Start();
        }
    }

    class Game
    {
        private int hPol;
        private int wPol;
        private Zmeika zmeika;
        private Eda eda;
        private List<Point> prepyat;
        private bool gameOver;

        public Game(int height, int width)
        {
            this.hPol = height;
            this.wPol = width;
            prepyat = new List<Point>();
        }

        public void Start()
        {
            Console.Clear();
            Gran();
            Prepyat();

            zmeika = new Zmeika(wPol / 2, hPol / 2);
            eda = new Eda(wPol, hPol, zmeika, prepyat);
            eda.RandFood();

            Thread inputThread = new Thread(Input);
            inputThread.Start();

            while (!gameOver)
            {
                zmeika.Move();

                if (zmeika.Head.X == eda.Position.X && zmeika.Head.Y == eda.Position.Y) // Боже храни Linq
                {
                    zmeika.Rost();
                    eda.RandFood();
                }

                if (zmeika.Collision(wPol, hPol) || prepyat.Any(o => o.X == zmeika.Head.X && o.Y == zmeika.Head.Y))
                {
                    gameOver = true;
                    break;
                }

                Thread.Sleep(150);
            }

            Console.SetCursorPosition(0, hPol + 2);
            Console.ResetColor();
            Console.WriteLine("Игра окончена. Вы проиграли.");
        }

        private void Gran()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 0; x < wPol; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("#");
                Console.SetCursorPosition(x, hPol - 1);
                Console.Write("#");
            }

            for (int y = 0; y < hPol; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#");
                Console.SetCursorPosition(wPol - 1, y);
                Console.Write("#");
            }
            Console.ResetColor();
        }

        private void Prepyat()
        {
            Random rand = new Random();
            int PrepyatCount = (wPol * hPol) / 50; 

            for (int i = 0; i < PrepyatCount; i++)
            {
                int x = rand.Next(2, wPol - 2);
                int y = rand.Next(2, hPol - 2);
                Point point = new Point(x, y);
                prepyat.Add(point);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x, y);
                Console.Write("X");
            }
            Console.ResetColor();
        }

        private void Input()
        {
            while (!gameOver)
            {
                var key = Console.ReadKey(true).Key;
                zmeika.ChangeDirection(key);
            }
        }
    }

    class Zmeika
    {
        private List<Point> body;
        private Direction current;

        public Zmeika(int startX, int startY)
        {
            body = new List<Point>
            {
                new Point(startX, startY)
            };
            current = Direction.Right;
        }

        public Point Head => body[0];

        public void Move()
        {
            Point next = GetPoint();

            body.Insert(0, next);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(next.X, next.Y);
            Console.Write("s");

            Point tail = body.Last();
            Console.SetCursorPosition(tail.X, tail.Y);
            Console.Write(" ");
            body.RemoveAt(body.Count - 1);
            Console.ResetColor();
        }

        public void Rost()
        {
            Point next = GetPoint();
            body.Insert(0, next);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(next.X, next.Y);
            Console.Write("s");
            Console.ResetColor();
        }

        private Point GetPoint()
        {
            Point head = Head;
            return current switch
            {
                Direction.Up => new Point(head.X, head.Y - 1),
                Direction.Down => new Point(head.X, head.Y + 1),
                Direction.Left => new Point(head.X - 1, head.Y),
                Direction.Right => new Point(head.X + 1, head.Y),
                _ => head
            };
        }

        public void ChangeDirection(ConsoleKey key)
        {
            Direction newDir = current;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (current != Direction.Down) newDir = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    if (current != Direction.Up) newDir = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    if (current != Direction.Right) newDir = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    if (current != Direction.Left) newDir = Direction.Right;
                    break;
            }
            current = newDir;
        }

        public bool Collision(int widthC, int heightC)
        {
            if (Head.X <= 0 || Head.X >= widthC - 1 || Head.Y <= 0 || Head.Y >= heightC - 1)
                return true;

            for (int i = 1; i < body.Count; i++)
                if (body[i].X == Head.X && body[i].Y == Head.Y)
                    return true;

            return false;
        }

        public List<Point> Body => body;
    }

    class Eda
    {
        private int wPol;
        private int hPol;
        private Zmeika zmeika;
        private List<Point> prepyat;
        public Point Position { get; private set; }

        public Eda(int widthE, int heightE, Zmeika snake, List<Point> prepyat)
        {
            this.wPol = widthE;
            this.hPol = heightE;
            this.zmeika = snake;
            this.prepyat = prepyat;
        }

        public void RandFood()
        {
            Random rand = new Random();
            Point pos;
            do
            {
                pos = new Point(rand.Next(1, wPol - 2), rand.Next(1, hPol - 2));
            } while (zmeika.Body.Any(p => p.X == pos.X && p.Y == pos.Y) ||
                     prepyat.Any(p => p.X == pos.X && p.Y == pos.Y));

            Position = pos;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write("@");
            Console.ResetColor();
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }

    enum Direction
    {
        Up, Down, Left, Right
    }
}