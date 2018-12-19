// .NET namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Project namespaces
using DemoConsoleHelper_DotNET_4_7_1.Examples;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;

namespace DemoConsoleHelper_DotNET_4_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ExBase example = new ExDynamic();
            //example.Run();
            Console.Write(example.HelperText);

            // Stop immediate termination
            Console.ReadKey();
        }
    }
}
