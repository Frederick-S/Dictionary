using System;
using System.Linq;
using System.Text;

namespace Dict
{
    public class Printer
    {
        public void Print(Word word)
        {
            Console.OutputEncoding = Encoding.UTF8;

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
                string pronunciations = string.Join("\t", word.Pronunciations.Select(x =>
                {
                    switch (x.AccentType)
                    {
                        case AccentType.British:
                            return string.Format("英{0}", x.Soundmark);
                        case AccentType.American:
                            return string.Format("美{0}", x.Soundmark);
                        default:
                            return string.Empty;
                    }
                }).Where(x => !string.IsNullOrEmpty(x)));

                Console.WriteLine(pronunciations);

                word.Explanations.ForEach(x => Console.WriteLine(x));
            }
        }
    }
}
