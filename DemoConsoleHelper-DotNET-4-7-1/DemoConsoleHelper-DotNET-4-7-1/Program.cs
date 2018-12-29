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
    /// <summary>
    /// Entry point. Runs examples of C# usage.
    /// </summary>
    /// <remarks>
    /// Requires System.Console at the moment.
    /// </remarks>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            dynamic Factory = ExFactory.Instance;

            ExBase example = Factory.ExStringType();
            Console.Write(example.ConsoleText);

            // Stop immediate termination
            Console.ReadKey();

            return;
        }
    }
}
