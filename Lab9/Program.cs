using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
           
            SortedList array = new SortedList();
            array.Add("Ani");
            array.Add("Bob");
            array.Add("Sam");
            array.Add("George");
            array.Add("Anna");
           
            array.SetSortStrategy(new DirectInsertion());
            array.Sort();
           
            Console.ReadKey();
        
    }
        public abstract class SortStrategy
        {
            public abstract void Sort(List<string> list);
        }

       
        public class DirectInsertion : SortStrategy
        {
            public override void Sort(List<string> list)
            {
               //

                Console.WriteLine("Direct Indertion Sorted list ");
            }
        }

        public class SortedList
        {
            private List<string> list = new List<string>();

            private SortStrategy sortstrategy;
            public void SetSortStrategy(SortStrategy sortstrategy)
            {
                this.sortstrategy = sortstrategy;
            }
            public void Add(string name)
            {
                list.Add(name);
            }
            public void Sort()
            {
                sortstrategy.Sort(list);
                
                foreach (string name in list)
                {
                    Console.WriteLine(" " + name);
                }
                Console.WriteLine();
            }
        }
    }
}

