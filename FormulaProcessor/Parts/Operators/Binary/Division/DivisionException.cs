using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.Division
{
    public class DivisionException : Exception
    {
        public DivisionException() { }
        public DivisionException(string message) : base(message) { }
        public DivisionException(string message, Exception inner) : base(message, inner) { }
        public DivisionException(OperandType lhs, OperandType rhs)
            : base("<" +lhs.ToString() + ">" + " / " + "<" + rhs.ToString() + ">" + "is not a valid division.")
        {

        }
    }
}
