using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators
{
    public abstract class Operator : Part
    {
        public Operand Result { get; set; }
        public abstract Priority Priority { get; }
    }
}
