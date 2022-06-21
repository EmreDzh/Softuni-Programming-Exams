using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.String_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Compete")
            {
                string[] commandArgs = command.Split();

                if (command.Contains("Make Upper"))
                {

                    email = email.ToUpper();

                    Console.WriteLine(email);
                }
                else if (command.Contains("Make Lower"))
                {
                    email = email.ToLower();

                    Console.WriteLine(email);
                }
                else if (command.Contains("GetDomain"))
                {
                    int count = int.Parse(commandArgs[1]);

                    string substr = email.Substring(email.Length - count);

                    Console.WriteLine(substr);
                }
                else if (command.Contains("GetUsername"))
                {
                    if (!email.Contains('@'))
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        int where = email.IndexOf('@');
                        string result = email.Substring(0, where);

                        Console.WriteLine(result);
                    }
                }
                else if (command.Contains("Replace"))
                {
                    char exact = char.Parse(commandArgs[1]);

                    email = email.Replace(exact, '-');


                    Console.WriteLine(email);

                }
                else if (command.Contains("Encrypt"))
                {
                    byte[] asciiBytes = Encoding.ASCII.GetBytes(email);

                    Console.WriteLine(string.Join(" ", asciiBytes));
                }

                if (command == "Complete")
                {
                    break;
                    command = Console.ReadLine();
                }

                command = Console.ReadLine();
            }
        }
    }
}
