using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Functional
{
    public class TaskScope2 : TaskPool
    {
        public override void Task1()
        {
            Action<int[]> adder = ints =>
            {
                for (var i = 0; i < ints.Length; i++)
                {
                    ints[i]++;
                }
            };
            Action<int[]> multiplier = ints =>
            {
                for (var i = 0; i < ints.Length; i++)
                {
                    ints[i] *= 2;
                }
            };
            Action<int[]> subtractor = ints =>
            {
                for (var i = 0; i < ints.Length; i++)
                {
                    ints[i]--;
                }
            };
            Action<int[]> printer = ints => Console.WriteLine(string.Join(" ", ints));

            Func<string, Action<int[]>> selector = command =>
            {
                switch (command)
                {
                    case "add":
                        return adder;
                    case "multiply":
                        return multiplier;
                    case "subtract":
                        return subtractor;
                    case "print":
                        return printer;
                }

                return _ => { };
            };

            var line = Console.ReadLine();
            var strings = line.Split(' ');
            var numbers = lineParser(strings);

            while ((line = Console.ReadLine()) != "end")
            {
                selector(line)(numbers);
            }
        }

        public override void Task2()
        {
            Func<int[], int[]> reverser = ints => ints.Reverse().ToArray();
            Func<int[], int, int[]> filterDivider = (ints, d) => ints.Where(i => i % d != 0).ToArray();
            Action<int[]> printer = ints => Console.WriteLine(string.Join(" ", ints));

            var line = Console.ReadLine();
            var strings = line.Split(' ');
            var numbers = lineParser(strings);
            int divider = int.Parse(Console.ReadLine());
            printer(filterDivider(reverser(numbers), divider));
        }

        public override void Task3()
        {
            Func<string[], int, string[]> filter = (strings, maxSLen) =>
                strings.Where(s => s.Length <= maxSLen).ToArray();
            Action<string[]> printer = strings => Console.WriteLine(string.Join(" ", strings));

            var line = Console.ReadLine();
            int number = int.Parse(line);

            line = Console.ReadLine();
            var names = line.Split(' ');
            printer(filter(names, number));
        }

        public override void Task4()
        {
            var comparer = Comparer<int>.Create((i, j) =>
            {
                if (i % 2 == 0 && j % 2 == 1) return -1;
                if (j % 2 == 0 && i % 2 == 1) return 1;
                return i.CompareTo(j);
            });

            var line = Console.ReadLine();
            var strings = line.Split(' ');
            var numbers = lineParser(strings);
            Array.Sort(numbers, comparer);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}