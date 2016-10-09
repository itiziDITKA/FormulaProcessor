using System;
using System.Runtime.Serialization;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Binary.GreaterThanOrEqual
{
    [Serializable]
    internal class GreaterThanOrEqualException : Exception
    {
        private OperandType type1;
        private OperandType type2;

        public GreaterThanOrEqualException()
        {
        }

        public GreaterThanOrEqualException(string message) : base(message)
        {
        }

        public GreaterThanOrEqualException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GreaterThanOrEqualException(OperandType type1, OperandType type2)
        {
            this.type1 = type1;
            this.type2 = type2;
        }

        protected GreaterThanOrEqualException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}