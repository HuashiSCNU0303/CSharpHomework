using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement
{
    class Order
    {
        public int orderID { get; } // ID
        public List<OrderItem> orderItems { get; } // 订单明细项
        public int cost { get; } // 订单总金额
        public bool isProcessed { get; set; } // 订单状态，是否已处理
        public string clientName { get; } // 客户名
        public string clientAddress { get; } // 送货地址
        public DateTime orderTime { get; } // 订单发起时间
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
                   EqualityComparer<List<OrderItem>>.Default.Equals(orderItems, order.orderItems) &&
                   cost == order.cost &&
                   isProcessed == order.isProcessed &&
                   clientName == order.clientName &&
                   clientAddress == order.clientAddress &&
                   orderTime == order.orderTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(orderID, orderItems, cost, isProcessed, clientName, clientAddress, orderTime);
        }
    }
}
