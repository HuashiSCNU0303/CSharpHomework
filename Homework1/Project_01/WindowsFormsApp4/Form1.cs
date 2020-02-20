using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取操作符，ComboBox里未选中操作符时opera为空串，排除掉这种情况
            string opera = Convert.ToString(comboBox1.SelectedItem);
            if (opera == "") 
            {
                MessageBox.Show("没有操作符输入！");
                return;
            }
            double num_1 = 0, num_2 = 0;
            //从两个输入框中获取数字，如果失败（即输入框中含有非数字字符）则弹出对话框
            try
            {
                num_1 = Convert.ToDouble(textBox1.Text);
                num_2 = Convert.ToDouble(textBox2.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("没有数字输入！");
                return;
            }
            double result = 0;
            switch(opera)
            {
                case "+":result = num_1 + num_2;break;
                case "-":result = num_1 - num_2;break;
                case "*":result = num_1 * num_2;break;
                case "/": 
                    {
                        if (num_2 == 0) 
                        {
                            MessageBox.Show("除数为0，不能计算！");
                            return;
                        }
                        else
                        {
                            result = num_1 / num_2;
                        }
                        break;
                    }
            }
            //显示结果
            label1.Text = Convert.ToString(result);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "简易计算器";
        }
    }
}
