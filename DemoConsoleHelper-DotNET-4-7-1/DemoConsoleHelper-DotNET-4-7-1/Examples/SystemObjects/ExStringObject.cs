using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;

// Most of the examples taken on 29-12-2018 from: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/index

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

Use regular string literals when you need to use escape characters emebeded in the string.

Use vertabim strings for convenience and better readability. Example use cases include:
When the string contains backslash characters
Preserve structure of text

Use two double quotations in verbatim strings to escape a lone double quotation.

At compile time, verbatim strings are converted to ordinary strings with all the same 
escape sequences. Therefore if you you view a verbatim string in the debugger watch 
window you will see the escape characters that were added by the compiler, not the 
verbatim version from source. 

String interpolation is the process of evaluating a string literal containing one or more 
placeholders, yielding a result in which the placeholders are replaced with their 
corresponding values. 

Format strings are strings whose contents are determined dynamically at runtime. 

Format string at strings with interpolated expressions (see above for definition of 
string interpolation) or placeholders inside of braces {}. Everything inside the bracers 
will be resolved to a value and output as a formatted string at runtime. There are two 
methods to create formatted strings, they are: 
String interpolation
composite formatting

Interpolation strings start with $ immediately followed by "" and ends with "". In 
between the "" you get braces {} which hold interpolated expressions. 

To use composite formatting you can use String.Format(). You specify a literal string 
and include any placeholders in the string with an integer of the arguement number after 
the string, contained within bracers. e.g. String.Format(""some text {0}"", someInt);

You can grab part of a string using the Substring() method. 
Returns a new string. 

You can find one or more characters in a string using IndexOf().

Replace() will replace all occurences of a value specified with a new value you specify. 
Returns a new string.

You can access individual chars in a string by using square brackets (array notation) [] 
with the index value of the char you want. It is provided as readonly. 

You can add null to a string without consequence. 

String.Empty returns an object of string which contains no characters and has no length.

You can compare null with a string object. 

You can include the null character in a string. 

If you are doing many operations on strings, prefer the use of the StringBuilder class. 
As strings are immutable if you ever change a string it creates a new object which is 
not performant. The StringBuilder class creates a string buffer the offers better 
performance if your program performs many string manipulations. It also allows the 
changing of individual characters. 
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

            _EscapeCharacterExamples();

            _VerbatimStringExamples();

            _StringInterpolationExample();

            _CompositeFormattingExample();

            _SubStringsExample();

            _ReplaceExample();

            _IndexOfExample();

            _AccessIndividualChar();

            _NullStringExamples();

            _StringBuilderExample();
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

        private void _EscapeCharacterExamples()
        {
            string columns = "Column 1\tColumn 2\tColumn 3";
            //Output: Column 1        Column 2        Column 3

            string rows = "Row 1\r\nRow 2\r\nRow 3";
            // Output:
            //  Row 1
            //  Row 2
            //  Row 3
            

            string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
            //Output: "The Æolean Harp", by Samuel Taylor Coleridge
        }

        private void _VerbatimStringExamples()
        {
            string filePath = @"C:\Users\scoleridge\Documents\";
            // Output: C:\Users\scoleridge\Documents\

            string text = @"My pensive SARA ! thy soft cheek reclined
    Thus on mine arm, most soothing sweet it is
    To sit beside our Cot,...";
            // Output:
            // My pensive SARA ! thy soft cheek reclined
            //    Thus on mine arm, most soothing sweet it is
            //    To sit beside our Cot,... 
            

            string quote = @"Her name was ""Sara.""";
            // Output: Her name was "Sara."
        }

        private void _StringInterpolationExample()
        {
            int number = 3;

            ConsoleTextBuilder.AppendLine($"The number is this string ({number}) was " +
                                          $"included via string interpolation!");
        }

        private void _CompositeFormattingExample()
        {
            decimal number = 5.2M;
            string forConsoleTextBuilder =
                String.Format("This number ({0}) was included via composit formatting." +
                              "", number);

            ConsoleTextBuilder.AppendLine(forConsoleTextBuilder);
        }

        private void _SubStringsExample()
        {
            string someString = "Just some chars in some string";
            string subString = someString.Substring(5, 4);

            ConsoleTextBuilder.AppendLine("The content of the substring: " + subString);
        }

        private void _ReplaceExample()
        {
            string foo = "foo";
            string replaceFooWithBar = foo.Replace("foo", "bar");

            ConsoleTextBuilder.AppendLine("Value of the replaced string: "
                                          + replaceFooWithBar);
        }

        private void _IndexOfExample()
        {
            string strToSearch = "find and the letter z in this string z   z z     z";
            int indexOfZinStr = strToSearch.IndexOf('z');

            ConsoleTextBuilder.AppendLine("Index value of first z occurence: " 
                                          + indexOfZinStr.ToString());
        }

        private void _AccessIndividualChar()
        {
            string word = "zebra";
            char letter = word[2];

            ConsoleTextBuilder.AppendLine($"The letter is: {letter}");
        }

        private void _NullStringExamples()
        {
            // You can concatinate null strings with empty or filled strings without
            // issue

            string strNull = null;
            string strVal = "value";
            string strEmpty = string.Empty;

            bool exceptionThrown = false;
            try
            {
                string addingNullAndValue = strNull + strVal;

                ConsoleTextBuilder.AppendLine($"Adding a string set to null with a string " +
                                              $"that has a value result: " +
                                              $"{addingNullAndValue}");

                string addingValueAndNull = strVal + strNull;

                ConsoleTextBuilder.AppendLine($"Adding a string set with a value with a " +
                                              $"string set to null result: " +
                                              $"{addingValueAndNull}");

                string addingNullAndEmpty = strNull + strEmpty;

                ConsoleTextBuilder.AppendLine($"Adding a string set to null with a string " +
                                              $"that is empty result: " +
                                              $"{addingNullAndEmpty}");

                string addingEmptyAndNull = strEmpty + strNull;

                ConsoleTextBuilder.AppendLine($"Adding a string set to empty with a " +
                                              $"string set to null result: " +
                                              $"{addingEmptyAndNull}");
            }
            catch (Exception e)
            {
                exceptionThrown = true;
                ConsoleTextBuilder.AppendLine("This should not show");
            }
            finally
            {
                ConsoleTextBuilder.AppendLine("No exception should have been thrown");
            }

            if (exceptionThrown == false)
            {
                ConsoleTextBuilder.AppendLine("Adding a null to string does not throw an " +
                                              "exception.");
            }

            bool compareNullAndEmpty = (strNull == strEmpty);

            ConsoleTextBuilder.AppendLine($"Result of comparing null and empty: " +
                                          $"{compareNullAndEmpty}");
            ConsoleTextBuilder.AppendLine("They are not the same. string.Empty is an " +
                                          "object while null is not.");

            ConsoleTextBuilder.AppendLine($"Length of empty string: {strEmpty.Length}");

            // Throws a NullReferenceException
            // ConsoleTextBuilder.AppendLine(strNull.Length);

            string strIncludingNullChar = "str\x0";

            ConsoleTextBuilder.AppendLine($"string include null character surrounded by " +
                                          $"@ to show null character: " +
                                          $"@{strIncludingNullChar}@");


        }

        private void _StringBuilderExample()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("some text");

            sb.Append(" and add some number 4");

            ConsoleTextBuilder.AppendLine($"Text in sb: {sb}");

            // Change number
            sb[sb.Length - 1] = '3';

            ConsoleTextBuilder.AppendLine($"After changing the number: {sb}");

            // Make jumbled text but show you can assign one char to another
            sb[0] = sb[1];

            ConsoleTextBuilder.AppendLine($"Copied sb[1] to sb[0]: {sb}");

            string cantSetIndividualCharExample = "some string";

            // Doesn't work, return a index item from a string is read only
            //cantSetIndividualCharExample[0] = 'S';
        }

        // PRIVATE INTERFACE END





        // MEMBER VARIABLES START

        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();

        // MEMBER VARIABLES END


    }
}
