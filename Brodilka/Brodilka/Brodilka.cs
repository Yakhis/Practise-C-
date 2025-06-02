using System;
using System.Threading;

class Program
{
    static char[,] map = new char[10, 10];
    static int cordX, cordY;
    static ConsoleColor defaultColor = ConsoleColor.White;

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        NewMap();
        while (true)
        {
            Console.Clear();
            Map();

            if (Win())
            {
                Console.WriteLine("Ура, +IQ");
                break;
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.F)
            break;

            Knopki(key);
        }
    }

    static void NewMap()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                map[i, j] = '#';

        map[1, 1] = 'T';
        map[0, 1] = 'T';
        map[2, 1] = 'T';
        map[2, 3] = 'T';
        map[5, 6] = 'T';
        map[3, 1] = 'T';
        map[5, 7] = 'T';
        map[8, 6] = 'T';
        map[2, 5] = 'T';
        map[6, 6] = 'T';

        map[5, 4] = 'O';
        map[9, 7] = 'O';
        map[2, 7] = 'O';

        map[3, 4] = 'R';
        map[6, 5] = 'R';

        cordX = 0;
        cordY = 0;
        map[cordX, cordY] = 'C';
    }

    static void Map()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                char c = map[i, j];
                Console.ForegroundColor = Textures(c);
                Console.Write(c);
                Console.ForegroundColor = defaultColor;
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nУправление: W/A/S/D – ход, сдаться - F");
    }

    static void Knopki(ConsoleKey key)
    {
        int dx = 0, dy = 0;
        switch (key)
        {
            case ConsoleKey.W: dx = -1; break;
            case ConsoleKey.S: dx = 1; break;
            case ConsoleKey.A: dy = -1; break;
            case ConsoleKey.D: dy = 1; break;
        }

        int newX = cordX + dx;
        int newY = cordY + dy;

        if (!Grani(newX, newY)) return;

        char cel = map[newX, newY];

        if (cel == '#' || cel == 'O')
        {
            Perem(newX, newY);
        }
        else if (cel == 'R' || cel == 'Ⓡ')
        {
            int pushX = newX + dx;
            int pushY = newY + dy;
            if (!Grani(pushX, pushY)) return;

            char behind = map[pushX, pushY];
            if (behind == '#' || behind == 'O')
            {
                map[pushX, pushY] = (behind == 'O') ? 'Ⓡ' : 'R';
                map[newX, newY] = (cel == 'Ⓡ') ? 'O' : '#';
                Perem(newX, newY);
            }
        }
    }

    static void Perem(int x, int y)
    {
        map[cordX, cordY] = (map[cordX, cordY] == 'Ⓒ') ? 'O' : '#';
        cordX = x;
        cordY = y;
        map[cordX, cordY] = (map[cordX, cordY] == 'O') ? 'Ⓒ' : 'C';
    }

    static bool Grani(int x, int y) => x >= 0 && x < 10 && y >= 0 && y < 10;

    static bool Win()
    {
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
                if (map[i, j] == 'O')
                    return false;
        return true;
    }
    static ConsoleColor Textures(char c)
    {
        return c switch
        {
            '#' => ConsoleColor.DarkGreen,
            'T' => ConsoleColor.DarkYellow,
            'O' => ConsoleColor.Cyan,
            'R' => ConsoleColor.Gray,
            'Ⓡ' => ConsoleColor.Blue,
            'Ⓒ' => ConsoleColor.DarkMagenta,
            'C' => ConsoleColor.Yellow,
            _ => defaultColor,
        };
    }

}

