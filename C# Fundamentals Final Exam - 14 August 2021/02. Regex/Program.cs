using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Regex
{
    class Program
    {
        static void Main(string[] args)
        {

            int goUp = int.Parse(Console.ReadLine());

            Regex matchThem = new Regex(@"([$%])(?<Name>[A-Z][a-z]{2,})\1:\s\[(?<firstGroup>\w+)\]\|\[(?<secondGroup>\w+)\]\|\[(?<thirdGroup>\w+)\]\|");

            for (int i = 0; i < goUp; i++)
            {
                string command = Console.ReadLine();
                
                Match compare = matchThem.Match(command);

                int numberUp = 0;

                for (int k = 0; k < command.Length; k++)
                {
                    if (command[k] == '|')
                    {
                        numberUp++;
                    }
                }
                
                if (compare.Success && numberUp <= 3)
                {
                    
                    Console.WriteLine($"{compare.Groups["Name"].Value}: {(char)int.Parse(compare.Groups["firstGroup"].Value)}{(char)int.Parse(compare.Groups["secondGroup"].Value)}{(char)int.Parse(compare.Groups["thirdGroup"].Value)}");
                }

                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
