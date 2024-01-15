namespace codeAssignment.TextFilter.Tests.Filter.English
{
   using CodeAssignment.TextFilter.Filters.English;
   using Newtonsoft.Json.Linq;
   using NUnit.Framework;

   [TestFixture]
   public class FilterOutMiddleVowelWordsTest
   {
      private FilterOutMiddleVowelWords filter;

      [SetUp]
      public void SetUp()
      {
         filter = new FilterOutMiddleVowelWords();
      }


      [Test]
      [TestCase("clean")]
      [TestCase("what")]
      [TestCase("currently")]
      [TestCase("hi people")]
      [TestCase(" a ")]
      [TestCase("hoUse")]
      [TestCase("cAt ")]
      public void FilteringOutTheMiddleVowelWords(string value)
      {
         var output = filter.FilterTextAsync(value).Result;
         Assert.That(output.Trim(), Is.EqualTo(string.Empty),$"This word [{value}] shoudld be filtered");

      }

      [Test]
      [TestCase("the")]
      [TestCase("rather")]
      [TestCase("beginning")]
      public void FilteringOutInTheMiddleVowelWords_Negative(string value)
      {
         var output = filter.FilterTextAsync(value).Result;
         Assert.That(output, Is.EqualTo(value), $"This word [{value}] shoudld be not be filtered");
      }

      [Test]
      public void FilteringOutInTheMiddleVowelWords_Case()
      {
         string input = "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do:";
         var output = filter.FilterTextAsync(input).Result;
         Assert.That(output, Is.EqualTo(" beginning tired sitting sister the , and nothing :"));
      }
   }
}
