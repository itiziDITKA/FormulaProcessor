using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaProcessor.Parts.Operators.Binary.Multiplication;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Binary.Division
{
    public class Division : Multiplication.Multiplication
    {
        public Division () { }

        public Division(Operand lhs, Operand rhs) : base(lhs, rhs) { }
        public Division(long lhs, long rhs) : base(lhs, rhs) { }
        public Division(long lhs, decimal rhs) : base(lhs, rhs) { }
        public Division(decimal lhs, long rhs) : base(lhs, rhs) { }
        public Division(decimal lhs, decimal rhs) : base(lhs, rhs) { }

        public override Priority Priority
        {
            get
            {
                return Priority.Division;
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
                case OperandType.Boolean:
                    break;
            }
            throw new DivisionException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }

        private new Operand executeLHSDecimal()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = new Multiplication.Multiplication(this.LeftHandSide.AsDecimal, this.RightHandSide.AsInteger).Execute();
                    return this.Result;
                case OperandType.Decimal:
                    this.Result = new Multiplication.Multiplication(this.LeftHandSide.AsDecimal, this.RightHandSide.AsDecimal).Execute();
                    return this.Result;
                case OperandType.DateTime:
                case OperandType.Boolean:
                    break;
            }
            throw new DivisionException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }

        private new Operand executeLHSInteger()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = new Multiplication.Multiplication(this.LeftHandSide.AsInteger, 1 / this.RightHandSide.AsInteger).Execute();
                    return this.Result;
                case OperandType.Decimal:
                    this.Result = new Multiplication.Multiplication(this.LeftHandSide.AsInteger, 1 / this.RightHandSide.AsDecimal).Execute();
                    return this.Result;
                case OperandType.DateTime:
                case OperandType.Boolean:
                    break;
            }
            throw new DivisionException(this.LeftHandSide.Type, this.RightHandSide.Type);
        }
    }
}
