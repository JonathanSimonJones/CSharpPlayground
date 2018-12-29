using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.SystemObjects
{
    /// <summary>
    /// Examples involving the string object
    /// </summary>
    public sealed class ExStringObject : ExBase
    {
        // PUBLIC INTERFACE START


        /// <summary>
        /// Contstructs the example.
        /// </summary>
        /// <remarks>
        /// Where <c cref="HelperText">HelperText</c> is set.
        /// </remarks>
        public ExStringObject()
        {
            string helperText = @"
String Object

A string is an object of type String whose value is text. 

It is stored as a sequential read-only collection of Char objects. There is no 
null-terminating character at the end of a C# string, therefore it can contain any 
number of embedded null characters eg. \0 . 

The length property represents the number of Char objects it contains, not the Unicode 
characters. 

To access the Unicode code points in a string, use StringInfo object. 

When creating a string you do not need to use the new keyword to create an object, 
except when initalizing the string with an array of chars. 

Initialising a string with the Empty property of System.String will create a string is 
of zero length, which is also """" (a double quotation mark with no data between). By 
utilising the Empty property you reduce the chances of a NullreferenceException 
occuring. 

Strings are immutable (the content cannot be changed). 

In concatinating (adding) strings you create a new string object. 

If you attempt to copy a string object you are setting a reference to an object, not 
copying the value (content) of the string. 
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
            _InitialiseStringExamples();

            _CopyingAStringExample();

            _AssigningAStringExample();
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

        private void _InitialiseStringExamples()
        {
            // Declare without initializing.
            string message1;

            // Initialize to null.
            string message2 = null;

            // Initialize as an empty string.
            // Use the Empty constant instead of the literal "".
            string message3 = System.String.Empty;

            //Initialize with a regular string literal.
            string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";

            // Initialize with a verbatim string literal.
            string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";

            // Use System.String if you prefer.
            System.String greeting = "Hello World!";

            // In local variables (i.e. within a method body)
            // you can use implicit typing.
            var temp = "I'm still a strongly-typed System.String!";

            // Use a const string to prevent 'message4' from
            // being used to store another string value.
            const string message4 = "You can't get rid of me!";

            // Use the String constructor only when creating
            // a string from a char*, char[], or sbyte*. See
            // System.String documentation for details.
            char[] letters = { 'A', 'B', 'C' };
            string alphabet = new string(letters);
        }

        private void _CopyingAStringExample()
        {
            // Copying a string actually creates a reference to the string object
            string s1 = "A string is more ";
            string s2 = "than the sum of its chars.";

            // Concatenate s1 and s2. This actually creates a new
            // string object and stores it in s1, releasing the
            // reference to the original object.
            s1 += s2;

            ConsoleTextBuilder.AppendLine("s1 should now be \"A string is more than the" +
                                          " sum of its chars\": " + s1);
        }

        private void _AssigningAStringExample()
        {
            string s1 = "Hello ";
            string s2 = s1;
            s1 += "World";

            ConsoleTextBuilder.AppendLine("This should output \"Hello \":" + s2);
            ConsoleTextBuilder.AppendLine("This should output \"Hello World\":" + s1);

            // s2 now has a reference to "Hello"
        }

        // PRIVATE INTERFACE END





        // MEMBER VARIABLES START

        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();

        // MEMBER VARIABLES END


    }
}
