using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.DataObjects
{
    public class Contract
    {
        public int ClientCode { get; set; }
        public int ProjectCode { get; set; }
        public int ContractCodeYariv { get; set; }
        public int ContractCodeClient { get; set; }
        public int Value { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractSigningDate { get; set; }
        public DateTime ContractEndTime { get; set; }
        public int ContractType { get; set; }
        public string ValueCalculation { get; set; }
        public string ValueCalculationWay { get; set; }
        public string ContractUsage { get; set; }
        public string[] ValueTypes { get; set; }

        public Contract()
        {
        }

        public Contract(int contractCodeYariv, int ContractCodeClient)
        {
            ContractCodeYariv = contractCodeYariv;
            ContractCodeClient = contractCodeYariv;
        }
    }
}
