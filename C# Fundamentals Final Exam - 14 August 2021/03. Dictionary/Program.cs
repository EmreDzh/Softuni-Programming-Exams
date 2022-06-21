using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Dictionary
{
    class Hero
    {
        public int Health { get; set; }
        public int Energy { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Hero> Power = new Dictionary<string, Hero>();
            string command = Console.ReadLine();

            while (command != "Results")
            {
                string[] commandArgs = command.Split(":");

                if (command.Contains("Add"))
                {
                    string personName = commandArgs[1];
                    int health = int.Parse(commandArgs[2]);
                    int energy = int.Parse(commandArgs[3]);

                    if (!Power.ContainsKey(personName))
                    {
                        Power.Add(personName, new Hero { Health = health, Energy = energy });
                    }
                    else
                    {
                        Power[personName].Health += health;
                        
                    }
                }
                else if (command.Contains("Attack"))
                {
                    string attackerName = commandArgs[1];
                    string defenderName = commandArgs[2];
                    int damage = int.Parse(commandArgs[3]);

                    if (Power.ContainsKey(attackerName) && Power.ContainsKey(defenderName))
                    {
                        Power[defenderName].Health -= damage;
                        Power[attackerName].Energy --;

                        if (Power[defenderName].Health <= 0)
                        {

                            Console.WriteLine($"{defenderName} was disqualified!");
                            Power.Remove(defenderName);

                        }
                        if (Power[attackerName].Energy <= 0)
                        {
                            Power.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");

                        }
                    }
                    
                }
                else if (command.Contains("Delete"))
                {
                    string userName = commandArgs[1];

                    if (userName == "All")
                    {
                        Power.Clear();
                    }
                    else
                    {
                        if (Power.ContainsKey(userName))
                        {
                            Power.Remove(userName);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"People count: {Power.Count}");
            foreach (var Herous in Power.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{Herous.Key} - {Herous.Value.Health} - {Herous.Value.Energy}");
            }
        }
    }
}
