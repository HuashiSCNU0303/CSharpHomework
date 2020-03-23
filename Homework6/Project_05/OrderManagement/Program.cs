using System;
using System.Collections.Generic;

namespace OrderManagement
{
    class Program
    {
        static Dictionary<int, Cargo> productInfo = new Dictionary<int, Cargo>();
        static OrderService orderService = new OrderService();
        static void Main(string[] args)
        {
            SetProducts();
            while (true)
            {
                Console.WriteLine("——————————订单管理系统——————————");
                Console.WriteLine("1.输出当前所有订单");
                Console.WriteLine("2.添加订单");
                Console.WriteLine("3.删除订单");
                Console.WriteLine("4.查询订单");
                Console.WriteLine("5.修改订单");
                Console.WriteLine("6.对当前所有订单进行排序");
                Console.WriteLine("7.保存当前订单信息");
                Console.WriteLine("8.导入保存的订单信息");
                Console.Write("请输入：");
                int selection = 0;
                ExamineInput(1, 8, ref selection);
                switch (selection)
                {
                    case 1: orderService.OutputAllOrders(); break;
                    case 2: AddOrder(); break;
                    case 3: RemoveOrder(); break;
                    case 4: QueryOrder(); break;
                    case 5: ModifyOrder(); break;
                    case 6: SortOrders(orderService.orders); break;
                    case 7: ExportOrders(); break;
                    case 8: ImportOrders(); break;
                }

                Console.Write("退出系统吗？需要退出请输入Exit，否则可输入任意字符：");
                if (Console.ReadLine() == "Exit") 
                {
                    break;
                }
                Console.WriteLine("——————————————————————————");
                Console.WriteLine();
            }
            
        }
        static void SetProducts()
        {
            productInfo[1] = new Cargo("Cargo_1", 5);
            productInfo[2] = new Cargo("Cargo_2", 60);
            productInfo[3] = new Cargo("Cargo_3", 12);
            productInfo[4] = new Cargo("Cargo_4", 7);
            productInfo[5] = new Cargo("Cargo_5", 2);
        }
        static void AddOrder()
        {
            Console.WriteLine("———————添加订单———————");
            Console.Write("请输入订单编号：");
            int orderID = Convert.ToInt32(Console.ReadLine());
            Console.Write("请输入客户名：");
            string clientName = Console.ReadLine();
            Console.Write("请输入送货地址：");
            string clientAddress = Console.ReadLine();
            List<OrderItem> orderItems = new List<OrderItem>();
            Console.WriteLine("请按照“订单货物种类 每种货物的数量”的格式输入该订单的货物信息，输入Stop结束。");
            while (true) 
            {
                try
                {
                    Console.Write("请输入订单货物种类与数量：");
                    string input = Console.ReadLine();
                    string[] cargoInfo;
                    if (input == "Stop")
                    {
                        break;
                    }
                    cargoInfo = input.Split(' ');
                    int cargoIndex = Convert.ToInt32(cargoInfo[0]);
                    int cargoNum = Convert.ToInt32(cargoInfo[1]);
                    orderItems.Add(new OrderItem(productInfo[cargoIndex].cargoName, productInfo[cargoIndex].cargoPrice, cargoNum));
                }
                catch(KeyNotFoundException)
                {
                    Console.WriteLine("没有这种货物！请输入其他种类的货物信息！");
                }
                catch(Exception)
                {
                    Console.WriteLine("这种货物信息输入错误！请重新输入！");
                }
                
            }
            orderService.AddOrder(new Order(orderID, orderItems, clientName, clientAddress, DateTime.Now));
            Console.WriteLine("——————添加订单成功——————");
            orderService.OutputAllOrders();
        }
        static void RemoveOrder() // 仅提供按照订单号删除的功能
        {
            Order order;
            Console.WriteLine("———————删除订单———————");
            Console.Write("请输入需删除订单的订单号："); // 订单号唯一
            string input = Console.ReadLine();
            int orderID = Convert.ToInt32(input);
            order = orderService.QueryOrderByID(orderID);
            if (order == null) // 找不到
            {
                Console.WriteLine("没有找到该订单，无法删除！");
                Console.WriteLine("——————删除订单失败——————");
                return;
            }
            orderService.RemoveOrder(order);
            Console.WriteLine("——————删除订单成功——————");
            orderService.OutputAllOrders();
        }
        static void ModifyOrder() // 仅提供按照订单号修改该订单状态的功能
        {
            Order order;
            Console.WriteLine("———————修改订单———————");
            Console.Write("请输入需修改订单的订单号："); // 订单号唯一
            string input = Console.ReadLine();
            int orderID = Convert.ToInt32(input);
            order = orderService.QueryOrderByID(orderID);
            if (order == null) // 找不到
            {
                Console.WriteLine("没有找到该订单，无法修改！");
                Console.WriteLine("——————修改订单失败——————");
                return;
            }
            Console.Write("订单是否已处理？(Y/N)：");
            input = Console.ReadLine();
            if(input == "Y")
            {
                orderService.ModifyOrder(order, true);
            }
            else if(input == "N")
            {
                orderService.ModifyOrder(order, false);
            }
            Console.WriteLine("——————修改订单成功——————");
            orderService.OutputAllOrders();
        }
        static IEnumerable<Order> QueryOrder()
        {
            List<Order> orders = null;
            Console.WriteLine("———————查询订单———————");
            Console.WriteLine("1.按照订单号查询");
            Console.WriteLine("2.按照货物名查询");
            Console.WriteLine("3.按照客户名查询");
            Console.Write("请输入：");
            int selection = 0;
            ExamineInput(1, 3, ref selection);
            switch (selection)
            {
                case 1:// 订单号
                    {
                        Console.Write("请输入订单号：");
                        string input = Console.ReadLine();
                        Order order = orderService.QueryOrderByID(Convert.ToInt32(input));
                        orders.Add(order);
                        break;
                    }
                      
                case 2:// 货物名
                    {
                        Console.Write("请输入货物名：");
                        string input = Console.ReadLine();
                        orders = orderService.QueryOrderByOther(2, input) as List<Order>;
                        break;
                    }
                case 3:// 客户名
                    {
                        Console.Write("请输入客户名：");
                        string input = Console.ReadLine();
                        orders = orderService.QueryOrderByOther(3, input) as List<Order>;
                        break;
                    }
            }
            SortOrders(orders);
            orderService.OutputOrders(orders);
            return orders;
        }
        static void SortOrders(List<Order> orders)
        {
            Console.WriteLine("———————对订单排序———————");
            Console.WriteLine("1.按照订单号排序");
            Console.WriteLine("2.按照添加时间排序");
            Console.WriteLine("3.按照订单总金额排序");
            Console.Write("请输入：");
            int selection = 0;
            ExamineInput(1, 3, ref selection);
            Console.Write("是否升序？(Y/N)：");
            string input = Console.ReadLine();
            if (input == "Y")
            {
                orderService.SortOrders(orders, selection, true);
            }
            else if (input == "N") 
            {
                orderService.SortOrders(orders, selection, false);
            }
            Console.WriteLine("———————排序已完成———————");
        }
        static void ExamineInput(int begin, int end, ref int result)
        {
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    result = Convert.ToInt32(input);
                    if (!(result >= begin && result <= end)) 
                    {
                        Console.Write("请输入" + begin + "~" + end + "内的整数！请重新输入：");
                        continue;
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.Write("请输入整数！请重新输入：");
                }
            }
        }
        static void ExportOrders()
        {
            Console.Write("请输入订单信息文件保存路径：");
            string path = Console.ReadLine();
            Console.Write("请输入文件名：");
            string name = Console.ReadLine();
            orderService.ExportOrders(path, name);
        }
        static void ImportOrders()
        {
            Console.Write("请输入订单信息文件保存路径：");
            string path = Console.ReadLine();
            Console.Write("请输入文件名：");
            string name = Console.ReadLine();
            orderService.ImportOrders(path, name);
        }
    }
}
