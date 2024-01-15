namespace codeAssignment.TextFilter.Tests.Filter.English
{
   using CodeAssignment.TextFilter.Filters.English;
   using NUnit.Framework;


   [TestFixture]
   public class FilterOutOWordsContainsLowerTTest
   {
      private FilterOutOWordsContainsLowerT filter;

      [SetUp]
      public void SetUp()
      {
         filter = new FilterOutOWordsContainsLowerT();
      }

      [Test]
      [TestCase("Test")]
      [TestCase(" tea")]
      [TestCase("butter" )]
      public void FilterOutOWordsContainsLowerT(string value)
      {
         var output = filter.FilterTextAsync(value).Result;
         Assert.That(output.Trim(), Is.EqualTo(string.Empty), $"This word [{value}] shoudld be filtered");

      }

      [Test]
      [TestCase("house")]
      [TestCase("garden")]
      [TestCase("sun")]
      public void FilterOutOWordsContainsLowerT_Negative(string value)
      {
         var output = filter.FilterTextAsync(value).Result;
         Assert.That(output, Is.EqualTo(value), $"This word [{value}] shoudld Not be filtered");

      }



      [Test]
      public void FilterOutOWordsContainsLowerT_Case()
      {
         string input = "There was nothing so very remarkable in that; nor did Alice cross think it so very much out of the way to hear the Rabbit say to itself,";
         var output = filter.FilterTextAsync(input).Result;
         Assert.That(output, Is.EqualTo("There was so very remarkable in ; nor did Alice cross so very much of way hear say ,"));
      }

   }
}
