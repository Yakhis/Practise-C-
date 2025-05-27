using System;


class Podob_Treug
{
    static void Main()
    {
        Console.WriteLine("Введите длину стороны первого треугольника :");
        int stor1_1 = Convert.ToInt32 (Console.ReadLine());
        Console.WriteLine("Введите длину стороны первого треугольника :");
        int stor2_1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите длину стороны первого треугольника :");
        int stor3_1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите длину стороны второго треугольника :");
        int stor1_2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите длину стороны второго треугольника :");
        int stor2_2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите длину стороны второго треугольника :");
        int stor3_2 = Convert.ToInt32(Console.ReadLine());

        double otn1 = stor1_1 / stor1_2;
        double otn2 = stor2_1 / stor2_2;
        double otn3 = stor3_1 / stor3_2;

        const double epsilon = 1e-6;

        if (Math.Abs(otn1 - otn2) < epsilon && Math.Abs(otn2 - otn3) < epsilon)
        {
            Console.WriteLine("да");
        }
        else
        {
            Console.WriteLine("нет");
        }
    }
}