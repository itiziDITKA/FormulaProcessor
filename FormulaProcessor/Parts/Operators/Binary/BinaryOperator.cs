using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaProcessor.Parts.Operands;
using FormulaProcessor.Parts.Operators.Binary.Addition;

namespace FormulaProcessor.Parts.Operators.Binary
{
    public abstract class BinaryOperator : Operator
    {
        protected Operand LeftHandSide { get; set; }
        protected Operand RightHandSide { get; set; }
    }
}
