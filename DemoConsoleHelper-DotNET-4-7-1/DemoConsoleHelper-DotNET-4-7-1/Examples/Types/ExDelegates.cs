using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Types
{
    public sealed class ExDelegates : ExBase
    {
        // PUBLIC INTERFACE START

        public ExDelegates()
        {
            string helperText = @"
Delegates
";
            HelperText = helperText;
        }

        public override string HelperText
        {
            get => m_helperText;
            protected set => m_helperText = value;
        }

        public override string ConsoleText
        {
            get => ConsoleTextBuilder.ToString();
        }

        // PUBLIC INTERFACE END





        // PROTECTED INTERFACE START

        // Called in base class constructor
        protected override void Run()
        {
            ConsoleTextBuilder.AppendLine("Delegates Example");
        }

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
