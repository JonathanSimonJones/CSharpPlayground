// .NET namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Project namespaces
using DemoConsoleHelper_DotNET_4_7_1.Examples;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Types;

namespace DemoConsoleHelper_DotNET_4_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            dynamic Factory = ExFactory.Instance;

            ExBase example = Factory.ExDynamic();
            Console.Write(example.ConsoleText);

            // Stop immediate termination
            Console.ReadKey();
        }
    }
}
