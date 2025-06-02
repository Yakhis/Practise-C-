using System;

class Krug
{
    static void Main()
    {
        Console.WriteLine("Введите радиус окружности: ");
        int rad = Convert.ToInt32(Console.ReadLine()); 
        double tol = 0.5;

        for (int y = rad; y >= -rad; y--)
        {
            for (int x = -rad; x <= rad; x++)
            {
                double promej = Math.Sqrt(x * x + y * y);

                if (promej >= rad - tol && promej <= rad + tol)
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}