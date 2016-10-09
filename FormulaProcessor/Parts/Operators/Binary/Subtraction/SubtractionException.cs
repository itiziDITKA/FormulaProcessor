using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.Subtraction
{
    [Serializable]
    class SubtractionException :Exception
    {
        public SubtractionException() { }
        public SubtractionException(string message) : base(message) { }
        public SubtractionException(string message, Exception inner) : base(message, inner) { }
        public SubtractionException(OperandType lhs, OperandType rhs)
            : base("<" +lhs.ToString() + ">" + " - " + "<" + rhs.ToString() + ">" + "is not a valid subtraction.")
        {

        }
    }
}
