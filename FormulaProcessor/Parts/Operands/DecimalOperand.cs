using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operands
{
    public class DecimalOperand : Operand
    {
        public DecimalOperand(decimal value) : base(value, OperandType.Decimal) { }
    }
}
