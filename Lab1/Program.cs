using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        { 
            
        }
        //Слаба свързаност наотговорностите при клас
        class Point
        {
            private int x, y;
            private int Vx, Vy;
            public void Input()
            {
                Console.Write("Enter a value for x:");
                x = Int32.Parse(Console.ReadLine());
                Console.Write("Enter a value for y:");
                y = Int32.Parse(Console.ReadLine());
            }
            public void Translation()
            {
                Console.Write("Enter a value for Vx:");
                Vx = Int32.Parse(Console.ReadLine());
                Console.Write("Enter a value for Vy:");
                Vy = Int32.Parse(Console.ReadLine());
                x += Vx; y += Vy;
                Console.WriteLine("The point has been translated to {0}, {1}", x, y);
            }
        }
        
    }

}