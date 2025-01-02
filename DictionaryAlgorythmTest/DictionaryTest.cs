namespace DictionaryAlgorythmTest
{
    public class DictionaryAlgorythmTests
    {
        [Fact]
        public void DictionaryAlgorythm_ValidNewDictionary_ReturnsNewDictionary()
        {
            var processor = new DictionaryAlgorythmForTesting();
            string input = "1,3 2,3";
            string result = processor.DictionaryAlgorythm(input);

            Assert.Equal("Result: ID: 3, Value: 4", result);
        }

        [Fact]
        public void DictionaryAlgorythm_NoDuplicates_ReturnsNoDuplicatesMessage()
        {
            var processor = new DictionaryAlgorythmForTesting();
            string input = "1,3 2,4";
            string result = processor.DictionaryAlgorythm(input);

            Assert.Equal("No duplicates!", result);
        }

        [Fact]
        public void DictionaryAlgorythm_InvalidInput_ReturnsInvalidInputMessage()
        {
            var processor = new DictionaryAlgorythmForTesting();
            string input = "";
            string result = processor.DictionaryAlgorythm(input);

            Assert.Equal("Invalid input", result);
        }

        [Fact]
        public void DictionaryAlgorythm_InvalidFormat_ReturnsInvalidFormatMessage()
        {
            var processor = new DictionaryAlgorythmForTesting();
            string input = "1,2 2";
            string result = processor.DictionaryAlgorythm(input);

            Assert.Equal("Invalid input. Please enter in format 'id,value id,value...'.", result);
        }
    }

}