using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement_WebAPI
{
    [Serializable]
    public class Order
    {
        public int Id { get; set; } // ID
        public List<OrderItem> orderItems { get; set; } // 订单明细项
        public int cost { get; set; } // 订单总金额
        public bool isProcessed { get; set; } // 订单状态，是否已处理
        public string clientName { get; set; } // 客户名
        public string clientAddress { get; set; } // 送货地址
        public DateTime orderTime { get; set; } // 订单发起时间
    }
}
