using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Base;
using DemoConsoleHelper_DotNET_4_7_1.Examples.StatementsExpressionsOperators;
using DemoConsoleHelper_DotNET_4_7_1.Examples.SystemObjects;
using DemoConsoleHelper_DotNET_4_7_1.Examples.Types;


// Singleton pattern taken from: http://csharpindepth.com/articles/general/singleton.aspx
// Factory pattern taken from: https://www.c-sharpcorner.com/article/factory-method-design-pattern-in-c-sharp/
 

namespace DemoConsoleHelper_DotNET_4_7_1.Examples
{
    /// <summary>
    /// A singleton factory for creating examples. 
    /// </summary>
    /// <remarks>
    /// Uses the factory and singleton design patterns. 
    /// </remarks>
    public sealed class ExFactory
    {
        // PUBLIC INTERFACE START

        /// <summary>
        /// Return the sole static instance of the class.
        /// </summary>
        public static ExFactory Instance
        {
            get { return lazy.Value; }
        }

        /// <summary>
        /// Return a new Dynamic example.
        /// </summary>
        /// <returns>
        /// A example of type ExDynamic. 
        /// </returns>
        public ExDynamic ExDynamic() => m_exDynamic ?? (m_exDynamic = new ExDynamic());

        /// <summary>
        /// Return a new Delegates example.
        /// </summary>
        /// <returns>
        /// A example of type ExDelegates. 
        /// </returns>
        public ExDelegates ExDelegates() => 
            m_exDelegates ?? (m_exDelegates = new ExDelegates());

        /// <summary>
        /// Return a new Statements example.
        /// </summary>
        /// <returns>
        /// A example of statments. 
        /// </returns>
        public ExStatements ExStatements() => 
            m_exStatements ?? (m_exStatements = new ExStatements());

        /// <summary>
        /// Return a new String Type example.
        /// </summary>
        /// <returns>
        /// A example of how to use string objects.
        /// </returns>
        public ExStringType ExStringType() =>
            m_exStringType ?? (m_exStringType = new ExStringType());

        /// <summary>
        /// Return a new String Type example.
        /// </summary>
        /// <returns>
        /// A example of how to use string objects.
        /// </returns>
        public ExStringObject ExStringObject() =>
            m_exStringObject ?? (m_exStringObject = new ExStringObject());

        // PUBLIC INTERFACE END



        // PRIVATE INTERFACE START

        // Pass in a delegate to the constructor which calls the Singleton constructor
        private static readonly Lazy<ExFactory> lazy =
            new Lazy<ExFactory>(() => new ExFactory());



        // Define private constructor to stop multiple copies being created
        private ExFactory()
        {
        }

        // PRIVATE INTERFACE END




        // PRIVATE MEMBER VARIABLES START

        private ExDynamic       m_exDynamic;
        private ExDelegates     m_exDelegates;
        private ExStatements    m_exStatements;
        private ExStringType    m_exStringType;
        private ExStringObject  m_exStringObject;

        // PRIVATE MEMBER VARIABLES END
    }
}
