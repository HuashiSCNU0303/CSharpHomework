using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace OrderManagement_WinForm
{
    class OrderService
    {
        public List<Order> orders { get; set; }
        XmlSerializer xmlSerializer { get; }
        
        public OrderService()
        {
            xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (var context = new OrderContext())
            {
                orders = context.Orders.ToList();
                if (orders.Count > 0)
                {
                    foreach (var order in orders)
                    {
                        order.orderItems = context.OrderItems.Where(p => p.OrderId == order.orderID).ToList();
                    }
                }
            }
        }
       
        public void addOrder(Order order) // 添加订单
        {
            orders.Add(order);
            using (var context = new OrderContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
        
        public void removeOrder(int index) // 删除订单
        {
            using (var context = new OrderContext())
            {
                context.Orders.Attach(orders[index]);
                context.Orders.Remove(orders[index]);
                context.SaveChanges();
            }
            orders.RemoveAt(index);
        }
        
        public IEnumerable<Order> queryOrder(string field, string keyword) // 查询订单
        {
            List<Order> selectedOrders = null;
            switch (field)
            {
                case "订单号":
                    {
                        int keyword_int = 0;
                        try
                        {
                            keyword_int = Convert.ToInt32(keyword);
                        }
                        catch (FormatException)
                        {
                            break;
                        }
                        using (var context = new OrderContext())
                        {
                            selectedOrders = context.Orders.Where(p => p.orderID == keyword_int).ToList();
                            foreach(var order in selectedOrders)
                            {
                                order.orderItems = context.OrderItems.Where(p => p.OrderId == order.orderID).ToList();
                            }
                        }
                    }
                    break;
                case "产品名":
                    {
                        using (var context = new OrderContext())
                        {
                            selectedOrders = context.Orders.Where(x => x.orderItems.Any(y => y.productName == keyword)).ToList();
                            foreach (var order in selectedOrders)
                            {
                                order.orderItems = context.OrderItems.Where(p => p.OrderId == order.orderID).ToList();
                            }
                        }
                    }
                    break;
                case "客户名":
                    {
                        using (var context = new OrderContext())
                        {
                            selectedOrders = context.Orders.Where(p => p.clientName == keyword).ToList();
                            foreach (var order in selectedOrders)
                            {
                                order.orderItems = context.OrderItems.Where(p => p.OrderId == order.orderID).ToList();
                            }
                        }
                    }
                    break;
            }
            return selectedOrders;
        }

        public void exportOrders(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, orders);
            }
        }

        public void importOrders(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                orders = xmlSerializer.Deserialize(fileStream) as List<Order>;
            }
            // 更新数据库
            updateDatabase();
        }

        public void updateDatabase()
        {
            using (var context = new OrderContext())
            {
                // 删除旧记录
                context.Orders.RemoveRange(context.Orders);
                context.OrderItems.RemoveRange(context.OrderItems);
                context.SaveChangesAsync();

                // 添加新记录
                context.Orders.AddRange(orders);
                foreach (var order in orders)
                {
                    context.OrderItems.AddRange(order.orderItems);
                }
                context.SaveChangesAsync();
            }
        }
    }
}
