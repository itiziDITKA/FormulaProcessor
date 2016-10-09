using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.Subtraction
{
    public class Subtraction : Addition.Addition
    {
        public Subtraction() { }
        public Subtraction(Operand lhs, Operand rhs) : base(lhs, rhs) { }
        public Subtraction(long lhs, long rhs) : base(lhs, rhs) { }
        public Subtraction(long lhs, decimal rhs) : base(lhs, rhs) { }
        public Subtraction(decimal lhs, long rhs) : base(lhs, rhs) { }
        public Subtraction(decimal lhs, decimal rhs) : base(lhs, rhs) { }
        public Subtraction(DateTime lhs, long rhs) : base(lhs, rhs) { }

        public override Priority Priority
        {
            get
            {
                return Priority.Subtraction;
            }
        }


        public override Operand Execute()
        {
            new Logging.UserLog(this.ToString());

            switch (this.LeftHandSide.Type)
            {
                case OperandType.Integer:
                    return executeLHSInteger();
                case OperandType.Decimal:
                    return executeLHSDecimal();
                case OperandType.DateTime:
                    return executeLHSDateTime();
                case OperandType.Boolean:
                    break;
            }
            throw new SubtractionException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }


        public override string ToString()
        {
            if (this.Result != null)
            {
                return this.LeftHandSide.ToString() + " - " + this.RightHandSide.ToString() + " = " + this.Result.ToString();
            }
            else
            {
                return this.LeftHandSide.ToString() + " - " + this.RightHandSide.ToString();
            }
        }

        private Operand executeLHSDateTime()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = new Addition.Addition(this.LeftHandSide.AsDateTime, -(this.RightHandSide.AsInteger)).Execute();
                    return this.Result;
                case OperandType.Decimal:
                case OperandType.DateTime:
                case OperandType.Boolean:
                    break;
            }
            throw new SubtractionException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }

        private Operand executeLHSDecimal()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = new Addition.Addition(this.LeftHandSide.AsDecimal, -(this.RightHandSide.AsInteger)).Execute();
                    return this.Result;
                case OperandType.Decimal:
                    this.Result = new Addition.Addition(this.LeftHandSide.AsDecimal, -(this.RightHandSide.AsDecimal)).Execute();
                    return this.Result;
                case OperandType.DateTime:
                case OperandType.Boolean:
                    break;
            }
            throw new SubtractionException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }

        private Operand executeLHSInteger()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = new Addition.Addition(this.LeftHandSide.AsInteger, -(this.RightHandSide.AsInteger)).Execute();
                    return this.Result;
                case OperandType.Decimal:
                    this.Result = new Addition.Addition(this.LeftHandSide.AsInteger, -(this.RightHandSide.AsDecimal)).Execute();
                    return this.Result;
                case OperandType.DateTime:
                case OperandType.Boolean:
                    break;
            }
            throw new SubtractionException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }
    }
}
