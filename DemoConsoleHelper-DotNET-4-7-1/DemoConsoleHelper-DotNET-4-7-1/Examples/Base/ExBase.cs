using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Interfaces;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Base
{
    public abstract class ExBase: IHelperText, IConsoleText
    {
        protected string m_helperText;
        protected StringBuilder m_consoleTextBuilder;

        protected ExBase()
        {
            m_consoleTextBuilder = new StringBuilder();

            Run();  // Is called by more derived class to run example. 
        }

        public abstract string HelperText
        {
            get;
            protected set;
        }

        protected abstract StringBuilder ConsoleTextBuilder { get; }

        public string ConsoleText
        {
            get { return ConsoleTextBuilder.ToString(); }
        }

        protected abstract void Run();
    }
}
