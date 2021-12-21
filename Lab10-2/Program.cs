using System;
using System.Collections.Generic;

namespace Lab10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);
            user.Undo(4);
            user.Redo(3);
        } 
        class Calculator
        {
            int curr = 0;
            public void ExecuteOperation(char operation, int operand)
            {
                switch (operation)
                {
                    case '+':
                        curr += operand;
                        break;
                    case '-':
                        curr -= operand;
                        break;
                    case '*':
                        curr *= operand;
                        break;
                    case '/':
                        curr /= operand;
                        break;
                }
                Console.WriteLine("Current value = {0} (following {1} {2})", curr, operation, operand);
            }
        }
        public abstract class Command
        {
            public abstract void Execute();
            public abstract void UnExecute();
        }
        class CalculatorCommand : Command
        {
            char operation; int operand;
            Calculator calculator;
            public CalculatorCommand(Calculator calculator, char operation, int operand)
            {
                this.calculator = calculator;
                this.operation = operation;
                this.operand = operand;
            }// Execute new command
            public override void Execute()
            {
                calculator.ExecuteOperation(operation, operand);
            }
            // Unexecute last command
            public override void UnExecute()
            {
                calculator.ExecuteOperation(Undo(operation), operand);
            }
            // Returns opposite operator for given operator
            private char Undo(char operation)
            {
                switch (operation)
                {
                    case '+':
                        return '-';
                    case '-':
                        return '+';
                    case '*':
                        return '/';
                    case '/':
                        return '*';
                    default:
                        throw new ArgumentException("operation");
                }
            }

             class User
            {
                Calculator calculator = new Calculator();
                List<Command> commands = new List<Command>();
                int current = 0;
                public void Redo(int levels)
                {
                    Console.WriteLine("\n----Redo {0} levels ", levels);
                    for (int i = 0; i < levels; i++)
                    {
                        if (current < commands.Count - 1)
                        {
                            Command command = commands[current++];
                            command.Execute();
                        }
                    }
                }
                public void Undo(int levels)
                {
                    Console.WriteLine("\n----Undo {0} levels ", levels);
                    for (int i = 0; i < levels; i++) 
                    {
                        if (current > 0) 
                        {
                            Command command = commands[--current] as Command; 
                            command.UnExecute(); 
                        }
                    }
                }
                public void Compute(char operation, int operand) 
                {
                    Command command = new CalculatorCommand(calculator, operation, operand);
                    command.Execute(); 
                    commands.Add(command);
                    current++; 
                }
            }
        }
    }
 }

