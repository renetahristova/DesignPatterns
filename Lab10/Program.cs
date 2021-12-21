using System;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();

            ICommand command = invoker.GetCommand("Start");
            command.Execute();

            command = invoker.GetCommand("Stop");
            command.Execute();

        }
        public interface ICommand
        {
            string Name { 
                get; 
            }
            void Execute();
        }
        public class StartCommand : ICommand 
        {
            public void Execute() 
            {
                Console.WriteLine("Изпълнение на команда Start ..."); 
            }
            public string Name 
            {
                get 
                {
                    return "Start";
                }
            }
        }
        public class StopCommand : ICommand 
        {
            public void Execute()
            {
                Console.WriteLine("Изпълнение на команда Stop.");
            }
            public string Name 
            {
                get 
                { 
                    return "Stop"; 
                }
            }
        }
        public class Invoker
        {
            ICommand cmd = null;
            public ICommand GetCommand(string action)
            {
                switch (action)
                {
                    case "Start": 
                        cmd = new StartCommand();
                        break; 
                    case "Stop":
                        cmd = new StopCommand();
                        break;
                    default:
                        break;
                }
                return cmd;
            }
        }
    }
}
