using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement_WinForm
{
    [Serializable]
    public class OrderItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderItemID { get; set; }
        public string productName { get; set; }
        public int productPrice { get; set; }
        public int productNum { get; set; }
        public int OrderId { get; set; } 
        // public Order Order { get; set; }
        public OrderItem()
        {
        }
        public OrderItem(string productName, int productPrice, int productNum)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            this.productNum = productNum;
        }

        public override string ToString()
        {
            return productName + '\t' + productPrice.ToString() + '\t' + productNum.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItem item &&
                   productName == item.productName &&
                   productPrice == item.productPrice &&
                   productNum == item.productNum;
        }
    }
}
