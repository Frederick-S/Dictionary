using Xunit;

namespace Dict.Tests
{
    public class QueryTest
    {
        [Fact]
        public void ShouldFindWordWithExplanations()
        {
            var word = new Dict().Query("name");

            Assert.True(word.Explanations.Count > 0);
        }
    }
}
