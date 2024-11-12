using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace hw6
{
    internal class Program
    {
        class Figure
        {
            private int _layer;
            private string _edgecolor = "black";
            private double _edgethickness = 1.0;
            private string _fillcolor = "white";
            public int Layer
            {
                get => _layer;
                set => _layer = value;
            }

            public string EdgeColor
            {
                get => _edgecolor;
                set => _edgecolor = value;
            }

            public double EdgeThickness
            {
                get => _edgethickness;
                set => _edgethickness = value;
            }

            public string FillColor
            {
                get => _fillcolor;
                set => _fillcolor = value;
            }
        }

        class Point
        {
            private double _x = 0.0;
            private double _y = 0.0;
            public double X_Position
            {
                get => _x;
                set => _x = value;
            }
            public double Y_Position
            {
                get => _y;
                set => _y = value;
            }
        }

        sealed class Circle : Figure
        {
            private double _radius = 0.0;
            private Point _center;
            public double Radius
            {
                get => _radius;
                set => _radius = value;
            }
            public Point Center
            {
                get => _center;
                set => _center = value;
            }
        }

        sealed class Edge : Figure
        {
            private readonly string _fillcolor = "black";
            private Point _firstpoint;
            private Point _secondpoint;
            public new string FillColor {
                get => _fillcolor;
            }
            public Point FirstPoint
            {
                get => _firstpoint;
                set => _firstpoint = value;
            }
            public Point SecondPoint
            {
                get => _secondpoint;
                set => _secondpoint = value;
            }

            public void ShowVerticalEdges(Edge[] edge)
            {
                for (int i = 0; i < edge.Length; i++)
                {
                    if (edge[i].FirstPoint.X_Position == edge[i].SecondPoint.X_Position)
                    {
                        Console.WriteLine($"{edge[i].FirstPoint.X_Position} {edge[i].FirstPoint.Y_Position} {edge[i].SecondPoint.X_Position} {edge[i].SecondPoint.Y_Position}");
                    }
                }
            }
        }

        class Polygon : Figure
        {
            private Point[] _points;
            public Point[] Points
            {
                get => _points;
                set => _points = value;
            }
        }

        static void Main(string[] args)
        {
            Figure figure = new Figure();
            Circle circle = new Circle() { Radius = 7.0 };
            Point px1 = new Point() { X_Position = 4.0, Y_Position = 9.0 };
            Point py1 = new Point() { X_Position = 7.0, Y_Position = -1.0 };
            Point px2 = new Point() { X_Position = 1.0, Y_Position = 10.0 };
            Point py2 = new Point() { X_Position = 1.0, Y_Position = 8.0 };
            Point px3 = new Point() { X_Position = -4.0, Y_Position = 6.0 };
            Point py3 = new Point() { X_Position = 4.0, Y_Position = 5.0 };
            Edge edge1 = new Edge() { FirstPoint = px1, SecondPoint = py1};
            Edge edge2 = new Edge() { FirstPoint = px2, SecondPoint = py2 };
            Edge edge3 = new Edge() { FirstPoint = px3, SecondPoint = py3 };
            Edge[] edges = { edge1, edge2, edge3 };
            Console.WriteLine(edge1.FirstPoint.X_Position);
            Console.WriteLine(figure.EdgeThickness);
            Console.WriteLine(figure.FillColor);
            Console.WriteLine(circle.Radius);
            Console.WriteLine(px3.X_Position);
            Console.WriteLine(edge1.FirstPoint.X_Position);
            edge1.ShowVerticalEdges(edges);
        }
    }
}
