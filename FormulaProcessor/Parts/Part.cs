using FormulaProcessor.Logging;
using FormulaProcessor.Parts.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts
{
    public abstract class Part
    {
        public string Name { get; set; }

        public virtual Operand Execute()
        {
            throw new PartException("Part not implemented.");
        }
    }
}
