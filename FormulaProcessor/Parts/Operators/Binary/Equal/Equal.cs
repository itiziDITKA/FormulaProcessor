using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.Equal
{
    public class Equal : BinaryOperator
    {

        public Equal()
        {

        }

        public Equal(Operand leftHandSide, Operand rightHandSide)
        {
            this.LeftHandSide = leftHandSide;
            this.RightHandSide = rightHandSide;
        }

        public Equal(long leftHandSide, long rightHandSide) : this(new IntegerOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public Equal(long leftHandSide, decimal rightHandSide) : this(new IntegerOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public Equal(decimal leftHandSide, long rightHandSide) : this(new DecimalOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public Equal(decimal leftHandSide, decimal rightHandSide) : this(new DecimalOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public Equal(DateTime leftHandSide, DateTime rightHandSide) : this(new DateTimeOperand(leftHandSide), new DateTimeOperand(rightHandSide)) { }

        public Equal(string leftHandSide, string rightHandSide) : this(new StringOperand(leftHandSide), new StringOperand(rightHandSide)) { }


        public override Operand Execute()
        {
            switch(this.LeftHandSide.Type)
            {
                //TODO
                case OperandType.Boolean:
                    this.Result = executeLHSBoolean();
                    break;
                case OperandType.DateTime:
                    this.Result = executeLHSDateTime();
                    break;
                case OperandType.Decimal:
                    this.Result = executeLHSDecimal();
                    break;
                case OperandType.Integer:
                    this.Result = executeLHSInteger();
                    break;
                case OperandType.String:
                    this.Result = executeLHSString();
                    break;
                default:
                    break;
            }
            return this.Result;
        }

        private Operand executeLHSString()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.String:
                    return new BooleanOperand(String.Equals(this.LeftHandSide.AsString, this.RightHandSide.AsString, StringComparison.CurrentCulture));
                case OperandType.Decimal:
                case OperandType.Integer:
                case OperandType.DateTime:
                case OperandType.Boolean:
                default:
                    throw new EqualException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
        }

        private Operand executeLHSInteger()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Decimal:
                    return new BooleanOperand(Int64.Equals(this.LeftHandSide.AsInteger, (long)this.RightHandSide.AsDecimal));
                case OperandType.Integer:
                    return new BooleanOperand(Int64.Equals(this.LeftHandSide.AsInteger, (decimal)this.RightHandSide.AsInteger));
                case OperandType.DateTime:
                case OperandType.Boolean:
                case OperandType.String:
                default:
                    throw new EqualException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
        }

        private Operand executeLHSDecimal()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Decimal:
                    return new BooleanOperand(Decimal.Equals(this.LeftHandSide.AsDecimal, this.RightHandSide.AsDecimal));
                case OperandType.Integer:
                    return new BooleanOperand(Decimal.Equals(this.LeftHandSide.AsDecimal, (decimal)this.RightHandSide.AsInteger));
                case OperandType.DateTime:
                case OperandType.Boolean:
                case OperandType.String:
                default:
                    throw new EqualException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
        }

        private Operand executeLHSDateTime()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.DateTime:
                    return new BooleanOperand(this.LeftHandSide.AsDateTime.CompareTo(this.RightHandSide.AsDateTime) == 0);
                case OperandType.Boolean:
                case OperandType.Decimal:
                case OperandType.Integer:
                case OperandType.String:
                default:
                    throw new EqualException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
        }

        private Operand executeLHSBoolean()
        {
            switch(this.RightHandSide.Type)
            {
                case OperandType.Boolean:
                    return new BooleanOperand(this.LeftHandSide.AsBoolean == this.RightHandSide.AsBoolean);
                case OperandType.DateTime:
                case OperandType.Decimal:
                case OperandType.Integer:
                case OperandType.String:
                default:
                    throw new EqualException(this.LeftHandSide.Type, this.RightHandSide.Type);
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
