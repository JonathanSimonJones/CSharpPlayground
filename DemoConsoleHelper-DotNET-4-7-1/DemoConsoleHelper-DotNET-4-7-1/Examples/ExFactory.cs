using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Types;

/*
 * Singleton pattern taken from: http://csharpindepth.com/articles/general/singleton.aspx
 * Factory pattern taken from: https://www.c-sharpcorner.com/article/factory-method-design-pattern-in-c-sharp/
 */

namespace DemoConsoleHelper_DotNET_4_7_1.Examples
{
    public sealed class ExFactory
    {
        // Pass in a delegate to the constructor which calls the Singleton constructor
        private static readonly Lazy<ExFactory> lazy =
            new Lazy<ExFactory>(() => new ExFactory());

        // Return the sole static instance of the class
        public static ExFactory Instance
        {
            get { return lazy.Value; }
        }

        // Define private constructor to stop multiple copies being created
        private ExFactory()
        {
        }

        public ExDynamic ExDynamic() => new ExDynamic();

        public ExDelegates ExDelegate() => new ExDelegates();

    }
}
