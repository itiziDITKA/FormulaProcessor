using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Unary.Not
{
    public class Not : UnaryOperator
    {
        public Not(Operand operand)
        {
            this.Operand = operand;
        }

        public Not(bool operand) : this(new BooleanOperand(operand)) { }

        public override Operand Execute()
        {
            return new BooleanOperand(!(this.Operand.AsBoolean));
        }


        public override Priority Priority
        {
            get
            {
                return Priority.Not;
            }
        }
    }
}
