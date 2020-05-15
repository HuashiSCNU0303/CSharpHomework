using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement_WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDb;
        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }

        // 按照ID查询
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            order.orderItems = orderDb.OrderItems.Where(p => p.OrderId == order.Id).ToList();
            return order;
        }

        // 按照订单ID/产品名/客户名进行查询
        [HttpGet("query")]
        public ActionResult<List<Order>> GetOrders(int? id, string productName, string clientName)
        {
            var query = buildQuery(id, productName, clientName);
            var result = query.ToList();
            foreach (var order in result)
            {
                order.orderItems = orderDb.OrderItems.Where(p => p.OrderId == order.Id).ToList();
            }
            return result;
        }

        private IQueryable<Order> buildQuery(int? id, string productName, string clientName)
        {
            IQueryable<Order> query = orderDb.Orders;
            if (id != null)
            {
                query = query.Where(t => t.Id == id);
            }
            if (productName != null)
            {
                query = query.Where(x => x.orderItems.Any(y => y.productName == productName));
            }
            if (clientName != null)
            {
                query = query.Where(t => t.clientName == clientName);
            }
            return query;
        }

        // 添加订单
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        // 修改订单信息（含改订单明细）
        [HttpPut]
        public ActionResult<Order> PutOrder(Order order)
        {
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                foreach (var item in order.orderItems)
                {
                    orderDb.Entry(item).State = EntityState.Modified;
                }
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        // 删除订单
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(long id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
        
        // 给订单添加明细，添加到的订单是item里面的OrderId
        [HttpPost("additem")]
        public ActionResult<OrderItem> PostOrderItem(OrderItem item)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.Id == item.OrderId);
                if (order == null)
                {
                    return BadRequest("没有这个订单！");
                }
                orderDb.OrderItems.Add(item);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return item;
        }

        // 为订单号为orderId的订单删除明细
        [HttpDelete("delitem")]
        public ActionResult<OrderItem> DeleteOrderItem(int? orderId, string productName)
        {
            try
            {
                if (orderId == null || productName == null)
                {
                    return BadRequest("没有提供信息！");
                }
                var item = orderDb.OrderItems.FirstOrDefault(t => (t.OrderId == orderId && t.productName == productName));
                if (item == null)
                {
                    return BadRequest("没有这个明细项！");
                }
                orderDb.Remove(item);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
    }
}
