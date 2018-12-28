using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;
using Exception = System.Exception;

// Helpful docs: https://michielvoo.net/2009/03/26/expressions-vs-statements-in-c-sharp/
//               https://stackoverflow.com/questions/19132/expression-versus-statement
//               https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/statements


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
https://stackoverflow.com/a/20771/8554766

Common actions include: declaring variables, assigning values, calling methods, looping 
through collections, branching to one or another block of code depending on a given 
condition. 

Statement blocks contain multiple statements. 

The order in which statments are executed in a program is called flow of control or flow
execution. 

A statement block is enclosed in {} brackets. 

Declaration statements introduces a new variable or constant. 

Expression statements that calculate a value must store a value in a variable. 
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

Checked and unchecked statments. These specify if exceptions should be thrown if an 
overflow is caused when doing arithmetic. 

Await statements are used in functions which include the async modifier. When an await 
expression is met control returns to the caller of the async function and the method can 
carry on with processing the rest of the statements. The progress in the async function
is halted until the awaited task is complete. 

Yield return statements are used with iterators to return each of the individual elements 
of a collection. Once a yield return statement is reached, the current location in the 
iterator function is remembered, and once re-entry of the iterator function happens the 
execution of the function carries on from the last return yeild statement.

Fixed statements are used in unsafe functions. They allow the use of pointers. The 
fixed statement prevents the garbage collector from relocation a movable variable. 

Lock statements enable you to limit access to blocks of code to only one thread at a 
time. 

Labeled statements. When a label statement is specified, you can use goto followed by the 
name of the label statement to jump to that particular point in the code. 

Statement keywords:
Selection statements	        if, else, switch, case
Iteration statements	        do, for, foreach, in, while
Jump statements	                break, continue, default, goto, return, yield
Exception handling statements	throw, try-catch, try-finally, try-catch-finally
Checked and unchecked	        checked, unchecked
fixed statement	                fixed
lock statement	                lock
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

            // Examples of Exception statements
            _TryCatchFinally();

            // Examples of checked and unchecked statements
            _CheckedAndUnchecked();

            // Async example to demonstrate await statements
            _AwaitStatementExample();

            ConsoleTextBuilder.AppendLine("This should be before the async methods as " +
                                          "program flow should continue");

            // Holding thread so that the tasks completes
            System.Threading.Thread.Sleep(5000);

            // Demonstrates yeild return statement
            foreach (string str in _YeildReturnExample())
            {
                ConsoleTextBuilder.AppendLine(str);
            }

            //_FixedExample();

            _LockExample();

            _LabeledStatements();

            ConsoleTextBuilder.AppendLine("End of statement examples!");
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

        private void _TryCatchFinally()
        {
            // Set random char buffer so that we can try go out of bounds
            char[] buffer = new char[20];

            // Exception statment
            try
            {
                // Go beyond bounds
                buffer[30] = '5';
            }
            // Exception statement
            catch(Exception exception)
            {
                ConsoleTextBuilder.AppendLine("Caught excepetion: " + exception.ToString());
            }
            // Exception statement
            finally
            {
                ConsoleTextBuilder.AppendLine("Setting buffer to null in finally");
                buffer = null;
            }
        }

        private void _CheckedAndUnchecked()
        {
            Int32 lowestNegative = Int32.MinValue;

            ConsoleTextBuilder.AppendLine("Lowest negative value for int32 = " 
                                          + lowestNegative.ToString());

            ConsoleTextBuilder.AppendLine("With checked block in try");
            try
            {
                // Checked statement
                checked
                {
                    lowestNegative -= 1;
                }
            }
            catch (Exception e)
            {
                ConsoleTextBuilder.AppendLine("Caught exception: " + e);
            }

            // Reset value for test
            lowestNegative = Int32.MinValue;

            ConsoleTextBuilder.AppendLine("Without checked block in try");
            try
            {
                lowestNegative -= 1;
            }
            catch (Exception e)
            {
                ConsoleTextBuilder.AppendLine("Caught exception: " + e);
            }

            // Reset value for test
            lowestNegative = Int32.MinValue;

            ConsoleTextBuilder.AppendLine("Explicity using unchecked block in try");
            try
            {
                // Unchecked statement
                unchecked
                {
                    lowestNegative -= 1;
                }
            }
            catch (Exception e)
            {
                ConsoleTextBuilder.AppendLine("Caught exception: " + e);
            }


            ConsoleTextBuilder.AppendLine("new value after minus 1 = " 
                                          + lowestNegative.ToString());
        }

        private async void _AwaitStatementExample()
        {
            // Await statement
            await _WriteToConsoleTextBuilderAfter3Seconds();

            ConsoleTextBuilder.AppendLine("This is called after " +
                                          "_WriteToConsoleTextBuilderAfter3Seconds");
        }

        private async Task _WriteToConsoleTextBuilderAfter3Seconds()
        {
            // Await statement
            await Task.Delay(3000);

            ConsoleTextBuilder.AppendLine("This should be written 3 seconds after " +
                                          "execution of " +
                                          "_WriteToConsoleTextBuilderAfter3Seconds");
        }

        private IEnumerable<string> _YeildReturnExample()
        {
            // Yield return statement
            yield return "First yeild returned.";

            // Yield return statement
            yield return "Second yeild returned.";

            // Yield return statement
            yield return "Last yeild returned.";
        }

        // To use this method make sure to compile with unsafe option
        //unsafe private void _FixedExample()
        //{
        //    int[] localFunctionIntArray = {0, 1, 2, 3};

        //    // Fixed statement
        //    fixed (int* intArrayPtr = localFunctionIntArray)
        //    {
        //        ConsoleTextBuilder.AppendLine("Value of second element in int array: " +
        //                                      (*(intArrayPtr + 1)).ToString());
        //    }
        //}

        private object ExLock => m_lock ?? (m_lock = new object());

        private void _LockExample()
        {
            // Lock statment
            lock (ExLock)
            {
                ConsoleTextBuilder.AppendLine("This is written inside a block statement " +
                                              "which is prefixed by a lock statement.");
            }
        }

        private void _LabeledStatements()
        {
            int startVal = 2;
            switch (startVal)
            {
                // A labeled statement
                case 0:
                    return;

                // A labeled statement
                case 1:
                    ConsoleTextBuilder.AppendLine("Hit case 1, now to case 0");
                    goto case 0;

                // A labeled statement
                case 2:
                    ConsoleTextBuilder.AppendLine("Entered switch example, heading to " +
                                                  "case 1 next.");
                    goto case 1;
                default:
                    goto exit;
            }

            // Also a labelled statment
            exit:
                return;
        }

        // PRIVATE INTERFACE END




        // MEMBER VARIABLES START

        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();
        private object m_lock;

        // MEMBER VARIABLES END


    }
}
