using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement_WinForm
{
    [Serializable]
    public class Order
    {
        public int orderID { get; set; } // ID
        public List<OrderItem> orderItems { get; set; } // 订单明细项
        public int cost { get; set; } // 订单总金额
        public bool isProcessed { get; set; } // 订单状态，是否已处理
        public string clientName { get; set; } // 客户名
        public string clientAddress { get; set; } // 送货地址
        public DateTime orderTime { get; set; } // 订单发起时间
        public Order()
        {
        }
        public Order(int orderID, List<OrderItem> orderItems, string clientName, string clientAddress, DateTime orderTime, bool isProcessed = false)
        {
            this.orderID = orderID;
            this.orderItems = orderItems;
            this.isProcessed = isProcessed;
            this.clientName = clientName;
            this.clientAddress = clientAddress;
            this.orderTime = orderTime;
            cost = 0;
            foreach (var v in orderItems)
            {
                cost += v.productPrice * v.productNum;
            }
        }

        public override string ToString()
        {
            return orderID.ToString() + '\t' + clientName + '\t' + clientAddress + '\t' + orderTime.ToString() + '\t' + cost.ToString() + '\t' + isProcessed.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   orderID == order.orderID &&
                   cost == order.cost &&
                   isProcessed == order.isProcessed &&
                   clientName == order.clientName &&
                   clientAddress == order.clientAddress &&
                   orderTime == order.orderTime;
        }
    }
}
