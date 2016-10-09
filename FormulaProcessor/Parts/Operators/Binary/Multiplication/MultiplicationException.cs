using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.Multiplication
{
    [Serializable]
    class MultiplicationException : Exception
    {
        public MultiplicationException() { }
        public MultiplicationException(string message) : base(message) { }
        public MultiplicationException(string message, Exception inner) : base(message, inner) { }
        public MultiplicationException(OperandType lhs, OperandType rhs)
            : base("<" +lhs.ToString() + ">" + " * " + "<" + rhs.ToString() + ">" + "is not a valid multiplication.")
        {

        }
    }
}
