﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operands
{
    public class StringOperand : Operand
    {
        public StringOperand(string value) : base(value, OperandType.String) { }
    }
}
