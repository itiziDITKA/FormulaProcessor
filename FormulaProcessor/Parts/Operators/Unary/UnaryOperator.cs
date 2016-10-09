using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Unary
{
    public abstract class UnaryOperator : Operator
    {
        public Operand Operand { get; set; }
    }
}
