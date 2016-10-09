using System;
using System.Runtime.Serialization;
using FormulaProcessor.Parts.Operands;

namespace FormulaProcessor.Parts.Operators.Binary.Modulo
{
    [Serializable]
    internal class ModuloException : Exception
    {
        private OperandType type1;
        private OperandType type2;

        public ModuloException()
        {
        }

        public ModuloException(string message) : base(message)
        {
        }

        public ModuloException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ModuloException(OperandType type1, OperandType type2)
        {
            this.type1 = type1;
            this.type2 = type2;
        }

        protected ModuloException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}