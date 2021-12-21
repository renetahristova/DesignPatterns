using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[3];
  

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Surface: {0}", shapes[i].CalculateArea());
            }
        }
        abstract class Shape
        {
            public double width;
            public double height;
            public virtual double CalculateArea()
            {
                return 0;
            }
        }


        class Rectangle : Shape
        {


            public override double CalculateArea()
            {
                return height * width;
            }
        }
        class Triangle : Shape
        {


            public override double CalculateArea()
            {
                return height * width / 2;
            }
        }
        class Circle : Shape
        {


            public Circle(double radius)
            {
                height = radius;
                width = radius;
            }


            public override double CalculateArea()
            {
                return Math.PI * width * height;
            }
        }
    }
}
