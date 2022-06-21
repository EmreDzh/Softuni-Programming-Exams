using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Collections.Generic;

namespace _01._Conditional_Statements_And_Loops
{
    class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());

            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());

            double freePackages = 0;

            for (int i = 1; i <= students; i++)
            {
                if (i % 5 == 0)
                {
                    freePackages++;
                }
            }

            double cost = flourPrice * (students - freePackages)
                          + eggPrice * 10 * students
                          + apronPrice * Math.Ceiling(students * 1.2);

            if (cost <= budget)
            {
                Console.WriteLine($"Items purchased for {cost:f2}$.");
            }

            else
            {
                Console.WriteLine($"{(cost - budget):f2}$ more needed.");
            }

        }
    }
}
