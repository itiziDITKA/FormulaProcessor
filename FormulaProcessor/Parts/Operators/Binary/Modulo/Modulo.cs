using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators.Binary.Modulo
{
    public class Modulo : BinaryOperator
    {
        public Modulo()
        {

        }

        public Modulo(Operand leftHandSide, Operand rightHandSide)
        {
            this.LeftHandSide = leftHandSide;
            this.RightHandSide = rightHandSide;
        }

        public Modulo(long leftHandSide, long rightHandSide) : this(new IntegerOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public Modulo(long leftHandSide, decimal rightHandSide): this(new IntegerOperand(leftHandSide), new DecimalOperand(rightHandSide)){ }
        public Modulo(decimal leftHandSide, long rightHandSide) : this(new DecimalOperand(leftHandSide), new IntegerOperand(rightHandSide)) { }
        public Modulo(decimal leftHandSide, decimal rightHandSide) : this(new DecimalOperand(leftHandSide), new DecimalOperand(rightHandSide)) { }

        public override Operand Execute()
        {
            new Logging.UserLog(this.ToString());
            
            switch(this.LeftHandSide.Type)
            {
                case OperandType.Integer:
                    this.Result = executeLHSInteger();
                    break;
                case OperandType.Decimal:
                    this.Result = executeLHSDecimal();
                    break;
                case OperandType.DateTime:
                case OperandType.Boolean:
                default:
                    throw new ModuloException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
            return this.Result;
        }

        private Operand executeLHSDecimal()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    return new DecimalOperand(this.LeftHandSide.AsDecimal % this.RightHandSide.AsInteger);
                case OperandType.Decimal:
                    return new DecimalOperand(this.LeftHandSide.AsDecimal % this.RightHandSide.AsDecimal);
                case OperandType.DateTime:
                case OperandType.Boolean:
                default:
                    throw new ModuloException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }
        }

        private Operand executeLHSInteger()
        {
            switch (this.RightHandSide.Type)
            {
                case OperandType.Integer:
                    return new IntegerOperand(this.LeftHandSide.AsInteger % this.RightHandSide.AsInteger);
                case OperandType.Decimal:
                    return new DecimalOperand(this.LeftHandSide.AsInteger % this.RightHandSide.AsDecimal);
                case OperandType.DateTime:
                case OperandType.Boolean:
                default:
                    throw new ModuloException(this.LeftHandSide.Type, this.RightHandSide.Type);
            }

        }

        public override Priority Priority
        {
            get
            {
                return Priority.Modulo;
            }
        }
    }
}
