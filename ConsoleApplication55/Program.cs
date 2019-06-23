using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication29
{
    class Program
    {
        static void MakePrintRandomTable(int line, int column, int[,] table)
        {
            Random rand = new Random();
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    table[i, j] = rand.Next(1, 10);
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void PrintTable(int line, int column, int[,] table)
        {
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void MakeTable(int line, int column, int[,] table)
        {
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.WriteLine("Введите элемент {0} строки {1} столбца", i + 1, j + 1);
                    Try(out table[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void choose(int left, out int number)
        {
            number = 0;
            bool flag = true;
            while (flag == true)
            {//проверка правильности ввода
                Try(out number);
                if (number >= 1 && number <= left)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверное значение! Введите целое число от 1 до {0}", left);

                }
            }
        }
        static void Try(out int inputnumber)//проверка правильности ввода числа
        {
            inputnumber = 0;
            bool flag = true;
            while (flag == true)
            {
                try
                {

                    string x = Console.ReadLine();
                    inputnumber = int.Parse(x);
                    flag = false;
                }
                catch
                {
                    Console.WriteLine("Неверное значение! Введите целое число");
                    flag = true;
                }
            }
        }
        static void Main(string[] args)
        {
            string answer = "yes";
            int number1_2;

            while (answer == "yes")
            {
                Console.WriteLine("Введите порядок матрицы");
                Console.Write("n=");
                int n;
                bool f1 = true;
                Try(out n);
                while (f1 && n < 0)
                {
                    Console.WriteLine("Неверное значение! Введите положительное число");
                    Try(out n);
                    if (n >= 0)
                    {
                        f1 = false;
                    }
                }
                if (n == 0)
                {
                    Console.WriteLine("Матрица пустая");
                }
                else
                {
                    int[,] table = new int[n, n];
                    Console.WriteLine("Введите 1, если хотите вводить элементы матрицы с клавиатуры");
                    Console.WriteLine("Введите 2, если хотите сгенерировать элементы матрицы случайным образом");
                    choose(2, out number1_2);
                    switch (number1_2)
                    {
                        case 1:
                            MakeTable(n, n, table);
                            Console.WriteLine("\nМатрица сформирована");
                            PrintTable(n, n, table);
                            break;
                        case 2:
                            Console.WriteLine("Матрица сформирована");
                            MakePrintRandomTable(n, n, table);
                            break;
                    }
                    int count = 0;
                    for (int i = 0; i < n; i++)
                    {
                        int number = 0;
                        for (int j = 0; j < n; j++)
                        {
                            if (table[i, j] % 2 == 0)
                            {
                                number++;
                            }
                            else continue;
                        }
                        if (number == n)
                        {
                            Console.WriteLine("Строка {0} содержит все четные элементы", i + 1);
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        Console.WriteLine("Строк со всеми четными элементами в матрице нет");
                    }
                }
                Console.WriteLine("Продолжить? yes/no");
                answer = Console.ReadLine();

            }

        }
    }
}
