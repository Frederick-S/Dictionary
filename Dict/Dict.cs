using System.Linq;
using System.Text.RegularExpressions;
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
            var pronunciationNodes = document.QuerySelectorAll(".wordbook-js .baav .pronounce");

            if (explanationNodes.Count() == 0)
            {
                var suggestionNodes = document.QuerySelectorAll(".typo-rel");

                word.Suggestions = suggestionNodes.Select(x => this.TrimSuggestion(x.InnerText))
                    .ToList();
            }
            else
            {
                word.Pronunciations = pronunciationNodes.Select(x =>
                {
                    var accentType = x.InnerText;
                    var soundmark = x.QuerySelector(".phonetic")?.InnerText;

                    if (accentType.Contains("英"))
                    {
                        return new Pronunciation
                        {
                            AccentType = AccentType.British,
                            Soundmark = soundmark,
                        };
                    }
                    else if (accentType.Contains("美"))
                    {
                        return new Pronunciation
                        {
                            AccentType = AccentType.American,
                            Soundmark = soundmark,
                        };
                    }
                    else
                    {
                        return null;
                    }
                })
                .Where(x => x != null)
                .ToList();

                word.Explanations = explanationNodes.Select(x => x.InnerText)
                    .ToList();
            }

            return word;
        }

        private string TrimSuggestion(string suggestion)
        {
            var regex = new Regex("[ ]{2,}", RegexOptions.None);
            var result = suggestion.Trim()
                .Replace("\n", string.Empty);

            return regex.Replace(result, " ");
        }
    }
}
