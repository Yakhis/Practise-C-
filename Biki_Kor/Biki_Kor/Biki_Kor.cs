using System;

class Biki_Kor
{
    static void Main()
    {
        Console.WriteLine("Игра: Быки и Коровы");

        Console.WriteLine("Введите четырехзначное число для начала игры : ");
        string Numb = Console.ReadLine();
        int popitok = 0;

        while (true)
        {
            Console.Write("Ваше предположение : ");
            string guess = Console.ReadLine();

            popitok++;

            int Bik = CountBik(Numb, guess);
            int Kor = CountKor(Numb, guess) - Bik;

            Console.WriteLine($"{Bik} бык(а,ов), {Kor} коров(а,ы)");

            if (Bik == 4)
            {
                Console.WriteLine($"Число угадано {Numb} за {popitok} попытку(ки,ок).");
                break;
            }
        }
    }

    static int CountBik(string secret, string guess)
    {
        int Bik = 0;
        for (int i = 0; i < 4; i++)
        {
            if (secret[i] == guess[i])
                Bik++;
        }
        return Bik;
    }

    static int CountKor(string secret, string guess)
    {
        int Kor = 0;
        foreach (char c in guess)
        {
            if (secret.Contains(c))
                Kor++;
        }
        return Kor;
    }
}