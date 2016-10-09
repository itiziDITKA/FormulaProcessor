using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.NotEqual
{
    public class NotEqual : Equal.Equal
    {
        public NotEqual()
        {

        }

        public NotEqual(Operand leftHandSide, Operand rightHandSide)
        {
            this.LeftHandSide = leftHandSide;
            this.RightHandSide = rightHandSide;
        }

        public NotEqual(long leftHandSide, long rightHandSide) : this(new IntegerOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public NotEqual(long leftHandSide, decimal rightHandSide) : this(new IntegerOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public NotEqual(decimal leftHandSide, long rightHandSide) : this(new DecimalOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public NotEqual(decimal leftHandSide, decimal rightHandSide) : this(new DecimalOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public NotEqual(DateTime leftHandSide, DateTime rightHandSide) : this(new DateTimeOperand(leftHandSide), new DateTimeOperand(rightHandSide)) { }

        public NotEqual(string leftHandSide, string rightHandSide) : this(new StringOperand(leftHandSide), new StringOperand(rightHandSide)) { }

        public override Operand Execute()
        {
            return new BooleanOperand(!base.Execute().AsBoolean);
        }
    }
}
