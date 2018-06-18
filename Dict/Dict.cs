using System.Linq;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace Dict
{
    public class Dict
    {
        private const string QueryUrl = "http://dict.youdao.com/w/";

        public Word Query(string name)
        {
            var url = string.Format("{0}{1}", QueryUrl, name);
            var htmlDocument = new HtmlWeb().Load(url);
            var document = htmlDocument.DocumentNode;

            var word = new Word();
            var explanationNodes = document.QuerySelectorAll(".wordbook-js + .trans-container ul li");

            if (explanationNodes.Count() == 0)
            {
                var suggestionNodes = document.QuerySelectorAll(".typo-rel");

                word.Suggestions = suggestionNodes.Select(x => this.TrimSuggestion(x.InnerText))
                    .ToList();
            }
            else
            {
                word.Explanations = explanationNodes.Select(x => x.InnerText)
                    .ToList();
            }

            return word;
        }

        private string TrimSuggestion(string suggestion)
        {
            return suggestion.Trim()
                .Replace("\n", string.Empty)
                .Replace(" ", string.Empty);
        }
    }
}
