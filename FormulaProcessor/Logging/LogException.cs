using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Logging
{
    [Serializable]
    public class LogException : Exception
    {
        public LogException() { }
        public LogException(string message) : base(message) { }
        public LogException(string message, Exception inner) : base(message, inner) { }
    }
}
