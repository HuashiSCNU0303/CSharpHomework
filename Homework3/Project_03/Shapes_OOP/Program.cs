using System;

namespace Shapes_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Shapes = new string[3] { "三角形", "矩形", "正方形" };
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            double area = 0, count = 0;
            for (int i = 0; i < 10; i++) 
            {
                IShape shape = null;            
                int type = rd.Next(0, 3);
                double edge_1 = rd.NextDouble() * 100;
                double edge_2 = rd.NextDouble() * 100;
                double edge_3 = rd.NextDouble() * 100;
                switch (type)
                {
                    case 0:
                        shape = SimpleShapeFactory.CreateShape(Shapes[type], edge_1, edge_2, edge_3);
                        Console.WriteLine("这是一个" + Shapes[type] + "，三边长为：" + edge_1 + "，" + edge_2 + "，" + edge_3 + "，面积为" + shape.getArea());
                        break;
                    case 1:
                        shape = SimpleShapeFactory.CreateShape(Shapes[type], edge_1, edge_2);
                        Console.WriteLine("这是一个" + Shapes[type] + "，两边长为：" + edge_1 + "，" + edge_2 + "，面积为" + shape.getArea());
                        break;
                    case 2:
                        shape = SimpleShapeFactory.CreateShape(Shapes[type], edge_1);
                        Console.WriteLine("这是一个" + Shapes[type] + "，边长为：" + edge_1 + "，面积为" + shape.getArea());
                        break;
                }
                //getArea()返回NaN表示该形状不合法，不能计算面积
                if (!shape.getArea().Equals(double.NaN))   
                {
                    area += shape.getArea();
                    count++;
                }
            }
            Console.WriteLine("合法形状数为：" + count + "，面积总和为：" + area);
        }
    }
}
