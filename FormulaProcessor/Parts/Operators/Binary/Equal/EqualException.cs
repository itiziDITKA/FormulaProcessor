using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.Equal
{
    public class EqualException : Exception
    {
        public EqualException() { }
        public EqualException(string message) : base(message) { }
        public EqualException(string message, Exception inner) : base(message, inner) { }
        public EqualException(OperandType lhs, OperandType rhs)
            : base("<" +lhs.ToString() + ">" + " == " + "<" + rhs.ToString() + ">" + "is not a valid equality.")
        {

        }
    }
}
