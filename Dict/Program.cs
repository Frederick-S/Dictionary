using System;
using CommandLine;

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

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(options =>
                {
                    if (options.Loop)
                    {
                        while (true)
                        {
                            Console.Write("dict > ");

                            var name = Console.ReadLine();

                            Query(name);
                        }
                    }
                    else
                    {
                        Query(args[0]);
                    }
                });
        }

        private static void Query(string name)
        {
            var word = new Dict().Query(name);

            new Printer().Print(word);
        }
    }
}
