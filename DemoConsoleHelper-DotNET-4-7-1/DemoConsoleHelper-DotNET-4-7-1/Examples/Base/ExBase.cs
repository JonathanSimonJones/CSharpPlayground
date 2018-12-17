using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Interfaces;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples.Base
{
    abstract class ExBase: IRun, IHelperText
    {
        protected string m_helperText;

        public abstract string HelperText
        {
            get;
            protected set;
        }

        public abstract void Run();
    }
}
