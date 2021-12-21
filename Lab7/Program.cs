using System;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        // class Adaptee
        class Group
        {
            private string[] data = { "Иван", "Иванов", "21905111", "i.ivanov@gmail.com", "18,5" };

            public string GetItem(string item)
            {
                switch (item.ToLower())
                {
                    case "name":
                        return data[0];
                    case "family":
                        return data[1];
                    case "id":
                        return data[2];
                    case "email":
                        return data[3];
                    case "score":
                        return data[4];
                    default:
                        return "";
                }
            }
        }
    }
}
