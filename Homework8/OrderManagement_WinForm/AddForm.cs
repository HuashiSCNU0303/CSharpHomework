using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagement_WinForm
{
    public delegate void sendNewOrder(Order order);
    public partial class AddForm : Form
    {
        public event sendNewOrder sendNewOrderEvent;
        Order newOrder;
        public AddForm()
        {
            InitializeComponent();
            newOrder = new Order();
            newOrder.orderItems = new List<OrderItem>();
            txtOrderID.DataBindings.Add("Text", newOrder, "orderID");
            txtClientName.DataBindings.Add("Text", newOrder, "clientName");
            txtClientAddr.DataBindings.Add("Text", newOrder, "clientAddress");
            orderItemBindingSource.DataSource = new BindingList<OrderItem>(newOrder.orderItems);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            newOrder.orderTime = DateTime.Now;
            newOrder.cost = 0;
            foreach (var item in newOrder.orderItems) 
            {
                newOrder.cost += item.productNum * item.productPrice;
            }
            sendNewOrderEvent(newOrder);
            MessageBox.Show("添加成功！");
            this.Close();
        }
    }
}
