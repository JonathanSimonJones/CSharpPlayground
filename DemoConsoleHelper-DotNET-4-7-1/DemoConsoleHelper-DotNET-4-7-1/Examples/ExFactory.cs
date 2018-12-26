﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Types;


// Singleton pattern taken from: http://csharpindepth.com/articles/general/singleton.aspx
// Factory pattern taken from: https://www.c-sharpcorner.com/article/factory-method-design-pattern-in-c-sharp/
 

namespace DemoConsoleHelper_DotNET_4_7_1.Examples
{
    /// <summary>
    /// A singleton factory for creating examples. 
    /// </summary>
    /// <remarks>
    /// Uses the factory and singleton design patterns. 
    /// </remarks>
    public sealed class ExFactory
    {
        // Pass in a delegate to the constructor which calls the Singleton constructor
        private static readonly Lazy<ExFactory> lazy =
            new Lazy<ExFactory>(() => new ExFactory());

        /// <summary>
        /// Return the sole static instance of the class.
        /// </summary>
        public static ExFactory Instance
        {
            get { return lazy.Value; }
        }

        // Define private constructor to stop multiple copies being created
        private ExFactory()
        {
        }


        /// <summary>
        /// Return a new Dynamic example.
        /// </summary>
        /// <returns>
        /// A example of type ExDynamic. 
        /// </returns>
        public ExDynamic ExDynamic() => new ExDynamic();

        /// <summary>
        /// Return a new Delegates example.
        /// </summary>
        /// <returns>
        /// A example of type ExDelegates. 
        /// </returns>
        public ExDelegates ExDelegates() => new ExDelegates();

    }
}
