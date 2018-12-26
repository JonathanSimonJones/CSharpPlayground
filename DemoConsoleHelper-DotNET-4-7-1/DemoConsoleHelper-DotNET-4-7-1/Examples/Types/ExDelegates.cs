using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Types
{
    /// <summary>
    /// Demonstrates use of Delegates
    /// </summary>
    public sealed class ExDelegates : ExBase
    {
        // PUBLIC INTERFACE START


        /// <summary>
        /// Contstructs the example.
        /// </summary>
        /// <remarks>
        /// Where <c cref="HelperText">HelperText</c> is set.
        /// </remarks>
        public ExDelegates()
        {
            string helperText = @"
Delegates
Delegates is a type.

A delegate can reference a function as long as the signature (read as parameters)
and return type are the same. 

You can assign a delegate a static or an instance method which alows the ability to 
change method calls on the fly or plug new code into an existing class.

Delegates are ideal for callbacks as they can be used as a parameter in a method. 

Delegates encapsulate both an object instance and a method. 

Delegates can be chained together. For example you could call multiple methods from 
a single event.

Anonomous methods and lambda expressions (in certain contexts) are complied to 
delegate types. 

Delegates are object-oriented, type safe and secure.

Once a delegate is instantiated, a method call made to the delegate will be passed by
the delegate to that method. The parameters are passed from the delegate to the
method. The return value, if any, is returned from the method the delegate refers to 
to the delegate. This process is known as invoking the delegate.
Delegate types are sealed. 

As delegates are objects they can be passed as a parameter, or assigned to a property.
This allows a method to accept a delegate as a parameter, and call the delegate 
at some later time. This is known as an asynchronous callback and is a common method of 
notifying a caller when a long process has completed. See _PassDelegateAsParameter.

Could be used to hide implementation details?

Delegates can be called synchronously by append parenthesis to the delegate object name,
or asynchronously by using .BeginInvoke and .EndInvoke methods.
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
            _UseDelegateExample();

            _PassDelegateAsParameter(4,5, _SumOfTwoInts);

            ConsoleTextBuilder.AppendLine("Result of " +
                                          "_sumPlusTenDelegateDeclaredUsingLamda " +
                                          "passing in 6 and 7: " +
                                          _sumPlusTenDelegateInstantiatedUsingLamda(6, 7)
                                              .ToString());

            ConsoleTextBuilder.AppendLine("Result of " +
                                          "_sumMinusFiveDelegateInstantiatedUsingAnonymousFunction " +
                                          "passing in 10 and 12: " +
                                          _sumMinusFiveDelegateInstantiatedUsingAnonymousFunction(10, 12)
                                              .ToString());
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

        private delegate string _StringReturnDelegate();

        private static string _Message() => "I exist in DefineDelegate";

        _StringReturnDelegate _MessageDel = _Message;

        private void _UseDelegateExample()
        {
            ConsoleTextBuilder.AppendLine("Result of calling _MessageDel: " 
                                          + _MessageDel());
        }

        private delegate int _ProcessTwoInts(int a, int b);

        private int _SumOfTwoInts(int i, int j) => i + j;

        /// <summary>
        /// Adds to ints via a delegate passed via a parameter. 
        /// </summary>
        /// <remarks>
        /// Shows off the capability of delegates to be used as a form of
        /// abstraction.
        /// </remarks>
        /// <param name="x">A random int value</param>
        /// <param name="y">A random int value</param>
        /// <param name="sumIntsDel">
        /// A delegate to perform an operation on the other parameters
        /// </param>
        private void _PassDelegateAsParameter(int x, int y, _ProcessTwoInts sumIntsDel)
        {
            ConsoleTextBuilder.AppendLine("Result of adding two ints via delegate " +
                                          "passed via parameter with values 4 and 5: " +
                                          sumIntsDel(x, y).ToString());
        }


        // Instatiate delegate using lamda
        private _ProcessTwoInts _sumPlusTenDelegateInstantiatedUsingLamda = 
            (i, i1) => i + i1 + 10;


        // Instatiate delegate using anonomous functions
        private _ProcessTwoInts _sumMinusFiveDelegateInstantiatedUsingAnonymousFunction =
            delegate(int a, int b) { return a + b - 5; };



        private delegate string _TakesStringReturnsString(string text);

        private static string _ReturnTextPassed(string text) => text;

        private string _AddToConsoleText(string text)
        {
            ConsoleTextBuilder.AppendLine(text);
            return "Successfully added to console.";
        }

        private static string _RepeatTextPassed(string text) => text + " " + text;

        private _TakesStringReturnsString _ReturnMessageDelegate = _ReturnTextPassed;

        // PRIVATE INTERFACE END







        // MEMBER VARIABLES START

        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();

        // MEMBER VARIABLES END


    }
}
