using System.Text;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;


namespace DemoConsoleHelper_DotNET_4_7_1.Examples.StatementsExpressionsOperators.AnonymousFunctions
{
    /// <summary>
    /// Holds the examples on the use of anonymous functions.
    /// </summary>
    public sealed class ExAnonymousFunctions : ExBase
    {
        // PUBLIC INTERFACE START


        /// <summary>
        /// Contstructs the example.
        /// </summary>
        /// <remarks>
        /// Where <c cref="HelperText">HelperText</c> is set.
        /// </remarks>
        public ExAnonymousFunctions()
        {
            string helperText = @"
Anonymous Functions
Lamda Expressions, Anonymous Expressions

An anonymous function is an 'inline' statement or expression that can be used wherever
a delegate type is expected. You can use it to initialise a named delegate or pass
it instead of a named delegate type as a method parameter. 
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
            ConsoleTextBuilder.AppendLine("Example");
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










        // MEMBER VARIABLES START

        private string m_helperText;
        private StringBuilder m_consoleTextBuilder = new StringBuilder();

        // MEMBER VARIABLES END


    }
}
