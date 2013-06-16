using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.DataObjects
{
    public class ValueItem
    {
        public ValueItem(string type, string index)
        {
            this.ValueType = type;
            this.ValueIndex = index;
            this.Quantity = string.Empty;
            this.Payment = string.Empty;
        }

        public ValueItem(string code, string index, string payment, string quantity)
        {   
            this.ValueIndex = index;
            this.Quantity = quantity;
            this.Payment = payment;
            this.ValueCode = code;
        }
        public string ValueType { get; set; }
        public string ValueCode { get; set; }
        public string ValueIndex { get; set; }
        public string Payment { get; set; }
        public string Quantity { get; set; }

    }
}
