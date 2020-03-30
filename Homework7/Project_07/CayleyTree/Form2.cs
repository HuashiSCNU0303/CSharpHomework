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
    public partial class Form2 : Form
    {
        Graphics graphics;
        int n;
        int length;
        double th1;
        double th2;
        double per1;
        double per2;
        Pen drawingPen;

        public Form2()
        {
            InitializeComponent();
        }

        
        public void startDrawing(int n, int length, double th1, double th2, double per1, double per2, Pen drawingPen)
        {
            this.th1 = th1;
            this.th2 = th2;
            this.per1 = per1;
            this.per2 = per2;
            this.drawingPen = drawingPen;
            this.n = n;
            this.length = length;
            if (graphics == null)
            {
                graphics = this.CreateGraphics();
            }
            drawCayleyTree(n, this.Width/2, this.Height, length, -Math.PI / 2);
        }
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1, drawingPen);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1, Pen pen)
        {
            graphics.DrawLine(
                pen,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }
    }
}
