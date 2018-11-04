using Xunit;

namespace Dict.Tests
{
    public class QueryTest
    {
        [Fact]
        public void ShouldFindWordWithExplanations()
        {
            var word = new Dict().Query("name");

            Assert.True(word.Pronunciations.Count > 0);
            Assert.True(word.Explanations.Count > 0);
        }

        [Fact]
        public void ShouldFindWordSuggestions()
        {
            var word = new Dict().Query("nameaaaa");

            Assert.True(word.Suggestions.Count > 0);
        }
    }
}
