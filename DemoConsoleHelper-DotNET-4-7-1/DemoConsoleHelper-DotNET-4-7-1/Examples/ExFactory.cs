using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Types;

namespace DemoConsoleHelper_DotNET_4_7_1.Examples
{
    class ExFactory
    {
        public ExBase ExDynamic()
        {
            return new ExDynamic();
        }
    }
}
