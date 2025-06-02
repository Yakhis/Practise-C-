using System;

class Prigl_e
{
    static void Main()
    {
        Console.Write("Введите значение x (-1 <= x <= 1): ");
        double x = Convert.ToDouble(Console.ReadLine());

        double slag = 1;
        double sum = 1;
        int n = 1;

        while (Math.Abs(slag) >= 1e-6)
        {
            slag *= x / n;
            sum += slag;
            n++;
        }

        Console.WriteLine($"Приближенное значение e^{x} = {sum}");
    }
}