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
    public delegate void sendQueryKeyword(string field, string keyword);
    public partial class QueryForm : Form
    {
        public event sendQueryKeyword sendQueryKeywordEvent;
        public QueryForm()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            sendQueryKeywordEvent(cmbQueryField.SelectedItem.ToString(), txtQueryKeyword.Text);
        }
    }
}
