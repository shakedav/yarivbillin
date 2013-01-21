using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace Billing
{
    public class LogWriter
    {
        private static Logger logger;
        private static volatile LogWriter instance;
        private static object locker = new Object();

        public static LogWriter Instance
        {
            get
            {
                // Check if the instance has not been created yet
                if (instance == null)
                {
                    // Enter a locking state
                    lock (locker)
                    {
                        // Ensure that the instance is still not valid
                        if (instance == null)
                        {
                            // Create the instace
                            instance = new LogWriter();
                        }
                    }
                }

                // Return the single instance
                return instance;
            }
        }
        
        LogWriter()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public void Trace(string message)
        {            
            logger.Trace(message);
        }

        public void Error(string message, Exception ex)
        {            
            logger.ErrorException(message,ex);
        }
    }
}
