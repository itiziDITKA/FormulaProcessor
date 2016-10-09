using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Logging
{
    public abstract class Log
    {
        protected string Message { get; set; }
        protected Exception Exception { get; set; }
        public virtual string Output()
        {
            return this.Message;
        }
    
    }
}
