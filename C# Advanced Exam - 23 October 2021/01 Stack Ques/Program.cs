using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Stack_Ques
{
    class Program
    {
        static void Main(string[] args)
        {
            var vowels = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));
            var consonants = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

            var wordsToLookFor = new Dictionary<string, int>();
            

            var wordOne = "pear".ToCharArray().ToList();
            var wordTwo = "flour".ToCharArray().ToList();
            var wordThree = "pork".ToCharArray().ToList();
            var wordForth = "olive".ToCharArray().ToList();

            wordsToLookFor.Add("pear", 0);
            wordsToLookFor.Add("flour", 0);
            wordsToLookFor.Add("pork", 0);
            wordsToLookFor.Add("olive", 0);
            
            while (consonants.Count > 0)
            {
                
                var vow = vowels.Dequeue();
                vowels.Enqueue(vow);
                var cons = consonants.Pop();


                if (wordOne.Contains(vow))
                {
                    wordOne.Remove(vow);
                }

                if (wordOne.Contains(cons))
                {
                    wordOne.Remove(cons);
                }
                
                if (wordTwo.Contains(vow))
                {
                    wordTwo.Remove(vow);
                }

                if (wordTwo.Contains(cons))
                {
                    wordTwo.Remove(cons);
                }

                if (wordThree.Contains(vow))
                {
                    wordThree.Remove(vow);
                }

                if (wordThree.Contains(cons))
                {
                    wordThree.Remove(cons);
                }


                if (wordForth.Contains(vow))
                {
                    wordForth.Remove(vow);
                }

                if (wordForth.Contains(cons))
                {
                    wordForth.Remove(cons);
                }

                

                if (wordThree.Count == 0)
                {
                    wordsToLookFor["pork"]++;
                    wordThree = "pork".ToCharArray().ToList();
                }

                if (wordForth.Count == 0)
                {
                    wordsToLookFor["olive"]++;
                    wordForth = "olive".ToCharArray().ToList();
                }

                if (wordTwo.Count == 0)
                {
                    wordsToLookFor["flour"]++;
                    wordTwo = "flour".ToCharArray().ToList();
                }

                if (wordOne.Count == 0)
                {
                    wordsToLookFor["pear"]++;
                    wordOne = "pear".ToCharArray().ToList();
                }

               
            }
            

            wordsToLookFor = wordsToLookFor.Where(w => w.Value > 0).ToDictionary(w => w.Key, w => w.Value);
            
            Console.WriteLine($"Words found: {wordsToLookFor.Sum(w => w.Value)}");

            foreach (var VARIABLE in wordsToLookFor)
            {
                Console.WriteLine(VARIABLE.Key);
            }
        }
    }
}
