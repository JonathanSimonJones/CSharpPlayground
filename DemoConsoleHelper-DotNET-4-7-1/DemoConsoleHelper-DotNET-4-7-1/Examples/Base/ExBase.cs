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
        // PUBLIC INTERFACE START

        public abstract string HelperText
        {
            get;
            protected set;
        }

        public abstract string ConsoleText { get; }

        // PUBLIC INTERFACE END








        // PROTECTED INTERFACE START

        protected ExBase()
        {
            Run();  // Run is defined in more derived class, but called here
        }

        protected abstract void Run();

        protected abstract StringBuilder ConsoleTextBuilder { get; }

        // PROTECTED INTERFACE END









        // PRIVATE MEMBER VARIABLES START

        //      Define member variables in derived class, makes for looser coupling

        // PRIVATE MEMBER VARIABLES END
    }
}
