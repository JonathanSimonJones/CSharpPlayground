using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Interfaces;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples
{
    // Reference type
    // Enables operations to bypass compile-time type checking and instead resolve
    // type at run time
    // Dynamic only exist at compile time, at run time variables of type dynamic 
    // are compiled into variables of type object
    class ExDynamic : ExBase
    {
        private dynamic m_dyn = 3;
        public dynamic m_obj = 4;

        public ExDynamic()
        {
            HelperText = "This is some text.";
        }

        public override string HelperText
        {
            get { return base.m_helperText; }
            protected set { base.m_helperText = value; }
        }


        public override void Run()
        {
            System.Console.WriteLine(this.HelperText);
            System.Console.WriteLine(m_dyn.GetType());
            System.Console.WriteLine(m_obj.GetType());
        }
    }


}
