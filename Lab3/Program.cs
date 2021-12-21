using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            IContinentalFactory factory1 = new AfricanFactory();
            Client client1 = new Client(factory1); client1.Run(); 
            IContinentalFactory factory2 = new AsiaticFactory(); 
            Client client2 = new Client(factory2);
            client2.Run();
        }
        interface IElephant
        {
            int GetWeight(); 
            int GetHeight();
            //добавяне на методи
            string GetHabitat();
        }
        interface ILion
        {
            string GetFeatures(); 
            void CanMeet(IElephant elephant);
            //добавяне на методи
            string LatinName();
        }

        class AfricanElephant : IElephant
        {
            public int GetWeight()
            {
                return 7500; 
            }
            public int GetHeight()
            {
                return 4; 
            }
            //----------
            public string GetHabitat()
            {
                return "Централна и Западна Африка";
            }
        }
        class IndianElephant : IElephant 
        {
            public int GetWeight()
            {
                return 6000;
            }
            public int GetHeight()
            {
                return 3;
            }
            public string GetHabitat()
            {
                return "Tропически регион";
            }
        }
        class AfricanLion : ILion
        {
            public string GetFeatures()
            {
                return "Има голяма грива";
            }
            public void CanMeet(IElephant elephant)
            {
                Console.WriteLine(this.GetType().Name + "   може   да   срешне   " + elephant.GetType().Name);
            }
            //--------
            public string LatinName()
            {
                return "Panthera leo";
            }

        }
        class AsiaticLion : ILion 
        {
            public string GetFeatures() 
            {
                return "Има малка грива";
            }
            public void CanMeet(IElephant elephant)
            {
                Console.WriteLine(this.GetType().Name + "   може   да   срешне   " + elephant.GetType().Name); 
            }
            //--------
            public string LatinName()
            {
                return "Panthera leo persica";
            }
        }

        interface IContinentalFactory
        {
            ILion CreateLion();
            IElephant CreateElephant();
        }
        class AfricanFactory : IContinentalFactory 
        {
            public ILion CreateLion() 
            {
                return new AfricanLion(); 
            }
            public IElephant CreateElephant()
            {
                return new AfricanElephant();
            }
        }
        class AsiaticFactory : IContinentalFactory
        {
            public ILion CreateLion() 
            {
                return new AsiaticLion();
            }
            public IElephant CreateElephant() 
            {
                return new IndianElephant();
            }
        }
        class Client
        {
            private ILion lion;
            private IElephant elephant;
            public Client(IContinentalFactory factory)
            {
                lion = factory.CreateLion(); elephant = factory.CreateElephant();
            }
            public void Run()
            {
                Console.WriteLine(elephant.GetType().Name + "     тежи     " + elephant.GetWeight() + "кг" + "habitat:" + elephant.GetHabitat());
                Console.WriteLine(elephant.GetType().Name + "   е   висок" + elephant.GetHeight() + "м" ); 
                Console.WriteLine(lion.GetType().Name + lion.GetFeatures() + lion.LatinName());
                lion.CanMeet(elephant) ; 
            }
        }
    }
}
