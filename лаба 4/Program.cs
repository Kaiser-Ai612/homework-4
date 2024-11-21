using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Fibonacci(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("число должно быть больше 0");
            }
            if (n == 1 || n == 2)
            {
                return 1; // Первые два 1
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
            static int Fibbonachi(int number12)
        {
            return Fibbonachi(number12 - 1 + number12 - 2);
        }
        static int NOD(int a, int b, int c)
        {
            return NOD(NOD(a, b), c); // Сначала находим НОД(a, b), затем с c
        }
        static int NOD(int a, int b)
        {
            if (b == 0)
            {
                return a; //НОД(a, 0) = a
            }
            return NOD(b, a % b); // рекурсия
        }
        static long CountFactorial(int number1)
        {
            if (number1 == 0) return 1; //факториал 0 = 1
            else if (number1 < 0)
            {
                return -1;
            }
            return number1 + CountFactorial(number1 - 1);
        }
        static bool Factorial(int number, out long result)
        {
            result = 1; //обязательно надо
            if (number < 0)
            {
                return false; // невозможно
            }
            try
            {
                for (int i = 1; i <= number; i++)
                {
                    result = checked(result * i);
                }
                return true; 
            }
            catch (OverflowException)
            {
                return false; // Возникло переполнение
            }
        }
        static int num(int a, int b)
        {
            return (a > b) ? a : b;
        }
        static void Num1(ref string a, ref string b)
        {
            (a,b) = (b,a);
        }
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }
        static void Task1()
        {
            /*Упражнение 5.1 Написать метод, возвращающий наибольшее из двух чисел. Входные
параметры метода – два целых числа. Протестировать метод.
             */
            Console.WriteLine("5.1");
            Console.WriteLine("введите 2 числа");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"максимальное число {num(num1, num2)}");
        }
        static void Task2()
        {
            /*Упражнение 5.2 Написать метод, который меняет местами значения двух передаваемых
    параметров. Параметры передавать по ссылке. Протестировать метод.
             */
            Console.WriteLine("5.2");
            Console.WriteLine("написать 2 любых параметра");
            string arg1 = Console.ReadLine();
            string arg2 = Console.ReadLine();
            //Console.WriteLine($"{arg1, arg2}");
            Num1(ref arg1, ref arg2);
            Console.WriteLine($"{arg1} {arg2}");
        }
        static void Task3()
        {
            /*Упражнение 5.3 Написать метод вычисления факториала числа, результат вычислений
передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
если в процессе вычисления возникло переполнение, то вернуть значение false. Для
отслеживания переполнения значения использовать блок checked.
             */
            Console.WriteLine("5.3");
            Console.WriteLine("напишите число");
            int number = int.Parse(Console.ReadLine());
            int result = 1;
            if (Factorial(number, out long result1))
            {
                for (int i = 1; i <= number; i++)
                {
                    result = (result * i);
                }
                Console.WriteLine($"факториал {number} равен {result}");
            }
            else
            {
                Console.WriteLine("превышает допустимое значение");
            }
        }
        static void Task4()
        {
            /*Упражнение 5.4 Написать рекурсивный метод вычисления факториала числа.
             */
            Console.WriteLine("5.4");
            Console.WriteLine("напишите число");
            int chislo = int.Parse(Console.ReadLine());
            if (CountFactorial(chislo) == -1)
            {
                Console.WriteLine("недопустимое значение");
            }
            else
            {
                Console.WriteLine($"факториал {chislo} равен {CountFactorial(chislo)}");
            }
        }
        static void Task5()
        {
            /*Домашнее задание 5.1 Написать метод, который вычисляет НОД двух натуральных чисел
(алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех
натуральных чисел.
             */
            Console.WriteLine("5,1");
            Console.WriteLine("введите два числа");
            int num5 = int.Parse(Console.ReadLine());
            int num6 = int.Parse(Console.ReadLine());
            int res = NOD(num5, num6);
            Console.WriteLine($"НОД {num5} и {num6} равен {res}");
            Console.WriteLine("введите третье число");
            // для трех чисел
            int num7 = int.Parse(Console.ReadLine());
            int res2 = NOD(num5, num6, num7);
            Console.WriteLine($"НОД {num5}, {num6} и {num7} равен {res2}");
        }
        static void Task6()
        { 
            /*Домашнее задание 5.2 Написать рекурсивный метод, вычисляющий значение n-го числа
ряда Фибоначчи. Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,
13... Для таких чисел верно соотношение Fk = Fk-1 + Fk-2 .
             */
            Console.WriteLine("5.2");
            Console.WriteLine("напишите число");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"последоательность Фибоначчи {Fibbonachi(n)}");
        }
    }
}
