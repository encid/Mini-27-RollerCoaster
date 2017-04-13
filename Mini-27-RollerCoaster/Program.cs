using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Mini27RollerCoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines(@"C:\enable1.txt");
            List<string> foundWords = new List<string>();

            foreach (var word in words.Where(p => p.Length > 4)) {
                if (isRollercoaster(word.ToLower()))
                    foundWords.Add(word);
            }
            foreach (var word in foundWords)
                Console.WriteLine(word);

            Console.WriteLine("Found {0} rollercoaster words that are 5 chars or longer.", foundWords.Count);
            Console.ReadLine();
            
        }

        static bool isRollercoaster(string word)
        {
            if (word[0] == word[1]) return false;

            bool stepForward = false;
            if (word[0] < word[1])
                stepForward = true;

            for (int i = 0; i < word.Length - 1; i++) {                
                if (stepForward && !(word[i] < word[i + 1]))
                    return false;
                if (!stepForward && !(word[i] > word[i + 1]))
                    return false;
                stepForward = !stepForward;                    
            }

            return true;
        }
    }
}
