using System.Collections.Generic;

namespace Dict
{
    public class Word
    {
        public string Name { get; set; }

        public List<string> Explanations { get; set; }

        public List<string> Suggestions { get; set; }
    }
}
