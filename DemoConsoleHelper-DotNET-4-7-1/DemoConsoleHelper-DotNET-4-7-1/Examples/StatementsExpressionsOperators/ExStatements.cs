using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;

// Helpful docs: https://michielvoo.net/2009/03/26/expressions-vs-statements-in-c-sharp/
//               https://stackoverflow.com/questions/19132/expression-versus-statement


namespace DemoConsoleHelper_DotNET_4_7_1.Examples.StatementsExpressionsOperators
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ExStatements : ExBase
    {
        // PUBLIC INTERFACE START


        /// <summary>
        /// Contstructs the example.
        /// </summary>
        /// <remarks>
        /// Where <c cref="HelperText">HelperText</c> is set.
        /// </remarks>
        public ExStatements()
        {
            string helperText = @"
Statements
A unit of code. Can be a block or a single line of code. 

Only assignment, call, increment and decrement expressions may be used as statements. 

Common actions include: declaring variables, assigning values, calling methods, looping 
through collections, branching to one or another block of code depending on a given 
condition. 

Statement blocks contain multiple statements. 

The order in which statments are executed in a program is called flow of control or flow
execution. 

A statement block is enclosed in {} brackets. 

Declaration statements introduces a new variable or constant. 

Expression statements that calculate a value must store a value. 
Expression statements include:  assignment, object creation with assignment, method 
invocation. 

Empty statement are when there is no expression. It is a semi colon by itself. Typical 
use case appears to be when you want to execute no code but the syntax of the language
requires a statement. Therefore you use a semi colon to conclude the statement. 

Selection statements include: if, else, switch, case, default. These statements cause the 
program control to be transferred to a specfic flow based of a condition. 

Iteration statement include: do, for, foreach, in, while. These statements allow you to 
loop through collections (like arrays) or perform the same set of statemtents 
repeatedly until a specific condition is met. 

Jump statements include: break, continue, default, goto, return, yield. They transfer 
control to another section of code. 

Exception handling statements include: throw, try-catch, try-finally, try-catch-finally.
Enables graceful recovery from expeceptional conditions that occur at run time. 
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
            get => ConsoleTextBuilder.ToString();
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
            // Declare variable statement (declaration statement)
            float position;

            // Assignment (expression statement)
            position = 10.0f;

            // Method statement (expression statment)
            _MethodStatement();

            // Declaration statement with initilizer are equivalent to 
            // declaration statement following by assignment statement
            // (declaration statement) into (expression statement)
            float[] positions = {position, 15.5f};

            // if statement (selection statment)
            if (positions[0] > 5.1f)
            // statement block
            {
                // Assignment (expression statement)
                positions[0] = 1.3f;
            }
            // else statement (selection statement)
            else
            // statement block
            {
                // Assignment (expression statement)
                positions[0] = 2.2f;
            }

            // Example of empty statement
            // while statement (iteration statement)
            while (positions[0] > 100.0f)
                ;

            // Selection statement
            switch (positions[0])
            {
                // Selection statement
                case 2.2f:
                    ConsoleTextBuilder.AppendLine("Hit else statement block.");

                    // Jump statement
                    break;

                // Selection statement
                case 1.3f:
                    ConsoleTextBuilder.AppendLine("Hit if statement block.");

                    // Jump statement
                    break;

                // Jump statement
                default:
                    ConsoleTextBuilder.AppendLine("Did not execute either the if or else " +
                                                  "statement block.");

                    // Jump statement
                    break;
            }

            _TryCatchFinally();
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



        // PRIVATE INTERFACE START

        private void _MethodStatement()
        {
            return;
        }

        private int _TryCatchFinally()
        {
            char[] buffer = new char[20];
            try
            {
                buffer[30] = '5';
            }
            catch
            {
                ConsoleTextBuilder.AppendLine("Caught excepetion");
            }
            finally
            {
                buffer = null;
            }

            return 0;
        }

        // PRIVATE INTERFACE END




        // MEMBER VARIABLES START

        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();

        // MEMBER VARIABLES END


    }
}
