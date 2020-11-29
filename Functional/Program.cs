using System;
using System.Linq;

namespace Functional
{
    class Program
    {
        static void Main(string[] args)
        {
            Task4();
        }

        private static void Task1()
        {
            var line = Console.ReadLine();

            Action<string> action = (word) => { Console.WriteLine(word); };

            foreach (var word in line.Split(' '))
            {
                action(word);
            }
        }

        private static void Task2()
        {
            var line = Console.ReadLine();

            Action<string> action = (word) => { Console.WriteLine($"{word} (нет в наличии)"); };

            foreach (var word in line.Split(' '))
            {
                action(word);
            }
        }

        static Func<string[], int[]> lineParser = strings =>
        {
            int[] ints = new int[strings.Length];
            for (var i = 0; i < strings.Length; i++)
            {
                ints[i] = int.Parse(strings[i]);
            }

            return ints;
        };

        private static void Task3()
        {
            var line = Console.ReadLine();

            Func<int[], int> summator = ints =>
            {
                int min = ints[0];
                for (var i = 1; i < ints.Length; i++)
                {
                    min = Math.Min(min, ints[i]);
                }

                return min;
            };
            
            Console.WriteLine(summator(lineParser(line.Split(' '))));
        }

        private static void Task4()
        {
            var line = Console.ReadLine();

            int[] ints = lineParser(line.Split(' '));

            int left = ints[0];
            int right = ints[1];

            Func<bool, int, int, int[]> selector = (odd, start, end) =>
            {
                // массив на e-s / 2 + 1 элементов
                int[] els = new int[(end - start) / 2 + 1];

                // если чётность старта не соответствует чётности выборки, смещаемся на 1
                // [Эквивалентно проверке]
                // выбираем нечётные, и при этом начинаем с чётной, тогда смещаемся на 1
                // выбираем чётные, и при этом начинаем с нечётной, тогда смещаемся на 1

                var offset = start % 2 == 1 != odd ? 1 : 0;

                for (int i = 0; i < els.Length; i++)
                {
                    els[i] = start + offset + i * 2;
                }

                return els;
            };

            bool isOdd = Console.ReadLine() == "odd";

            Console.WriteLine(string.Join(' ', selector(isOdd, left, right)));
        }
    }
}