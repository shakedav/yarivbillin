using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Billing.DataObjects
{
    public class ClientType
    {
        public int Code{get;set;}
        public string Type{ get; set; }

        public ClientType(int code, string type)
        {
            // TODO: Complete member initialization
            this.Code = code;
            this.Type = type;
        }
    }

    public sealed class ClientTypes
    {
        public List<ClientType> ClientTypesList;
        private static object locker = new Object();
        private static volatile ClientTypes instance;
        /// <summary>
        /// Get an instance of the ExcelHelper (create on the first time).
        /// </summary>
        public static ClientTypes Instance
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
                            instance = new ClientTypes();
                        }
                    }
                }

                // Return the single instance
                return instance;
            }
        }

        ClientTypes()
        {
            ClientTypesList = new List<ClientType>();
            foreach (DataRow row in ExcelHelper.Instance.ClientTypes.Rows)
            {
                ClientType clientType = new ClientType(int.Parse(row[0].ToString()), row[1].ToString());
                ClientTypesList.Add(clientType);
            }
        }
    }
}
