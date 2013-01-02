using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.DataObjects
{
    public class ValueItem
    {
        public string quantity { get; set; }

        public string payment { get; set; }

        public ValueItem(string payment, string quantity)
        {
            this.quantity = quantity;
            this.payment = payment;
        }
    }
}
