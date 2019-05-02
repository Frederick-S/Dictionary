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

            new Printer().Print(word);
        }
    }
}
