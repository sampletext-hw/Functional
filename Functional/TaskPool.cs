using System;

namespace Functional
{
    public abstract class TaskPool
    {
        public abstract void Task1();
        public abstract void Task2();
        public abstract void Task3();
        public abstract void Task4();

        protected static Func<string[], int[]> lineParser = strings =>
        {
            int[] ints = new int[strings.Length];
            for (var i = 0; i < strings.Length; i++)
            {
                ints[i] = int.Parse(strings[i]);
            }

            return ints;
        };
    }
}