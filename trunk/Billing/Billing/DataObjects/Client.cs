using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.DataObjects
{
    public class Client : ICloneable
    {
        public int ClientCode { get; set; }
        public int Type { get; set; }
        public string ClientName { get; set; }
        public string Address{ get; set; }
        public string ClientPhone { get; set; }
        public string ClientMail { get; set; }

        public Client()
        { 
        }

        public Client(int clientType)
        {
            ClientCode = ClientTypes.Instance.ClientTypesList[clientType].Code;

            //ExcelHelper.Instance.GetMaxIDOfType(ExcelHelper.Instance.Clients, ColumnNames.CLIENT_CODE,clientType.ToString(), ColumnNames.CLIENT_TYPE);
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
