using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OrderManagement.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        // AddOrder() 测试：
        // 准备输入一个完整的订单，若orders包含输入的订单，则成功
        [TestMethod()]
        public void AddOrderTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            if (!orderService.orders.Contains(order))
            {
                Assert.Fail();
            }
        }

        // AddOrder() 测试：
        // 准备输入空订单，抛出ArgumentException异常
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddOrderTest1()
        {
            OrderService orderService = new OrderService();
            Order order = new Order();
            orderService.AddOrder(order);
        }

        // AddOrder() 测试：
        // 准备输入null，抛出ArgumentException异常
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddOrderTest2()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(null);
        }

        // RemoveOrder() 测试：
        // 准备输入一个完整的订单，若orders不包含输入的订单，则成功
        [TestMethod()]
        public void RemoveOrderTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            orderService.RemoveOrder(order);
            if (orderService.orders.Contains(order))
            {
                Assert.Fail();
            }
        }

        // RemoveOrder() 测试：
        // 准备输入空订单，抛出ArgumentException异常
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveOrderTest1()
        {
            OrderService orderService = new OrderService();
            Order order = new Order();
            orderService.RemoveOrder(order);
        }

        // RemoveOrder() 测试：
        // 准备输入null，抛出ArgumentException异常
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveOrderTest2()
        {
            OrderService orderService = new OrderService();
            orderService.RemoveOrder(null);
        }

        // ModifyOrder() 测试：
        // 某个订单的状态false改true，如果该订单状态为true，则成功
        [TestMethod()]
        public void ModifyOrderTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            orderService.ModifyOrder(order, true);
            if (!order.isProcessed)
            {
                Assert.Fail();
            }
        }

        // ModifyOrder() 测试：
        // 某个订单的状态true改false，如果该订单状态为false，则成功
        [TestMethod()]
        public void ModifyOrderTest1()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            orderService.ModifyOrder(order, true);
            orderService.ModifyOrder(order, false);
            if (order.isProcessed)
            {
                Assert.Fail();
            }
        }

        // QueryOrderByOther() 测试：
        // situation = 2，按货物名找，分成找得到，找不到两种情况
        [TestMethod()]
        public void QueryOrderByOtherTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem("Cargo_6", 12, 8));
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            List<Order> orders = orderService.QueryOrderByOther(2, "Cargo_6") as List<Order>;
            if (orders.Count != 1)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void QueryOrderByOtherTest1()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem("Cargo_6", 12, 8));
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            List<Order> orders = orderService.QueryOrderByOther(2, "Cargo_5") as List<Order>;
            if (orders.Count != 0)
            {
                Assert.Fail();
            }
        }

        // QueryOrderByOther() 测试：
        // situation = 3，按客户名找，分成找得到，找不到两种情况
        [TestMethod()]
        public void QueryOrderByOtherTest2()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem("Cargo_6", 12, 8));
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            List<Order> orders = orderService.QueryOrderByOther(3, "Sam") as List<Order>;
            if (orders.Count != 1)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void QueryOrderByOtherTest3()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem("Cargo_6", 12, 8));
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            List<Order> orders = orderService.QueryOrderByOther(3, "Amy") as List<Order>;
            if (orders.Count != 0)
            {
                Assert.Fail();
            }
        }

        // QueryOrderByOther() 测试：
        // situation > 3，抛出ArgumentException异常
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void QueryOrderByOtherTest4()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem("Cargo_6", 12, 8));
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            List<Order> orders = orderService.QueryOrderByOther(4, "Amy") as List<Order>;
        }

        // QueryOrderByID() 测试：
        // 给定参数ID = 1，若找得到订单，则成功
        [TestMethod()]
        public void QueryOrderByIDTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem("Cargo_6", 12, 8));
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            Order newOrder = orderService.QueryOrderByID(1);
            if (newOrder == null)
            {
                Assert.Fail();
            }
        }

        // QueryOrderByID() 测试：
        // 给定参数ID = 2，若找不到订单，则成功
        [TestMethod()]
        public void QueryOrderByIDTest1()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem("Cargo_6", 12, 8));
            Order order = new Order(1, orderItems, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order);
            Order newOrder = orderService.QueryOrderByID(2);
            if (newOrder != null)
            {
                Assert.Fail();
            }
        }

        // SortOrders() 测试：
        // situation = 1，按照订单号排序，若排序结果正确，则成功
        [TestMethod()]
        public void SortOrdersTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems_1 = new List<OrderItem>();
            orderItems_1.Add(new OrderItem("Cargo_6", 12, 8));
            Order order_1 = new Order(2, orderItems_1, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order_1);
            List<OrderItem> orderItems_2 = new List<OrderItem>();
            orderItems_2.Add(new OrderItem("Cargo_6", 12, 8));
            Order order_2 = new Order(1, orderItems_2, "Amy", "Home", DateTime.Now);
            orderService.AddOrder(order_2);
            orderService.SortOrders(orderService.orders, 1);
            List<Order> orders = new List<Order>();
            orders.Add(order_2);
            orders.Add(order_1);
            if (orders.Count != orderService.orders.Count)
            {
                Assert.Fail();
            }
            for (int i = 0; i < 2; i++)
            {
                if (!orders[i].Equals(orderService.orders[i]))
                {
                    Assert.Fail();
                }
            }
        }

        // SortOrders() 测试：
        // situation = 2，排序，按照订单发起时间排序，若排序结果正确，则成功
        [TestMethod()]
        public void SortOrdersTest1()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems_1 = new List<OrderItem>();
            orderItems_1.Add(new OrderItem("Cargo_6", 12, 8));
            Order order_1 = new Order(2, orderItems_1, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order_1);
            List<OrderItem> orderItems_2 = new List<OrderItem>();
            orderItems_2.Add(new OrderItem("Cargo_6", 12, 8));
            Order order_2 = new Order(1, orderItems_2, "Amy", "Home", DateTime.Now);
            orderService.AddOrder(order_2);
            orderService.SortOrders(orderService.orders, 2, false);
            List<Order> orders = new List<Order>();
            orders.Add(order_2);
            orders.Add(order_1);
            for (int i = 0; i < 2; i++)
            {
                if (!orders[i].Equals(orderService.orders[i]))
                {
                    Assert.Fail();
                }
            }
        }

        // SortOrders() 测试：
        // situation <= 0 或 >= 3，按照订单总金额排序，若排序结果正确，则成功
        [TestMethod()]
        public void SortOrdersTest2()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems_1 = new List<OrderItem>();
            orderItems_1.Add(new OrderItem("Cargo_6", 12, 8));
            Order order_1 = new Order(2, orderItems_1, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order_1);
            List<OrderItem> orderItems_2 = new List<OrderItem>();
            orderItems_2.Add(new OrderItem("Cargo_4", 8, 9));
            Order order_2 = new Order(1, orderItems_2, "Amy", "Home", DateTime.Now);
            orderService.AddOrder(order_2);
            orderService.SortOrders(orderService.orders, 3);
            List<Order> orders = new List<Order>();
            orders.Add(order_2);
            orders.Add(order_1);
            for (int i = 0; i < 2; i++)
            {
                if (!orders[i].Equals(orderService.orders[i]))
                {
                    Assert.Fail();
                }
            }
        }

        // SortOrders() 测试：
        // orders为空，无法排序，抛出ArgumentException异常
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SortOrdersTest3()
        {
            OrderService orderService = new OrderService();
            orderService.SortOrders(orderService.orders, 1);
        }

        // ExportOrders() 测试：
        // Path存在时，若输出的XML文件内容符合预期，则成功
        [TestMethod()]
        public void ExportOrdersTest()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems_1 = new List<OrderItem>();
            DateTime time = new DateTime(2020, 3, 23, 17, 45, 36);
            Order order_1 = new Order(2, orderItems_1, "Sam", "Home", time);
            orderService.AddOrder(order_1);
            orderService.ExportOrders("F:\\", "orderInformation");
            string[] actualContent = File.ReadAllLines("F:\\orderInformation.xml", Encoding.UTF8);
            string[] expectedContent =
            {
                "<?xml version=\"1.0\"?>",
                "<ArrayOfOrder xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">",
                "  <Order>",
                "    <orderID>2</orderID>",
                "    <orderItems />",
                "    <cost>0</cost>",
                "    <isProcessed>false</isProcessed>",
                "    <clientName>Sam</clientName>",
                "    <clientAddress>Home</clientAddress>",
                "    <orderTime>2020-03-23T17:45:36</orderTime>",
                "  </Order>",
                "</ArrayOfOrder>"
            };
            if (actualContent.Length != expectedContent.Length)
            {
                Assert.Fail();
            }
            for (int i = 0; i < actualContent.Length; i++)
            {
                if (expectedContent[i] != actualContent[i])
                {
                    Assert.Fail();
                }
            }
        }

        // ExportOrders() 测试：
        // Path不存在时，抛出ArgumentException异常
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ExportOrdersTest1()
        {
            OrderService orderService = new OrderService();
            List<OrderItem> orderItems_1 = new List<OrderItem>();
            orderItems_1.Add(new OrderItem("Cargo_6", 12, 8));
            Order order_1 = new Order(2, orderItems_1, "Sam", "Home", DateTime.Now);
            orderService.AddOrder(order_1);
            orderService.ExportOrders("F:\\NonexistentPath", "orderInformation");
        }

        // ImportOrders() 测试计划：
        // 要导入的文件存在时，若导入的订单信息与原始订单信息一致，则成功
        [TestMethod()]
        public void ImportOrdersTest()
        {
            OrderService orderService = new OrderService();
            orderService.ImportOrders("F:\\", "orderInformation");
            List<OrderItem> orderItems_1 = new List<OrderItem>();
            DateTime time = new DateTime(2020, 3, 23, 17, 45, 36);
            Order order_1 = new Order(2, orderItems_1, "Sam", "Home", time);
            if ((orderService.orders == null) || (!orderService.orders[0].Equals(order_1)))   
            {
                Assert.Fail();
            }
        }

        // ImportOrders() 测试：
        // 要导入的文件不存在时，抛出ArgumentException异常
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ImportOrdersTest1()
        {
            OrderService orderService = new OrderService();
            orderService.ExportOrders("F:\\NonexistentPath", "orderInformation");
        }
    }
}