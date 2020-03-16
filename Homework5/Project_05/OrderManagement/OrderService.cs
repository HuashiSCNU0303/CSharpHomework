using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement
{
    class OrderService
    {
        List<Order> orders { get; }
        public OrderService()
        {
            orders = new List<Order>();
        }
        public void AddOrder(Order order) // 添加订单
        {
            if (!orders.Contains(order)) 
            {
                orders.Add(order);
            }
        }
        public void RemoveOrder(Order order) // 删除订单
        {
            if (orders.Contains(order))
            {
                orders.Remove(order);
            }
        }
        public void ModifyOrder(Order order, bool status) // 修改订单状态（已处理/未处理）
        {
            order.isProcessed = status;
        }
        public IEnumerable<Order> QueryOrderByOther(int situation, string param) // 通过货物名或客户名查询订单
        {
            List<Order> selectedOrders = null;
            switch(situation)
            {
                case 2: // 货物名
                    {
                        var Orders = orders.Where(x => x.orderItems.Any(y => y.productName == param));
                        selectedOrders = Orders.ToList();
                        break;
                    }
                case 3: // 客户名
                    {
                        var Orders = from order_ in orders
                                     where order_.clientName == param
                                     select order_;
                        selectedOrders = Orders.ToList();
                        break;
                    }        
            }
            return selectedOrders;
        }
        public Order QueryOrderByID(int orderID) // 通过订单号查询订单
        {
            List<Order> selectedOrders = null;
            var Orders = from order_ in orders
                         where order_.orderID == orderID
                         select order_;
            selectedOrders = Orders.ToList();
            return selectedOrders.Count == 0 ? null : selectedOrders[0];
        }
        public void SortOrders(int situation, bool isAscending) // 对订单按照订单号/订单时间/订单金额进行排序
        {
            switch(situation)
            {
                case 1: // 订单号
                    {
                        orders.Sort((p1, p2) => p1.orderID - p2.orderID);
                        if (!isAscending) 
                        {
                            orders.Reverse();
                        }
                        break;
                    }
                case 2: // 订单时间
                    {
                        orders.Sort((p1, p2) => 
                        { if (p1.orderTime > p2.orderTime) 
                                return 1; 
                            else 
                                return -1; 
                        });
                        if (!isAscending)
                        {
                            orders.Reverse();
                        }
                        break;
                    }
                default: // 订单金额
                    {
                        orders.Sort((p1, p2) => p1.cost - p2.cost);
                        if (!isAscending)
                        {
                            orders.Reverse();
                        }
                        break;
                    }
            }
        }
        public void OutputOrders(List<Order> orders) // 输出订单数据
        {
            Console.WriteLine("——————查询订单结果——————");
            foreach (var order in orders)
            {
                Console.WriteLine("订单号\t客户名\t地址\t添加时间\t订单总金额\t订单是否处理");
                Console.WriteLine(order);
                Console.WriteLine("该订单明细信息如下：");
                Console.WriteLine("商品名\t商品单价\t商品数量");
                foreach (var item in order.orderItems)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            Console.WriteLine("——————————————————");
        }
        public void OutputAllOrders()
        {
            Console.WriteLine("——————当前所有订单——————");
            foreach (var order in orders)
            {
                Console.WriteLine("订单号\t客户名\t地址\t添加时间\t订单总金额\t订单是否处理");
                Console.WriteLine(order);
                Console.WriteLine("该订单明细信息如下：");
                Console.WriteLine("商品名\t商品单价\t商品数量");
                foreach(var item in order.orderItems)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
            Console.WriteLine("——————————————————");
        }
    }
}
