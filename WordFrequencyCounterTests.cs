using WordsCounter;

namespace Tests.WordsCounter
{
    [TestFixture]
    public class Tests
    {
        WordFrequencyCounter counter = new();


        [Test]
        public void GivenInputText_WithAlphaNumericWords_ThenMatchExpectedDictionary()
        {
            string inputText = "Cat apple Zebra Formula1 APple";
            Dictionary<string, int> expected = new() { { "Cat", 1 }, { "Zebra", 1 }, { "apple", 2 }, { "Formula1", 1 } };

            IEnumerable<string> words = GetWords(inputText);
            var wordsCount = counter.CountInParallel(words);

            Assert.That(expected, Is.EqualTo(wordsCount));
        }

        [Test]
        public void GivenInputText_WithSpecialCharacters_ThenMatchExpectedDictionary()
        {
            string inputText = "apple ball cat @apple";
            Dictionary<string, int> expected = new() { { "apple", 1 }, { "ball", 1 },{"cat",1 }, { "@apple", 1 } };

            IEnumerable<string> words = GetWords(inputText);
            var wordsCount = counter.CountInParallel(words);

            Assert.That(expected, Is.EqualTo(wordsCount));
        }

        private IEnumerable<string> GetWords(string text)
        {
            return text.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }
    }
}