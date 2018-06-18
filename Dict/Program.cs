using System;

namespace Dict
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: dict word");

                return;
            }

            var name = args[0];
            var word = new Dict().Query(name);

            Display(word);
        }

        private static void Display(Word word)
        {
            if (word.Explanations.Count == 0)
            {
                if (word.Suggestions.Count == 0)
                {
                    Console.WriteLine("No resulets found");
                }
                else
                {
                    Console.WriteLine("Are you looking for:");

                    word.Suggestions.ForEach(x => Console.WriteLine(x));
                }
            }
            else
            {
                word.Explanations.ForEach(x => Console.WriteLine(x));
            }
        }
    }
}
