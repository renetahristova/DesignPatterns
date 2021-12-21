using System;
using System.Collections.Generic;

namespace Lab6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichBuilder builder;

            AssemblyLine shop = new AssemblyLine();


            builder = new WithCheese();
            shop.Assemble(builder);
            builder.Sandwich.Show();

            builder = new WithMeat();
            shop.Assemble(builder);
            builder.Sandwich.Show();

           
            Console.ReadKey();
        }
        class Sandwich
        {
            private string _sandwichType;
            private Dictionary<string, string> _ingredients
                = new Dictionary<string, string>();

            public Sandwich(string sandwichType)
            {
                this._sandwichType = sandwichType;
            }

           
            public string this[string key]
            {
                get { return _ingredients[key]; }
                set { _ingredients[key] = value; }
            }

            public void Show()
            {
                Console.WriteLine("\n---------------------------");
                Console.WriteLine("Sandwich: {0}", _sandwichType);
                Console.WriteLine(" Bread: {0}", _ingredients["bread"]);
                Console.WriteLine(" Product: {0}", _ingredients["product"]);
                Console.WriteLine(" Salad: {0}", _ingredients["veggies"]);
                     
               
            }
        }
        abstract class SandwichBuilder
        {
            protected Sandwich sandwich;

           
            public Sandwich Sandwich
            {
                get { return sandwich; }
            }

          
            public abstract void AddBread();
            public abstract void AddProduct();
            public abstract void AddSalad();
            public abstract void Price();
           
        }
        class WithMeat : SandwichBuilder
        {
            public WithMeat()
            {
                sandwich = new Sandwich("Sandwich with Meat");
            }

            public override void AddBread()
            {
                sandwich["bread"] = "White";
            }

            public override void AddProduct()
            {
                sandwich["meat"] = "Mwat";
            }

            public override void AddSalad()
            {
                sandwich["veggies"] = "Lettuce, Tomato";
            }

            public override void Price()
            {
             //
            }

       
        }


        class WithCheese : SandwichBuilder
        {
            public WithCheese()
            {
                sandwich = new Sandwich("Cheese");
            }

            public override void AddBread()
            {
                sandwich["bread"] = "Wheat";
            }

            public override void AddProduct()
            {
                sandwich["meat"] = "Bacon";
            }

            public override void AddSalad()
            {
                sandwich["veggies"] = "Lettuce, Tomato";
            }

            public override void Price()
            {
               //
            }

       
        }

        class AssemblyLine
        {
          
            public void Assemble(SandwichBuilder sandwichBuilder)
            {
                sandwichBuilder.AddBread();
                sandwichBuilder.AddProduct();
                sandwichBuilder.AddSalad();
                sandwichBuilder.Price();
                
            }
        }

    }
}
