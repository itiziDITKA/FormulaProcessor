using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operands
{
    public class DateTimeOperand : Operand
    {
        public DateTimeOperand(DateTime value) : base(value, OperandType.DateTime) { }
    }
}
