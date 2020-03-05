using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes_OOP
{
    class SimpleShapeFactory
    {
        public static IShape CreateShape(string type, params double[] edges)
        {
            if (type.Equals("三角形")) 
            {
                return new Triangle(edges[0], edges[1], edges[2]);
            }
            else if(type.Equals("矩形"))
            {
                return new Rectangle(edges[0], edges[1]);
            }
            else if(type.Equals("正方形"))
            {
                return new Square(edges[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
