using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallingDB
{
    public class OrderInfo
    {
        public string OrderString { get; private set; }
        public int LeftNumCount { get; private set; }

        public OrderInfo(string orderstring, int leftnumcount)
        {
            this.OrderString = orderstring;
            this.LeftNumCount = leftnumcount;
        }

        public override string ToString()
        {
            return string.Format("OrderString:{0} LeftNumCount:{1}", OrderString, LeftNumCount);
        }
    }
}
