using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public sealed class Constants
    {
        private static volatile Constants instance;
        private static object locker = new Object();

        public double MAAM
        {
            get
            {
                return double.Parse(System.Configuration.ConfigurationManager.AppSettings["maam"]);
            }
        }

        public String Path
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["excelFilePath"];
            }
        }

        public static Constants Instance
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
                            instance = new Constants();
                        }
                    }
                }

                // Return the single instance
                return instance;
            }
        }      
    }
}
