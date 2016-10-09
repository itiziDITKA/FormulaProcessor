using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.Multiplication
{
    public class Multiplication : BinaryOperator
    {
        public Multiplication() { }
        public Multiplication(Operand lhs, Operand rhs)
        {
            this.LeftHandSide = lhs;
            this.RightHandSide = rhs;
        }

        public Multiplication(long lhs, long rhs) : this(new IntegerOperand(lhs), new IntegerOperand(rhs)) { }
        public Multiplication(long lhs, decimal rhs) : this(new IntegerOperand(lhs), new DecimalOperand(rhs)) { }
        public Multiplication(decimal lhs, long rhs) : this(new DecimalOperand(lhs), new IntegerOperand(rhs)) { }
        public Multiplication(decimal lhs, decimal rhs) : this(new DecimalOperand(lhs), new DecimalOperand(rhs)) { }


        public override Priority Priority
        {
            get
            {
                return Priority.Multiplication;
            }
        }

        public override Operand Execute()
        {
            new Logging.UserLog(this.ToString());

            switch (this.LeftHandSide.Type)
            {
                case OperandType.Integer:
                    return this.executeLHSInteger();
                case OperandType.Decimal:
                    return this.executeLHSDecimal();
                case OperandType.DateTime:
                case OperandType.Boolean:
                    throw new MultiplicationException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }

            return this.Result;
        }


        public override string ToString()
        {
            if (this.Result != null)
            {
                return this.LeftHandSide.ToString() + " * " + this.RightHandSide.ToString() + " = " + this.Result.ToString();
            }
            else
            {
                return this.LeftHandSide.ToString() + " * " + this.RightHandSide.ToString();
            }
        }


        public Operand executeLHSInteger()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = new IntegerOperand(this.LeftHandSide.AsInteger * this.RightHandSide.AsInteger);
                    return this.Result;
                case OperandType.Decimal:
                    this.Result = new DecimalOperand(this.LeftHandSide.AsInteger * this.RightHandSide.AsDecimal);
                    return this.Result;
                case OperandType.DateTime:
                case OperandType.Boolean:
                    throw new MultiplicationException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
            throw new MultiplicationException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }

        public Operand executeLHSDecimal()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = new DecimalOperand(this.LeftHandSide.AsDecimal * this.RightHandSide.AsInteger);
                    return this.Result;
                case OperandType.Decimal:
                    this.Result = new DecimalOperand(this.LeftHandSide.AsDecimal * this.RightHandSide.AsDecimal);
                    return this.Result;
                case OperandType.DateTime:
                case OperandType.Boolean:
                    throw new MultiplicationException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
            throw new MultiplicationException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }

    }
}
