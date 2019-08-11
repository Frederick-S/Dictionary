using CommandLine;

namespace Dict
{
    public class Options
    {
        [Option('l', "loop", Required = false)]
        public bool Loop { get; set; }
    }
}