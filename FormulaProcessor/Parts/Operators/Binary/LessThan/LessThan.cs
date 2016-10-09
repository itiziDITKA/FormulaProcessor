using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaProcessor.Parts.Operators.Binary.GreaterThanOrEqual;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Binary.LessThan
{
    public class LessThan : FormulaProcessor.Parts.Operators.Binary.GreaterThanOrEqual.GreaterThanOrEqual
    {
        public LessThan()
        {

        }

        public LessThan(Operand leftHandSide, Operand rightHandSide)
        {
            this.LeftHandSide = leftHandSide;
            this.RightHandSide = leftHandSide;
        }

        public LessThan(long leftHandSide, long rightHandSide) : this(new IntegerOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public LessThan(long leftHandSide, decimal rightHandSide) : this(new IntegerOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public LessThan(decimal leftHandSide, long rightHandSide) : this(new DecimalOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public LessThan(decimal leftHandSide, decimal rightHandSide) : this(new DecimalOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public LessThan(DateTime leftHandSide, DateTime rightHandSide) : this(new DateTimeOperand(leftHandSide), new DateTimeOperand(rightHandSide)) { }


        ///executes greater than or equal and returns the opposite
        public override Operand Execute()
        {
            new Logging.UserLog(this.ToString());
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
