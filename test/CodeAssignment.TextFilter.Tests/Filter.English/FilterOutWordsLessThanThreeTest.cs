namespace codeAssignment.TextFilter.Tests.Filter.English
{
   using CodeAssignment.TextFilter.Filters.English;
   using NUnit.Framework;

   [TestFixture]
   public class FilterOutWordsLessThanThreeTest
   {
      private FilterOutWordsLessThanThree filter;

      [SetUp]
      public void SetUp()
      {
         filter = new FilterOutWordsLessThanThree();
      }

      [TestCase("to")]
      [TestCase("At ")]
      [TestCase(" go")]
      [TestCase("hi")]
      public void FilterOutWordsLenghtLessThanThree(string value) 
      {
         var output = filter.FilterTextAsync(value).Result;
         Assert.That(output.Trim(), Is.EqualTo(string.Empty), $"This word [{value}] shoudld be filtered");

      }

      [TestCase("tea")]
      [TestCase(" sun ")]
      [TestCase("cat and dog ")]
      public void FilterOutWordsLenghtLessThanThree_Negative(string value)
      {
         var output = filter.FilterTextAsync(value).Result;
         Assert.That(output, Is.EqualTo(value), $"This word [{value}] shoudld Not be filtered");

      }

      [Test]
      public void FilterOutWordsLenghtLessThanThree_Case()
      {
         string input = "The rabbit hole went straight on like a tunnel for some way, and then dipped suddenly down, so suddenly that Alice had not a moment to think about stopping herself before she found herself falling down a very deep well";
         var output = filter.FilterTextAsync(input).Result;
         Assert.That(output, Is.EqualTo("The rabbit hole went straight like tunnel for some way, and then dipped suddenly down, suddenly that Alice had not moment think about stopping herself before she found herself falling down very deep well"));
      }
   }

}
