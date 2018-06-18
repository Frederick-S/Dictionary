using System.Collections.Generic;

namespace Dict
{
    public class Word
    {
        public Word()
        {
            this.Explanations = new List<string>();

            this.Suggestions = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Explanations { get; set; }

        public List<string> Suggestions { get; set; }
    }
}
