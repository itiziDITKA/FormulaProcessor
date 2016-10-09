using System;
using System.Runtime.Serialization;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Binary.GreaterThan
{
    [Serializable]
    internal class GreaterThanException : Exception
    {
        private OperandType type1;
        private OperandType type2;

        public GreaterThanException()
        {
        }

        public GreaterThanException(string message) : base(message)
        {
        }

        public GreaterThanException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GreaterThanException(OperandType type1, OperandType type2)
        {
            this.type1 = type1;
            this.type2 = type2;
        }

        protected GreaterThanException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}