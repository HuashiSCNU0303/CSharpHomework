using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes_OOP
{
    class Rectangle : IShape
    {
        double width { get; }
        double height { get; }
        bool isValidShape;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
            isValidShape = JudgeValidShape();
        }
        public double getArea()
        {
            if (isValidShape) 
            {
                return width * height;
            }
            else 
            {
                return double.NaN;
            }
        }
        public bool JudgeValidShape()
        {
            return !(width <= 0 || height <= 0);
        }
    }
}
