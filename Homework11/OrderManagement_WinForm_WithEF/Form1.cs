using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace OrderManagement_WinForm
{
    public partial class Form1 : Form
    {
        OrderService orderService;
        bool allowEdit = false;
        bool allowQuery = false;
        public Form1()
        {
            orderService = new OrderService();
            InitializeComponent();
            orderBindingSource.DataSource = new BindingList<Order>(orderService.orders);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addNewOrder(Order order)
        {
            orderService.addOrder(order);
            orderBindingSource.DataSource = new BindingList<Order>(orderService.orders);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.sendNewOrderEvent += new sendNewOrder(addNewOrder);
            addForm.Show();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgvOrderInfo.Rows.Count == 0)
            {
                return;
            }
            int removeIndex = dgvOrderInfo.CurrentRow.Index;
            orderService.removeOrder(removeIndex);
            orderBindingSource.DataSource = new BindingList<Order>(orderService.orders);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (!allowEdit)
            {
                allowEdit = true;
                btnModify.Text = "结束修改";
                for (int i = 2; i < 5; i++)
                {
                    dgvOrderInfo.Columns[i].ReadOnly = false;
                }
                for (int i = 0; i < dgvOrderItemInfo.Columns.Count; i++)
                {
                    dgvOrderItemInfo.Columns[i].ReadOnly = false;
                }
                dgvOrderItemInfo.AllowUserToAddRows = true;
                dgvOrderItemInfo.AllowUserToDeleteRows = true;
            }
            else
            {
                allowEdit = false;
                btnModify.Text = "修改订单";
                for (int i = 2; i < 5; i++)
                {
                    dgvOrderInfo.Columns[i].ReadOnly = true;
                }
                for (int i = 0; i < dgvOrderItemInfo.Columns.Count; i++)
                {
                    dgvOrderItemInfo.Columns[i].ReadOnly = true;
                }
                dgvOrderItemInfo.AllowUserToAddRows = false;
                dgvOrderItemInfo.AllowUserToDeleteRows = false;
                // 更新数据库
                orderService.updateDatabase();
            }
            
        }

        private void queryOrder(string field, string keyword)
        {
            List<Order> selectedOrders = orderService.queryOrder(field, keyword) as List<Order>;
            if (selectedOrders != null)
            {
                orderBindingSource.DataSource = new BindingList<Order>(selectedOrders);
            }
            else
            {
                MessageBox.Show("字段输入不正确，请重新输入！");
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (!allowQuery)
            {
                allowQuery = true;
                btnQuery.Text = "恢复原列表";
                QueryForm queryForm = new QueryForm();
                queryForm.sendQueryKeywordEvent += queryOrder;
                queryForm.Show();
            }
            else
            {
                allowQuery = false;
                btnQuery.Text = "查询订单";
                orderBindingSource.DataSource = new BindingList<Order>(orderService.orders);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "可扩展标记语言文件（*.xml）|*.xml";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName.ToString();
            }
            orderService.exportOrders(filePath);
            MessageBox.Show("导出成功！");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "可扩展标记语言文件（*.xml）|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName.ToString();
            }
            else
            {
                return;
            }
            try
            {
                orderService.importOrders(filePath);
                orderBindingSource.DataSource = new BindingList<Order>(orderService.orders);
                MessageBox.Show("导入成功！");
            }
            catch(Exception)
            {
                MessageBox.Show("导入失败！");
            }
        }
    }
}
