using FormulaProcessor.Parts.Operators.Binary.Addition;
using FormulaProcessor.Parts.Operators.Binary.Division;
using FormulaProcessor.Parts.Operators.Binary.Multiplication;
using FormulaProcessor.Parts.Operators.Binary.Subtraction;
using FormulaProcessor.Parts.Operators.Binary.Modulo;
using FormulaProcessor.Parts.Operators.Binary.Equal;
using FormulaProcessor.Parts.Operators.Binary.NotEqual;
using FormulaProcessor.Parts.Operators.Binary.LessThan;
using FormulaProcessor.Parts.Operators.Binary.LessThanOrEqual;
using FormulaProcessor.Parts.Operators.Binary.GreaterThan;
using FormulaProcessor.Parts.Operators.Binary.GreaterThanOrEqual;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operands
{
    public class Operand : Part
    {
        protected Operand(object value, OperandType type)
        {
            this.Value = value;
            this.Type = type;
        }

        public OperandType Type { get; protected set; }
        public object Value { get; protected set; }

        public long AsInteger { get { return Convert.ToInt64(this.Value); } }
        public decimal AsDecimal { get { return Convert.ToDecimal(this.Value); } }
        public bool AsBoolean { get { return Convert.ToBoolean(this.Value); } }
        public DateTime AsDateTime { get { return Convert.ToDateTime(this.Value); } }
        public string AsString { get { return Convert.ToString(this.Value); } }

        public override string ToString()
        {
            switch(this.Type)
            {
                case OperandType.Integer:
                    return "(Integer)" + this.AsInteger;
                case OperandType.Decimal:
                    return "(Decimal)" + this.AsDecimal;
                case OperandType.DateTime:
                    return "(Date Time)" + this.AsDateTime.ToString();
                case OperandType.Boolean:
                    return "(Boolean)" + this.AsBoolean.ToString();
            }
            return base.ToString();
        }

        public static Operand operator +(Operand lhs, Operand rhs)
        {
            return new Addition(lhs, rhs).Execute();
        }

        public static Operand operator -(Operand lhs, Operand rhs)
        {
            return new Subtraction(lhs, rhs).Execute();
        }

        public static Operand operator *(Operand lhs, Operand rhs)
        {
            return new Multiplication(lhs, rhs).Execute();
        }

        public static Operand operator /(Operand lhs, Operand rhs)
        {
            return new Division(lhs, rhs).Execute();
        }

        public static Operand operator %(Operand lhs, Operand rhs)
        {
            return new Modulo(lhs, rhs).Execute();
        }

        public static Operand operator==(Operand lhs, Operand rhs)
        {
            return new Equal(lhs, rhs).Execute();
        }

        public static Operand operator !=(Operand lhs, Operand rhs)
        {
            return new NotEqual(lhs, rhs).Execute();
        }

        public static Operand operator >(Operand lhs, Operand rhs)
        {
            return new GreaterThan(lhs, rhs).Execute();
        }

        public static Operand operator >=(Operand lhs, Operand rhs)
        {
            return new GreaterThanOrEqual(lhs, rhs).Execute();
        }

        public static Operand operator <(Operand lhs, Operand rhs)
        {
            return new LessThan(lhs, rhs).Execute();
        }

        public static Operand operator <=(Operand lhs, Operand rhs)
        {
            return new LessThanOrEqual(lhs, rhs).Execute();
        }

    }
}
