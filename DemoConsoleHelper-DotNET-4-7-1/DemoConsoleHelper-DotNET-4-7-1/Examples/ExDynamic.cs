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

    class ExDynamic : ExBase
    {
        private dynamic m_dyn = 3;
        private object m_obj = 4;

        public ExDynamic()
        {
            string helperText = @"
 Reference type
 Enables operations to bypass compile-time type checking and instead resolve type at run time
 Dynamic behaves like object in most circumstances.
 Operations that contain expressions of type dynamic are not resolved or type checked by the complier.
 Dynamic only exist at compile time, at run time variables of type dynamic are compiled into variables of type object.
"; 
            HelperText = helperText;
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

            // Will compile as dynamic type checking is done at run time
            m_dyn = m_dyn + 3;  

            // Will stop compilation as object types are checked at compile time
            // and m_obj is of type object
            //m_obj = m_obj + 3;
        }
    }


}
