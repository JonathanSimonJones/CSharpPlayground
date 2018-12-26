using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Interfaces;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Types
{
    /// <summary>
    /// Demonstrates functionality and use of dynamic. 
    /// </summary>
    public sealed class ExDynamic : ExBase
    {
        // PUBLIC INTERFACE START

        /// <summary>
        /// Contstructs the example.
        /// </summary>
        /// <remarks>
        /// Where <c cref="HelperText">HelperText</c> is set.
        /// </remarks>
        public ExDynamic()
        {
            string helperText = @"
Dynamic
Reference type
Enables operations to bypass compile-time type checking and instead resolve type at run 
time

Dynamic behaves like object in most circumstances.

Operations that contain expressions of type dynamic are not resolved or type checked 
by the complier.

Dynamic only exist at compile time, at run time variables of type dynamic are compiled 
into  variables of type object.

In declarations it can appear as a type of: a property, field, indexer, parameter, return 
value, local variable, or type constraint. 

Where type serves as a value, dynamic can be used. e.g. someVar is dynamic.
"; 
            HelperText = helperText;

        }

        /// <summary>
        /// Returns informative text about the example. 
        /// </summary>
        /// <returns>
        /// A string with helpful text about the example in question. 
        /// </returns>
        public override string HelperText
        {
            get => m_helperText;
            protected set => m_helperText = value;
        }

        /// <summary>
        /// Returns text to be displayed by a console. 
        /// </summary>
        /// <remarks>
        /// Outputs contents of <c cref="ConsoleTextBuilder">ConsoleTextBuilder</c>
        /// </remarks>
        /// <returns>
        /// The text that the console should display
        /// </returns>
        public override string ConsoleText
        {
            get => m_consoleTextBuilder.ToString();
        }


        // PUBLIC INTERFACE END 





        // PROTECTED INTERFACE START


        /// <summary>
        /// Workhorse of the class.
        /// </summary>
        /// <remarks>
        /// No need to call. Is run from base class constructor. 
        /// </remarks>
        protected override void Run()
        {
            // Example 1 -- how dynamic types appear at run time
            ConsoleTextBuilder.AppendLine(
                "Result of dynamic type set at run time" + m_dyn.GetType().ToString());
            ConsoleTextBuilder.AppendLine(
                "Result of object type set at run time" + m_obj.GetType().ToString());
            ConsoleTextBuilder.AppendLine(
                "Both should be same. Demonstrating that both evaluate at run time " +
                "to the same thing.");

            ConsoleTextBuilder.AppendLine("");



            // Example 2 -- how dynamic is used to bypass compiler type checking
            // Will compile as dynamic type checking is done at run time
            m_dyn = m_dyn + 3;

            // Will stop compilation as object types are checked at compile time
            // and m_obj is of type object
            //m_obj = m_obj + 3;



            // Example 3 -- dynamic used in declarations
            // see m_field;
            // see ExProperty
            // see ExMethod



            // Example 4 -- dynamic as a value
            int i = 6;
            dynamic localDynamic;

            if (i is dynamic)
            {
                ConsoleTextBuilder.AppendLine(
                    "Dynamic can be used as a value for comparisions using the operators" +
                    " 'is' to make sure the LHS is not null, as this demonstrates.");
            }

            localDynamic = i as dynamic;

            ConsoleTextBuilder.AppendLine(
                "Result of typeof(List<dynamic>): " +
                (typeof(List<dynamic>)).ToString());

            // The following statement causes a compiler error.
            //Console.WriteLine(typeof(dynamic));
            // Likely due to dynamic being primary used as a placeholder for the 
            // run time type of a piece of data.
        }

        /// <summary>
        /// Gives access to the object used to constuct data to pass to the console. 
        /// </summary>
        /// <remarks>
        /// Uses a StringBuilder object.
        /// </remarks>
        protected override StringBuilder ConsoleTextBuilder
        {
            get => m_consoleTextBuilder;
        }

        // PROTECTED INTERFACE END 








        // PRIVATE MEMBER VARIABLES START

        private dynamic m_dyn = 3;
        private object m_obj = 4;
        private static dynamic m_field;
        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();

        private dynamic ExProperty
        {
            get => m_field;
            set => m_field = value;
        }

        private dynamic ExMethod(dynamic dynamicParameter)
        {
            // Can be set to anything
            dynamic localDynamic = "local dynamic variable example of returning string" +
                                   " if string is the type passed.";
            int defaultReturnValue = 0;

            if (dynamicParameter is string)
            {
                return localDynamic;
            }
            else
            {
                {
                    return defaultReturnValue;
                }
            }
        }

        // PRIVATE MEMBER VARIABLES END

    }


}
