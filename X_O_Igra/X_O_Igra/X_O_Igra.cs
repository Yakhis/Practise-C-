using System;

class X_O_igra
{
    static char[,] doska = new char[3, 3];
    static char Igrok = 'X';

    static void Main()
    {
        NachPol();
        Console.WriteLine("Игра Крестики-нолики");
        Pole();

        while (true)
        {
            Console.WriteLine($"Ход игрока {Igrok}");
            Hod();
            Pole();

            if (Win(Igrok))
            {
                Console.WriteLine($"Игрок {Igrok} победил");
                break;
            }
            else if (Nichya())
            {
                Console.WriteLine("Ничья");
                break;
            }

            Smena();
        }
    }

    static void NachPol()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                doska[i, j] = ' ';
    }

    static void Pole()
    {
        Console.WriteLine(" 0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + "");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(doska[i, j]);
                if (j < 2) Console.Write(" ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine(" ");
        }
    }

    static void Hod()
    {
        int str, stl;

        while (true)
        {
            Console.Write("Введите строку : ");
            bool VhodStr = int.TryParse(Console.ReadLine(), out str);

            Console.Write("Введите столбец : ");
            bool VhodStl = int.TryParse(Console.ReadLine(), out stl);

            if (VhodStr && VhodStr && str >= 0 && str < 3 && stl >= 0 && str < 3 && doska[str, stl] == ' ')
            {
                doska[str, stl] = Igrok;
                break;
            }
            else
            {
                Console.WriteLine("Данный ход недоступен. Попробуйте другой.");
            }
        }
    }
    static void Smena()
    {
        Igrok = (Igrok == 'X') ? 'O' : 'X';
    }

    static bool Win(char igr)
    {
        for (int i = 0; i < 3; i++)
            if ((doska[i, 0] == igr && doska[i, 1] == igr && doska[i, 2] == igr) || 
                (doska[0, i] == igr && doska[1, i] == igr && doska[2, i] == igr)) 
                return true;

        return (doska[0, 0] == igr && doska[1, 1] == igr && doska[2, 2] == igr) ||
               (doska[0, 2] == igr && doska[1, 1] == igr && doska[2, 0] == igr);
    }

    static bool Nichya()
    {
        foreach (char c in doska)
            if (c == ' ') return false;
        return true;
    }

    
}