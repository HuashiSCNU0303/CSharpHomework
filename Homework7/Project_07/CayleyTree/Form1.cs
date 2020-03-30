using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {        
        Pen drawingPen;
        public Form1()
        {
            InitializeComponent();
            cmbLeftAngle.SelectedIndex = 2;
            cmbRightAngle.SelectedIndex = 3;
            drawingPen = new Pen(Color.Blue, 2);
            lblColor.BackColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取所有数据
            int n, length;
            try
            {
                n = Convert.ToInt32(txtDepth.Text);
                length = Convert.ToInt32(txtLength.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("信息输入不正确！请重新输入！");
                return;
            }
            double th1 = Convert.ToDouble(cmbRightAngle.SelectedItem) * Math.PI / 180;
            double th2 = Convert.ToDouble(cmbLeftAngle.SelectedItem) * Math.PI / 180;
            double per1 = (double)trbRightRatio.Value / 10;
            double per2 = (double)trbLeftRatio.Value / 10;
            Form2 frm2 = new Form2();
            frm2.Show();
            frm2.startDrawing(n, length, th1, th2, per1, per2, drawingPen);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) 
            {
                drawingPen.Color = colorDialog1.Color;
                lblColor.BackColor = colorDialog1.Color;
            }
        }
    }
}
