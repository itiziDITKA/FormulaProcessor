using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.GreaterThan
{
    public class GreaterThan : BinaryOperator
    {
        public GreaterThan()
        {

        }

        public GreaterThan(Operand leftHandSide, Operand rightHandSide)
        {
            this.LeftHandSide = leftHandSide;
            this.RightHandSide = rightHandSide;
        }

        public GreaterThan(long leftHandSide, long rightHandSide) : this(new IntegerOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public GreaterThan(long leftHandSide, decimal rightHandSide) : this(new IntegerOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public GreaterThan(decimal leftHandSide, long rightHandSide) : this(new DecimalOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public GreaterThan(decimal leftHandSide, decimal rightHandSide) : this(new DecimalOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public GreaterThan(DateTime leftHandSide, DateTime rightHandSide) : this(new DateTimeOperand(leftHandSide), new DateTimeOperand(rightHandSide)) { }


        public override Operand Execute()
        {
            new Logging.UserLog(this.ToString());

            switch (this.LeftHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = executeLHSInteger();
                    break;
                case OperandType.Decimal:
                    this.Result = executeLHSDecimal();
                    break;
                case OperandType.DateTime:
                    this.Result = executeLHSDateTime();
                    break;
                default:
                    throw new GreaterThanException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
            return this.Result;
        }

        private Operand executeLHSDateTime()
        {
           switch(this.RightHandSide.Type)
            {
                case OperandType.DateTime:
                    return new BooleanOperand(this.LeftHandSide.AsDateTime.CompareTo(this.RightHandSide.AsDateTime) > 0 ? true : false);
                default:
                    throw new GreaterThanException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
        }

        private Operand executeLHSDecimal()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    return new BooleanOperand(this.LeftHandSide.AsDecimal > this.RightHandSide.AsInteger);
                case OperandType.Decimal:
                    return new BooleanOperand(this.LeftHandSide.AsDecimal > this.RightHandSide.AsDecimal);
                default:
                    throw new GreaterThanException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
        }

        private Operand executeLHSInteger()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    return new BooleanOperand(this.LeftHandSide.AsInteger > this.RightHandSide.AsInteger);
                case OperandType.Decimal:
                    return new BooleanOperand(this.LeftHandSide.AsInteger > this.RightHandSide.AsDecimal);
                default:
                    throw new GreaterThanException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
        }

        public override Priority Priority
        {
            get
            {
                return Priority.Comparison;
            }
        }
    }
}
