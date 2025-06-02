using System;
using System.Collections.Generic;

class Quiz
{
    class Vopros
    {
        public string Text { get; set; }
        public string[] Varianti { get; set; }
        public int Otvet { get; set; }
    }

    static void Main()
    {
        List<Vopros> vopros = new List<Vopros>
        {
            new Vopros {
                Text = "Кто написал картину Мона Лиза?",
                Varianti = new[] { "Пабло Пикассо", "Леонардо да Винчи", "Винсент ван Гог", "Рембрандт" },
                Otvet = 1
            },
            new Vopros {
                Text = "Какой стиль характеризует архитектуру готических соборов?",
                Varianti = new[] { "Барокко", "Классицизм", "Готика", "Романский стиль" },
                Otvet = 2
            },
            new Vopros {
                Text = "Сикстинская капелла была расписана:",
                Varianti = new[] { "Рафаэлем", "Микеланджело", "Боттичелли", "Караваджо" },
                Otvet = 1
            },
            new Vopros {
                Text = "Картина «Звёздная ночь» написана:",
                Varianti = new[] { "Моне", "Дега", "Ван Гог", "Гоген" },
                Otvet = 2
            },
            new Vopros {
                Text = "Какое из данных произведений искусства создал Микеланджело Буонарроти?:",
                Varianti = new[] { "Преображение", "Тайная вечерия", "Пир Ирода", "Сотворение Адама" },
                Otvet = 3
            }
        };

        int Pravilno = 0;

        for (int i = 0; i < vopros.Count; i++)
        {
            var v = vopros[i];
            Console.WriteLine($"\nВопрос {i + 1}: {v.Text}");
            for (int j = 0; j < v.Varianti.Length; j++)
            {
                Console.WriteLine($"{j + 1}. {v.Varianti[j]}");
            }

            int Vibor;
            while (true)
            {
                Console.Write("Ваш ответ : ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out Vibor) && Vibor >= 1 && Vibor <= 4)
                    break;
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
            }

            if (Vibor - 1 == v.Otvet)
            {
                Pravilno++;
            }
        }

        Console.WriteLine($"\nВы ответили правильно на {Pravilno} из {vopros.Count} вопросов.");

        if (Pravilno >= vopros.Count * 0.75)
            Console.WriteLine("Тест пройден");
        else
            Console.WriteLine("Тест не пройден");

    }
}