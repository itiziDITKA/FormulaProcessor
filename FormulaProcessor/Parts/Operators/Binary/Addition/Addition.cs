using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Binary.Addition
{
    public class Addition : BinaryOperator
    {
        public Addition()
        {
        }

        public Addition(Operand leftHandSide, Operand rightHandSide)
        {
            this.LeftHandSide = leftHandSide;
            this.RightHandSide = rightHandSide;
        }

        public Addition(long leftHandSide, long rightHandSide) : this(new IntegerOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public Addition(long leftHandSide, decimal rightHandSide): this(new IntegerOperand(leftHandSide), new DecimalOperand(rightHandSide)){ }
        public Addition(long leftHandSide, DateTime rightHandSide) : this(new IntegerOperand(leftHandSide), new DateTimeOperand(rightHandSide)) { }
        public Addition(decimal leftHandSide, long rightHandSide) : this(new DecimalOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public Addition(decimal leftHandSide, decimal rightHandSide) : this(new DecimalOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }
        public Addition(DateTime leftHandSide, long rightHandSide) : this(new DateTimeOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }

        public override Priority Priority { get { return Priority.Addition; } }

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
                case OperandType.Boolean:
                    throw new AdditionException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }


            return this.Result;
        }

        public override string ToString()
        {
            if (this.Result != null)
            {
                return this.LeftHandSide.ToString() + " + " + this.RightHandSide.ToString() + " = " + this.Result.ToString();
            }
            else
            {
                return this.LeftHandSide.ToString() + " + " + this.RightHandSide.ToString();
            }
        }


        private Operand executeLHSDateTime()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    return new DateTimeOperand(this.LeftHandSide.AsDateTime.AddDays(this.RightHandSide.AsInteger));
                case OperandType.Decimal:
                case OperandType.DateTime:
                case OperandType.Boolean:
                    throw new AdditionException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
            throw new AdditionException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }

        private Operand executeLHSDecimal()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                case OperandType.Decimal:
                    return new DecimalOperand(this.LeftHandSide.AsDecimal + this.RightHandSide.AsDecimal);
                case OperandType.DateTime:
                case OperandType.Boolean:
                    throw new AdditionException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
            throw new AdditionException(this.LeftHandSide.Type, this.RightHandSide.Type);

        }

        private Operand executeLHSInteger()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    return new IntegerOperand(this.LeftHandSide.AsInteger + this.RightHandSide.AsInteger);
                case OperandType.Decimal:
                    return new DecimalOperand(this.LeftHandSide.AsDecimal + this.RightHandSide.AsDecimal);
                case OperandType.DateTime: //will add days to an a date time
                    return new DateTimeOperand(this.RightHandSide.AsDateTime.AddDays(this.LeftHandSide.AsInteger));
                case OperandType.Boolean:
                    throw new AdditionException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
            throw new AdditionException(this.LeftHandSide.Type, this.RightHandSide.Type);

        }
    }
}
