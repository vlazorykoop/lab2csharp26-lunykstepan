using System.Text;

namespace Lab
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\n--- Оберіть завдання ---");
                Console.WriteLine("1. Завдання 1");
                Console.WriteLine("2. Завдання 2");
                Console.WriteLine("3. Завдання 3");
                Console.WriteLine("4. Завдання 4");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3(); break;
                    case "4": Task4(); break;
                    default: Console.WriteLine("Невірний вибір!"); break;
                }
            }
        }

        static void Task1()
        {
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("X: ");
            int x = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                if (a[i] > x) Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static void Task2()
        {
            Console.Write("n = "); int n = int.Parse(Console.ReadLine());
            Console.Write("m = "); int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }

            int minVal = a[0, 0], maxVal = a[0, 0];
            int minI = 0, minJ = 0, maxI = 0, maxJ = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] < minVal) { minVal = a[i, j]; minI = i; minJ = j; }
                    if (a[i, j] >= maxVal) { maxVal = a[i, j]; maxI = i; maxJ = j; }
                }

            int temp = a[minI, minJ];
            a[minI, minJ] = a[maxI, maxJ];
            a[maxI, maxJ] = temp;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) Console.Write($"{a[i, j],5} ");
                Console.WriteLine();
            }
        }

        static void Task3()
        {
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }

            long norm = 0;
            for (int j = 0; j < n; j++)
            {
                int maxInCol = a[0, j];
                for (int i = 1; i < n; i++)
                    if (a[i, j] > maxInCol) maxInCol = a[i, j];
                norm += maxInCol;
            }
            Console.WriteLine($"Норма = {norm}");
        }

        static void Task4()
        {
            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"m рядка {i}: ");
                int m = int.Parse(Console.ReadLine());
                jagged[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i}][{j}] = ");
                    jagged[i][j] = int.Parse(Console.ReadLine());
                }
            }
            Console.Write("від: "); int start = int.Parse(Console.ReadLine());
            Console.Write("до: "); int end = int.Parse(Console.ReadLine());
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                foreach (int val in jagged[i])
                    if (val < start || val > end) sum += val;
                result[i] = sum;
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}