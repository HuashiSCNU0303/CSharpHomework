using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes_OOP
{
    class Triangle : IShape
    {
        double[] edges { get; }
        bool isValidShape;
        public Triangle(double edge_1, double edge_2, double edge_3)
        {
            edges = new double[3];
            edges[0] = edge_1;
            edges[1] = edge_2;
            edges[2] = edge_3;
            isValidShape = JudgeValidShape();
        }
        public double getArea()
        {
            if (isValidShape) 
            {
                double p = 0.5 * (edges[0] + edges[1] + edges[2]);
                return Math.Sqrt(p * (p - edges[0]) * (p - edges[1]) * (p - edges[2]));
            }
            else 
            {
                return double.NaN;
            }
        }
        public bool JudgeValidShape()
        {
            Array.Sort(edges);
            if (edges[0] <= 0 || edges[1] <= 0 || edges[2] <= 0)
            {
                return false;
            }
            return ((edges[2] < edges[1] + edges[0]) && (edges[0] > edges[1] - edges[2]));
        }
    }
}
