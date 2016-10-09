using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Logging
{
    public class UserLog : Log
    {
        public UserLog()
        {

        }

        public UserLog(string message)
        {
            this.Message = message;
            LogQueue.Add(this);
        }

        public UserLog(Exception ex)
        {
            this.Exception = ex;
            LogQueue.Add(this);
        }

        public UserLog(string message, Exception ex)
        {
            this.Message = message;
            this.Exception = ex;
            LogQueue.Add(this);
        }

        public override string Output()
        {
            StringBuilder messageBuilder = new StringBuilder("(" +DateTime.Today.ToString() + ")");
            if(this.Message.Length > 0)
            {
                messageBuilder.AppendLine(" Message: " + this.Message);
            }
            if(this.Exception != null && this.Exception.Message.Length > 0)
            {
                messageBuilder.AppendLine(" Exception Message:" + this.Exception.Message);
            }

            return messageBuilder.ToString();
        }

    }
}
