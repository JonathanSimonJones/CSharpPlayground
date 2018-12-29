using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;


namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Types
{
    /// <summary>
    /// Examples of functionality of string as a type
    /// </summary>
    public sealed class ExStringType : ExBase
    {
        // PUBLIC INTERFACE START


        /// <summary>
        /// Contstructs the example.
        /// </summary>
        /// <remarks>
        /// Where <c cref="HelperText">HelperText</c> is set.
        /// </remarks>
        public ExStringType()
        {
            string helperText = @"
String type
Reference type

string type represents a sequence of zero or more Unicode characters. 

string is an alias for String in .NET. 

== and != compare values even though it is a reference type.

+ concatinates strings.

Strings are immutable. It may not appear this way given the behaviour but that 
is what goes on behind the scenes. When you attempt to change the value of a string a 
new string is made. Then the string being assigned is assocaited with the newly 
created string. 

The [] operator can be used to access individual chars in the string.

Sting literals are of type string and can be written in two forms, quioted and 
@-quoted. Sring literals are enclosed in double quotation marks """". 

String literals can contain any character literal. Escape sequences are included. 

If a string is preceeded by the @ symbol, the string is known as a verbatim string. 
Escape sequences are not processed in vertabim strings. They start is with an @ 
symbol and are enclosed by double quotations """".

string is an alias for System.String. 

System.String provides methods for safely creating, manipulating and comparing strings. 
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
            // Examples of a string literal assigned to variable/identifier
            string a = "foo";   
            string b = "foo";
            string c = "bar";

            ConsoleTextBuilder.AppendLine("Result of comparing two different string " +
                                          "objects with the same values using == " +
                                          "operator: " +
                                          (a == b).ToString());

            ConsoleTextBuilder.AppendLine("Result of comparing two different string " +
                                          "objects with the differnt values != " +
                                          "operator: " +
                                          (a == c).ToString());

            string d = a + b;

            ConsoleTextBuilder.AppendLine("Result of using + operator on two string " +
                                          "objects:" +
                                          d.ToString());

            // This demos that both a and b both reference the same object
            ConsoleTextBuilder.AppendLine("Demo of string address being different " +
                                          "using Object.ReferenceEquals():" +
                                          Object.ReferenceEquals(a, b).ToString());

            a = "change";

            // After changing a, a now references an object somewhere else
            ConsoleTextBuilder.AppendLine("Demo of string address being different " +
                                          "using Object.ReferenceEquals():" +
                                          Object.ReferenceEquals(a, b).ToString());

            ConsoleTextBuilder.AppendLine("Demo of using [] operator: " +
                                          a[0]);

            // Example of using a escape character to reference the unicode code point 
            // for the latin captical letter J twice
            ConsoleTextBuilder.AppendLine("The following should say JJ: " + "\u004A\u004A");

            // Example of a verbatim string
            ConsoleTextBuilder.AppendLine("The following shows that in a verbatin string" +
                                          " the escape sequence is not processed: " 
                                          + @"\u004A\u004A");

            // Escaping double quotations in a verbatim string
            ConsoleTextBuilder.AppendLine("This demonstrates using a double quotation " +
                                          "in a verbatim string: " + 
                                          @"""This text is inside rendered double quotes""");
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



        // PRIVATE INTERFACE END





        // MEMBER VARIABLES START

        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();

        // MEMBER VARIABLES END


    }
}
