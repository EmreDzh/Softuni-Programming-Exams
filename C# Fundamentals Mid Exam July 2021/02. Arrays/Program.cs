using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Collections.Generic;
using System.Threading.Channels;

namespace _02._Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();

            List<int> lostNames = new List<int>();
            List<int> lostaNamesTwo = new List<int>();

            string command = Console.ReadLine();

            while (command != "Report")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Blacklist")
                {
                    if (names.Contains(commandArgs[1]))
                    {
                        int index = names.FindIndex(x => x == commandArgs[1]);
                        string newName = "Blacklisted";
                        lostNames.Add(index);

                        names.RemoveAt(index);
                        names.Insert(index, newName);


                        Console.WriteLine($"{commandArgs[1]} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{commandArgs[1]} was not found.");
                    }
                }
                else if (commandArgs[0] == "Error")
                {
                    int index = int.Parse(commandArgs[1]);
                    string name = names[index];


                    if (index >= 0 && index < names.Count)
                    {
                        if (lostaNamesTwo.Contains(index) == false && lostNames.Contains(index) == false)
                        {
                            lostaNamesTwo.Add(index);

                            string newName = "Lost";

                            names.RemoveAt(index);
                            names.Insert(index, newName);

                            Console.WriteLine($"{name} was lost due to an error.");
                        }

                    }
                }
                else if (commandArgs[0] == "Change")
                {
                    int index = int.Parse(commandArgs[1]);


                    if (index >= 0 && index < names.Count)
                    {
                        string currentName = names[index];
                        names.RemoveAt(index);
                        names.Insert(index, commandArgs[2]);

                        Console.WriteLine($"{currentName} changed his username to {commandArgs[2]}.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {lostNames.Count}");
            Console.WriteLine($"Lost names: {lostaNamesTwo.Count}");
            Console.WriteLine(string.Join(" ", names));
        }
    }
}
