using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public enum Vorchanie
        {
            Low,
            Medium,
            High,
        }

        // Структура Дед
        public struct Ded
        {
            public string Name;
            public Vorchanie Vorchanie;
            public string[] Rude;
            public int Sinyak;

            // Конструктор
            public Ded(string name, Vorchanie VorchLv, string[] rude)
            {
                Name = name;
                Vorchanie = VorchLv;
                Rude = rude;
                Sinyak = 0; // По умолчанию
            }

            // Метод для проверки матерных слов
            public int Mat(params string[] profanityList)
            {
                foreach (var el in Rude)
                {
                    foreach (var profanity in profanityList)
                    {
                        if (el.Contains(profanity, StringComparison.OrdinalIgnoreCase))
                        {
                            Sinyak++; // Увеличиваем количество синяков
                        }
                    }
                }
                return Sinyak;
            }
        }

        static void DrawDigit(int number)
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("  ###  \n #   # \n #   # \n #   # \n  ###  ");
                    break;
                case 1:
                    Console.WriteLine("   #   \n  ##   \n   #   \n   #   \n  ###  ");
                    break;
                case 2:
                    Console.WriteLine("  ###  \n     # \n  ###  \n #     \n  ###  ");
                    break;
                case 3:
                    Console.WriteLine("  ###  \n     # \n  ###  \n     # \n  ###  ");
                    break;
                case 4:
                    Console.WriteLine(" #  # \n #  # \n  ###  \n    # \n    # ");
                    break;
                case 5:
                    Console.WriteLine("  ###  \n  #     \n  ###  \n     # \n  ###  ");
                    break;
                case 6:
                    Console.WriteLine("  ###  \n #     \n  ###  \n #   # \n  ###  ");
                    break;
                case 7:
                    Console.WriteLine("  ###  \n     # \n     # \n     # \n     # ");
                    break;
                case 8:
                    Console.WriteLine("  ###  \n #   # \n  ###  \n #   # \n  ###  ");
                    break;
                case 9:
                    Console.WriteLine("  ###  \n #   # \n  ###  \n     # \n  ###  ");
                    break;
                default:
                    break;
            }
        }
            static int average(out double average, ref long product,params int[] numbers)
        {
            int sum = 0;
            product = 1; // Начальное значение для произведения
            // Вычисление суммы и произведения
            foreach (int number in numbers)
            {
                sum += number;
                product *= number;
            }
            // Вычисление среднего арифметического
            average = numbers.Length > 0 ? (double)sum / numbers.Length : 0;
            return sum; // суммф
        }
        static void Exchanged(int[] array, int a, int b)
        {
            int temp = array[a];  // Скопируем элемент
            array[a] = array[b];  // Присвоим второму элементу
            array[b] = temp; // Присвоим первому элементу
            Console.WriteLine(array);
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task4();
            Task3();
        }
        static void Task1()
        { 
            /*1. Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
которые нужно поменять местами. Вывести на экран получившийся массив.
             */
            Console.WriteLine("1");
            Random rnd = new Random();
            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(100);
                Console.WriteLine(array[i]);
            }
            Console.WriteLine("введите число");
            int num = int.Parse(Console.ReadLine());
            int num1 = int.Parse(Console.ReadLine());
            int index1 = Array.IndexOf(array, num);
            int index2 = Array.IndexOf(array, num1);
            Exchanged(array, index1, index2);
            Console.WriteLine(string.Join(" ", array));
        }
        static void Task2()
        {
            /*2. Написать метод, где в качества аргумента будет передан массив (ключевое слово
params). Вывести сумму элементов массива (вернуть). Вывести (ref) произведение
массива. Вывести (out) среднее арифметическое в массиве.
             */
            Console.WriteLine("2");
            Console.WriteLine(" сколько чисел вы будете вводить");
            int l = int.Parse(Console.ReadLine());
            Console.WriteLine("введите числа ");
            int[] ints = new int[l];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = int.Parse(Console.ReadLine());
            }
            double sr;
            long proiz = 1;
            int sum = average(out sr, ref proiz, ints);
            average(out sr, ref proiz, ints);
            Console.WriteLine($"сумма {sum} произведение {proiz} среднее арифметическое{sr}");
        }
        static void Task3()
        {
            /*3. Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать
изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
завершает работу, если пользователь введёт слово: exit или закрыть (оба варианта
должны сработать) - консоль закроется.
             */
            Console.WriteLine("3");
            bool flag = true;
            while (true)
            {
                Console.Write("Введите число (или 'exit' или 'закрыть' для выхода): ");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) || input.Equals("закрыть", StringComparison.OrdinalIgnoreCase)) // сравнение ввода с закрыть без учета регистра
                {
                    break; // Выход из программы
                }

                try
                {
                    int number = int.Parse(input);
                    if (number >= 0 && number <= 9)
                    {
                        DrawDigit(number);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear(); // Очищаем экран, чтобы цвет был заметен
                        Console.WriteLine("Ошибка");
                        Thread.Sleep(3000); // Задержка на 3 секунды
                        Console.ResetColor(); // Сброс цвета консоли
                        Console.Clear();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка");
                }
            }
        }
        static void Task4()
        { 
            /*4. Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив
фраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
бабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное количество фраз для
ворчания. Напишите метод (внутри структуры), который на вход принимает деда,
список матерных слов (params). Если дед содержит в своей лексике матерные слова из
списка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.
             */
            Console.WriteLine("4");
            Ded ded1 = new Ded("Николай", Vorchanie.Low, new string[] { "Да провались оно все"});
            Ded ded2 = new Ded("Степан", Vorchanie.Medium, new string[] { "наливай чай " , "Гады"});
            Ded ded3 = new Ded("Тихон", Vorchanie.High, new string[] { "Гады", "Проститутки", "" , "Проститутки" , "Проститутки" });
            Ded ded4 = new Ded("Саша", Vorchanie.High, new string[] { "Будь здоров", "Гады" , "Проститутки" });
            Ded ded5 = new Ded("Инокентий", Vorchanie.Medium, new string[] { "Окоянные", "Бездари" });
            string[] profanityList = { "Проститутки", "Гады" };
            Console.WriteLine($"{ded1.Name} получил {ded1.Mat(profanityList)} синяков.");
            Console.WriteLine($"{ded2.Name} получил {ded2.Mat(profanityList)} синяков.");
            Console.WriteLine($"{ded3.Name} получил {ded3.Mat(profanityList)} синяков.");
            Console.WriteLine($"{ded4.Name} получил {ded4.Mat(profanityList)} синяков.");
            Console.WriteLine($"{ded5.Name} получил {ded5.Mat(profanityList)} синяков.");
        }
    }
}
