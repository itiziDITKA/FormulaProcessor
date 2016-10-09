using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Parts.Operators
{
    public enum Priority
    {
        Parentheses = 1,
        Multiplication = 2,
        Division = 2,
        Modulo = 2,
        Addition = 3,
        Subtraction = 3,
        Comparison = 4,
        Equality = 5,
        And = 6,
        Or = 7
    }
}
