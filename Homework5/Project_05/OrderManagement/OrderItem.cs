using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement
{
    class OrderItem
    {
        public string productName { get; }
        public int productPrice { get; }
        public int productNum { get; }
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

        public override int GetHashCode()
        {
            return HashCode.Combine(productName, productPrice, productNum);
        }
    }
}
