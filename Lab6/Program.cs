using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleBuilder[] vehicleBuilders = new VehicleBuilder[2];

            Director producer = new Director(); 

            vehicleBuilders[0] = new CarBuilder();

            producer.Construct(vehicleBuilders[0]);
            vehicleBuilders[0].Vehicle.Show(); 

            Console.WriteLine();

            vehicleBuilders[1] = new MotorCycleBuilder();

            producer.Construct(vehicleBuilders[1]);
            vehicleBuilders[1].Vehicle.Show();
            //-----------------------------------

            vehicleBuilders[1] = new BusBuilder();

            producer.Construct(vehicleBuilders[1]);
            vehicleBuilders[1].Vehicle.Show();
        }

        class Vehicle
        {
            private string vehicleType;
            private List<string> parts = new List<string>();

            public Vehicle(string type)
            {
                vehicleType = type;
            }
            public void Add(string part)
            {
                parts.Add(part);
            }
            public void Show() 
            {
                Console.WriteLine(vehicleType);
                foreach (string part in parts) 
                {
                    Console.WriteLine(part); 
                }
            }

        }
        abstract class VehicleBuilder 
        {
            protected Vehicle vehicle;
            public Vehicle Vehicle 
            {
                get 
                {
                    return vehicle; 
                }
            }
            public abstract void BuildFrame(); 
            public abstract void BuildEngine();
            public abstract void BuildWheels();
            public abstract void BuildDoors(); 
        }
        class CarBuilder : VehicleBuilder 
        {
            public CarBuilder() 
            {
                vehicle = new Vehicle("Car");
            }
            public override void BuildFrame()
            {
                vehicle.Add("CarFrame");
            }
            public override void BuildEngine() 
            {
                vehicle.Add("Engine 2500 cc"); 
            }
            public override void BuildWheels() 
            {
                vehicle.Add("Wheels 4");
            }
            public override void BuildDoors()
            {
                vehicle.Add("Doors 4");
            }
        }
        class MotorCycleBuilder : VehicleBuilder
        {
            public MotorCycleBuilder()
            {
                vehicle = new Vehicle("Motorcycle");
            }
            public override void BuildFrame()
            {
                vehicle.Add("Motorcycle Frame");
            }
            public override void BuildEngine()
            {
                vehicle.Add("Engine 500 cc"); 
            }
            public override void BuildWheels()
            {
                vehicle.Add("Wheels 2");
            }
            public override void BuildDoors()
            {
                vehicle.Add("Doors 0"); 
            }
        }
        //-----------------------------------------
        class BusBuilder : VehicleBuilder
        {
            public BusBuilder()
            {
                vehicle = new Vehicle("Bus");
            }
            public override void BuildFrame()
            {
                vehicle.Add("Bus Frame");
            }
            public override void BuildEngine()
            {
                vehicle.Add("Engine 200 cc");
            }
            public override void BuildWheels()
            {
                vehicle.Add("Wheels 4");
            }
            public override void BuildDoors()
            {
                vehicle.Add("Doors 2");
            }
        }
        class Director 
        {
            public void Construct(VehicleBuilder vehicleBuilder) 
            {
                vehicleBuilder.BuildFrame();
                vehicleBuilder.BuildEngine();
                vehicleBuilder.BuildWheels();
                vehicleBuilder.BuildDoors(); 
            }
        }
    }
}

