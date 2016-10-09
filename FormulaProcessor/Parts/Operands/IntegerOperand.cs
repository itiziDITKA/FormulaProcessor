using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operands
{
    public class IntegerOperand : Operand
    {
        public IntegerOperand(long value) : base(value, OperandType.Integer) { }
    }
}
