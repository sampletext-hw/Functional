using System;
using System.Collections.Generic;
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
        }

        public override void Task3()
        {
        }

        public override void Task4()
        {
        }
    }
}