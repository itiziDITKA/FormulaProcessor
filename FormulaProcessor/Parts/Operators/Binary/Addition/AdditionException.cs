using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Binary.Addition
{
    [Serializable]
    public class AdditionException : Exception
    {
        public AdditionException() { }
        public AdditionException(string message) : base(message) { }
        public AdditionException(string message, Exception inner) : base(message, inner) { }
        public AdditionException(OperandType lhs, OperandType rhs)
            : base("<" +lhs.ToString() + ">" + " + " + "<" + rhs.ToString() + ">" + "is not a valid additon.")
        {
            
        }

    }
}
