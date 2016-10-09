using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts
{
    [Serializable]
    public class PartException : Exception
    {
        public PartException() { }
        public PartException(string message) : base(message) { }
        public PartException(string message, Exception inner) : base(message, inner) { }
    }
}
