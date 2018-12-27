using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Types
{
    public delegate ExDelegates ExReturnDelegateDefinedOutsideOfClass();

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
notifying a caller when a long process has completed. It is similar to the encapsulation
interfaces provide. See _PassDelegateAsParameter.

Delegates fit quite nicely into sort algorithms. Passing in a delegate which knows how
to sort the elements passed in.

Assigning one delegate to another appears similar to creating a new reference to the
method linked to by the delegate. 

A multicast delegate is a delegate made up of multiple delegate calls. It appears 
constraint to delegates of the same type. 

If a multicast delegate uses a reference parameter, the reference is passed sequentially 
to each of the methods with any changes applied in the previous method.

Delegate types are derived from System.Delegate. You can call 
.GetInvocationList().GetLength(0) to get the count of the amount of delegates. 

Delegates with more than one method in their invocation list derive from 
MulticastDelegate. 

In a multicast delegate, if any of the methods throw an exception that is not caught 
within the method, the exception is passed to the caller of the delegate (so the method
exits?) and no subsequent methods in the invocation list are called. 

When a delegate wraps an instance method, it references both the instance and the method.
It has no knowledge of the instance type, aside from the method it wraps. Therefore a
delegate can refer to any object as long as the object has a method which matches the
signature of the delegate. See _MulticasetDelegateExample().

Could be used to hide implementation details?

You can define a delegate in a namespace as it is a type. 

Delegates can be called synchronously by append parenthesis to the delegate object name,
or asynchronously by using .BeginInvoke and .EndInvoke methods.

Comparing delegates of different types assigned at compile time results in a compliation
error. If the delegate instances are statically of the type System.Delegate, then the
comparision is allowed, but will return false at run time. 
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

            ConsoleTextBuilder.AppendLine(" ");
            _MulticasetDelegateExample();

            ConsoleTextBuilder.AppendLine(" ");
            _DelegateAsProperty();


        //private RHS NonStaticRHS1 = (text) => text;
        //private RHS NonStaticRHS2 = (text1) => text1;
        //private static RHS StaticRHS1 = (text2) => text2;
        //private static RHS StaticRHS2 = (text4) => text4;

        //private LHS NonStaticLHS1 = (text3) => text3;
        //private static LHS StaticLHS = (text5) => text5;
            _ComparisionOfDelegates(NonStaticRHS1, StaticRHS1, NonStaticLHS1, StaticLHS);
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
        /// A delegate to perform some process on the parameters passed into the
        /// method.
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

        private static string _AppendFooToMessage(string text)
        {
            return text + " foo";
        }

        private class MethodsForMulticastDelegate
        {
            public string ReturnTextPassed(string text) => text;
            public string RepeatTextPassed(string text) => text + " " + text;
        }

        private delegate void _TakesRefString(ref string text);

        private static void _DemoInnerCall1(ref string messageWithOutAppend)
        {
            messageWithOutAppend += " first append,";
        }

        private static void _DemoInnerCall2(ref string messageWithOutAppend)
        {
            messageWithOutAppend += " second append,";
        }

        private static void _DemoInnerCall3(ref string messageWithOutAppend)
        {
            messageWithOutAppend += " last append.";
        }


        /// <summary>
        /// Demonstration of multicast delegates
        /// </summary>
        /// <remarks>
        /// You can use the addition operator to combine delegates into one call.
        /// Also demonstrates how a delegate doesn't care about the type of object
        /// the method comes from. 
        /// </remarks>
        private void _MulticasetDelegateExample()
        {
            // Create delegates for multicast demo START
            _TakesStringReturnsString _AppendFooToMessageDelegate = _AppendFooToMessage;
            ConsoleTextBuilder.AppendLine("Result of calling _AppendFooToMessageDelegate " +
                                          "passing in bar: " +
                                          _AppendFooToMessageDelegate("bar"));

            MethodsForMulticastDelegate multicastObj = new MethodsForMulticastDelegate();

            _TakesStringReturnsString _ReturnTextPassedDelegate = 
                                            multicastObj.ReturnTextPassed;

            ConsoleTextBuilder.AppendLine("Result of calling _ReturnTextPassedDelegate " +
                                          "passing in baz: " +
                                          _ReturnTextPassedDelegate("baz"));

            _TakesStringReturnsString _RepeatTextPassedDelegate =
                multicastObj.RepeatTextPassed;

            ConsoleTextBuilder.AppendLine("Result of calling _RepeatTextPassedDelegate " +
                                          "passing in faz: " +
                                          _RepeatTextPassedDelegate("faz"));
            // Create delegates for multicast demo END


            // Create multicast delegate
            _TakesStringReturnsString _AllThreeStringDelegates = _ReturnTextPassedDelegate +
                                                                 _RepeatTextPassedDelegate +
                                                                 _AppendFooToMessageDelegate;

            // Test multicast delegate
            ConsoleTextBuilder.AppendLine("Result of calling _AllThreeStringDelegates " +
                                          "passing in check: " +
                                          _AllThreeStringDelegates("check"));

            // Removed last delegate from multicast
            _AllThreeStringDelegates -= _AppendFooToMessageDelegate;

            // Test multicast minus one delegate
            ConsoleTextBuilder.AppendLine("Result of calling _AllThreeStringDelegates, " +
                                          " without _AppendFooToMessageDelegatepassing " +
                                          "and passing in check2: " +
                                          _AllThreeStringDelegates("check2"));
            ConsoleTextBuilder.AppendLine("This demonstrates the ability to remove " +
                                          "a delegate from a multicast and that the " +
                                          "return value is taken as the last method " +
                                          "call.");

            // Demo unchanged nature of original delegates used in creation
            // of multicast
            ConsoleTextBuilder.AppendLine("Result of calling _AppendFooToMessageDelegate " +
                              "passing in daz: " +
                              _AppendFooToMessageDelegate("daz"));

            ConsoleTextBuilder.AppendLine("Result of calling _ReturnTextPassedDelegate " +
                                          "passing in boo: " +
                                          _ReturnTextPassedDelegate("boo"));

            ConsoleTextBuilder.AppendLine("Result of calling _RepeatTextPassedDelegate " +
                                          "passing in kaz: " +
                                          _RepeatTextPassedDelegate("kaz"));
            ConsoleTextBuilder.AppendLine("Shows unchanged nature of delegates after " +
                                          "setting to multicast.\n");

            // Create delegates for demonstration of using reference parameters in 
            // delegates
            _TakesRefString _DemoInnerCall1Del = _DemoInnerCall1;
            _TakesRefString _DemoInnerCall1De2 = _DemoInnerCall2;
            _TakesRefString _DemoInnerCall1De3 = _DemoInnerCall3;

            _TakesRefString _DemoMulticast = _DemoInnerCall1Del +
                                             _DemoInnerCall1De2 +
                                             _DemoInnerCall1De3;

            string initialText = "Initial,";

            // Call multicast delegate with referencer parameter
            _DemoMulticast(ref initialText);

            // Display results
            ConsoleTextBuilder.AppendLine("Result of calling _DemoMulticast " +
                                          "passing in Initial: " + initialText);
            ConsoleTextBuilder.AppendLine("Demos using a reference parameter in a " +
                                          "delegate and how that interaction works.\n");

        }
        
        /// <summary>
        /// Demonstrates using delegates as a property
        /// </summary>
        /// <remarks>
        /// Will compile if not set property, but will break at runtime if not set
        /// </remarks>
        void _DelegateAsProperty()
        {
            _ProcessTwoInts multipleTwoIntsDelegate = (a, b) => a * b;

            ProcessTwoIntsDelegateProperty = multipleTwoIntsDelegate;

            ConsoleTextBuilder.AppendLine("Result of ProcessTwoIntsDelegateProperty " +
                                          "passing in 3 and 4: " +
                                          ProcessTwoIntsDelegateProperty(3, 4));
        }


        private delegate string RHS(string textToReturn);
        private delegate string LHS(string textToReturn);

        private RHS NonStaticRHS1 = (text) => text;
        private RHS NonStaticRHS2 = (text1) => text1;
        private static RHS StaticRHS1 = (text2) => text2;
        private static RHS StaticRHS2 = (text4) => text4;

        private LHS NonStaticLHS1 = (text3) => text3;
        private static LHS StaticLHS = (text5) => text5;


        /// <summary>
        /// Demonstrates comparisions of delegates
        /// </summary>
        /// <remarks>
        /// Unless it is exactly the same delegate the comparison returns false.
        /// </remarks>
        /// <param name="nonStaticRHSDel">
        /// Intended for a non static delegate of type RHS
        /// </param>
        /// <param name="staticRHSDel">
        /// Intended for a static delegate of type RHS
        /// </param>
        /// <param name="nonStaticLHSDel">
        /// Intended for a non static delegate of type LHS
        /// </param>
        /// <param name="staticLHSDel">
        /// Intended for a static delegate of type LHS
        /// </param>
        private void _ComparisionOfDelegates(
            System.Delegate nonStaticRHSDel,
            System.Delegate staticRHSDel,
            System.Delegate nonStaticLHSDel, 
            System.Delegate staticLHSDel)
        {
            ConsoleTextBuilder.AppendLine("Non static compared with non static with " +
                                          "same delegate type result:" +
                                          (NonStaticRHS1 == NonStaticRHS2).ToString());

            // Results in compilation error at compile time
            //ConsoleTextBuilder.AppendLine("Non static compared with non static with " +
            //                              "different delegate type, but same signature" +
            //                              " result:" +
            //                              (NonStaticRHS1 == NonStaticLHS1).ToString());

            // Results in compilation error at compile time
            //ConsoleTextBuilder.AppendLine("Non static compared with non static with " +
            //                              "same delegate type result:" +
            //                              (StaticLHS == StaticRHS1).ToString());

            ConsoleTextBuilder.AppendLine("Static compared with static with " +
                                          "same delegate type result:" +
                                          (StaticRHS1 == StaticRHS2).ToString());

            ConsoleTextBuilder.AppendLine("Non Static compared with non static " +
                                          "System.Delegate with same delegate type " +
                                          "result:" +
                                          (NonStaticRHS2 == nonStaticRHSDel).ToString());

            ConsoleTextBuilder.AppendLine("Static compared with static System.Delegate " +
                                          "of same type resultL: " +
                                          (StaticRHS2 == staticRHSDel).ToString());

            ConsoleTextBuilder.AppendLine("Non Static compared with static " +
                                          "System.Delegate of same type result: " +
                                          (NonStaticRHS1 == staticRHSDel).ToString());

            ConsoleTextBuilder.AppendLine("Static compared with non static " +
                                          "System.Delegate of same type result: " +
                                          (StaticRHS1 == nonStaticRHSDel).ToString());

            ConsoleTextBuilder.AppendLine("Non static compared with non static " +
                                          "System.Delegate of differnt type result: " +
                                          (NonStaticRHS1 == nonStaticLHSDel).ToString());

            ConsoleTextBuilder.AppendLine("Static compared with static " +
                                          "System.Delegate of differnt type result: " +
                                          (StaticRHS1 == staticLHSDel).ToString());

            ConsoleTextBuilder.AppendLine("Non static compared with static " +
                                          "System.Delegate of differnt type result: " +
                                          (NonStaticRHS1 == staticLHSDel).ToString());

            ConsoleTextBuilder.AppendLine("Non Static compared with non static " +
                                          "System.Delegate with same delegate type " +
                                          "and is the same delegate " +
                                          "result: " +
                                          (NonStaticRHS1 == nonStaticRHSDel).ToString());
            ConsoleTextBuilder.AppendLine("Unless it is exactly the same delegate the " +
                                          "comparison returns false.");
        }

        /// <summary>
        /// Demonstration of a property providing access to a delegate
        /// </summary>
        private _ProcessTwoInts ProcessTwoIntsDelegateProperty
        {
            get => m_processTwoIntsDelegate;
            set => m_processTwoIntsDelegate = value;
        }

        // PRIVATE INTERFACE END





        // MEMBER VARIABLES START

        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();

        private _ProcessTwoInts m_processTwoIntsDelegate;

        // MEMBER VARIABLES END


    }
}
