using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Collections.Generic;

namespace _03._Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> phoneModel = Console.ReadLine().Split(", ").ToList();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split(" - ");

                if (commandArgs[0] == "Add")
                {
                    if (phoneModel.Contains(commandArgs[1]) == false)
                    {
                        phoneModel.Add(commandArgs[1]);
                    }
                }
                else if (commandArgs[0] == "Remove")
                {
                    if (phoneModel.Contains(commandArgs[1]))
                    {
                        int index = phoneModel.FindIndex(x => x == commandArgs[1]);

                        phoneModel.RemoveAt(index);
                    }
                }
                else if (commandArgs[0] == "Bonus phone")
                {
                    string[] commandArgsTwo = commandArgs[1].Split(":");

                    string oldPhone = commandArgsTwo[0];
                    string newPhone = commandArgsTwo[1];

                    int index = phoneModel.FindIndex(x => x == oldPhone);

                    if (phoneModel.Contains(oldPhone))
                    {
                        phoneModel.Insert(index + 1, newPhone);
                    }
                }
                else if (commandArgs[0] == "Last")
                {
                    if (phoneModel.Contains(commandArgs[1]))
                    {
                        int index = phoneModel.FindIndex(x => x == commandArgs[1]);

                        phoneModel.RemoveAt(index);
                        phoneModel.Add(commandArgs[1]);
                    }
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", phoneModel));
        }
    }
}
