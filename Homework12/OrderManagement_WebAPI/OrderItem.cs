using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement_WebAPI
{
    [Serializable]
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public string productName { get; set; }
        public int productPrice { get; set; }
        public int productNum { get; set; }
        public int OrderId { get; set; }
    }
}
