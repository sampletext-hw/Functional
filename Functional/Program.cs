﻿using System;
using System.Linq;

namespace Functional
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskPool pool = new TaskScope2();
            pool.Task4();
        }
    }
}