using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.LessThanOrEqual
{
   public class LessThanOrEqual : GreaterThan.GreaterThan
    {
        public LessThanOrEqual()
        {

        }

        public LessThanOrEqual(Operand leftHandSide, Operand rightHandSide)
        {
            this.LeftHandSide = leftHandSide;
            this.RightHandSide = rightHandSide;
        }

        public LessThanOrEqual(long leftHandSide, long rightHandSide) : this(new IntegerOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public LessThanOrEqual(long leftHandSide, decimal rightHandSide) : this(new IntegerOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public LessThanOrEqual(decimal leftHandSide, long rightHandSide) : this(new DecimalOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public LessThanOrEqual(decimal leftHandSide, decimal rightHandSide) : this(new DecimalOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public LessThanOrEqual(DateTime leftHandSide, DateTime rightHandSide) : this(new DateTimeOperand(leftHandSide), new DateTimeOperand(rightHandSide)) { }

        public override Operand Execute()
        {
            this.Result = new BooleanOperand(!base.Execute().AsBoolean);
            return this.Result;
        }

        public override Priority Priority
        {
            get
            {
                return base.Priority;
            }
        }
    }
}
