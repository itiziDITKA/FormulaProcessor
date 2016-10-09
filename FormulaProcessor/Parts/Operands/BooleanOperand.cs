using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operands
{
    public class BooleanOperand : Operand
    {
        public BooleanOperand(bool value) : base(value, OperandType.Boolean) { }
    }
}
