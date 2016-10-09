using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaProcessor.Logging
{
    public static class LogQueue
    {
        private static Queue<Log> logQueue;
        private static string logPath;
        private static bool initialized = false;
        public static void Initialize(string logFilePath)
        {
            logQueue = new Queue<Log>();
            logPath = logFilePath;
            if (logQueue != null)
            {
                initialized = true;
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(logPath)))
                {
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(logPath));
                }
            }
            else
            {
                throw new LogException("Failed to initialized Log Queue");
            }
        }
        public static void Add(Log log)
        {
            if (log == null)
            {
                throw new LogException("Log cannot be null");
            }

            if (initialized)
            {
                logQueue.Enqueue(log);
            }
        }

        public static void Flush()
        {
            if (initialized)
            {
                StringBuilder logBuilder = new StringBuilder();
                while (logQueue.Count > 0)
                {
                    try
                    {
                        logBuilder.AppendLine(logQueue.Dequeue().Output() + "\n");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (logBuilder != null)
                {
                    File.AppendAllText(logPath, logBuilder.ToString()); //will create the file
                }
            }
        }
    }
}
