using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Interfaces;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Base
{
    abstract class ExBase: IHelperText
    {
        protected string m_helperText;
        protected StringBuilder m_consoleOutput;

        protected ExBase()
        {
            m_consoleOutput = new StringBuilder();

            Run();  // Is called by more derived class to run example. 
        }

        public abstract string HelperText
        {
            get;
            protected set;
        }

        public abstract string ConsoleOutput
        {
            get;
        }

        protected abstract void Run();
    }
}
