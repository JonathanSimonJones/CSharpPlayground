using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Interfaces;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Base
{

    /// <summary>
    /// An abstract base class for C# code examples. Used to enforce interface.
    /// </summary>
    public abstract class ExBase: IHelperText, IConsoleText
    {
        // PUBLIC INTERFACE START


        /// <summary>
        /// Displays a helpful message about the example in question.
        /// </summary>
        public abstract string HelperText
        {
            get;
            protected set;
        }


        /// <summary>
        /// Holds content to be displayed to a terminal console.
        /// </summary>
        public abstract string ConsoleText { get; }

        // PUBLIC INTERFACE END








        // PROTECTED INTERFACE START


        /// <summary>
        /// Constructs example objects. Implicitly calls <c cref="Run()">Run()</c>.
        /// </summary>
        /// <remarks>
        /// Implicity calls <c cref="Run()">Run()</c> for more derived class.  
        /// </remarks>
        protected ExBase()
        {
            Run();
        }

        /// <summary>
        /// Holds the example code to be run. Where most of the work happens.
        /// </summary>
        protected abstract void Run();


        /// <summary>
        /// Interface to object that is used to collect any text for a console/terminal. 
        /// </summary>
        protected abstract StringBuilder ConsoleTextBuilder { get; }

        // PROTECTED INTERFACE END









        // PRIVATE MEMBER VARIABLES START

        //      Define member variables in derived class, makes for looser coupling

        // PRIVATE MEMBER VARIABLES END
    }
}
