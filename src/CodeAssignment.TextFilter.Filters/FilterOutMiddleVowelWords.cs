namespace CodeAssignment.TextFilter.Filters.English
{
   using CodeAssignment.TextFilter.Contract;
   using System.Linq;
   using System.Threading.Tasks;


   /// <summary>
   /// This class filter out all the words that contains a vowel in the middle of the word – the centre 1 or 2 letters ("clean" middle is ‘e’, "what" middle is ‘ha’, "currently" middle is ‘e’ and should be filtered, "the", "rather" should not be)
   /// </summary>
   public class FilterOutMiddleVowelWords : ITextFilter
   {

      public Task<string> FilterTextAsync(string text)
      {
         var words = text.Split(WordMapper.Separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
         var vowalWords = words.Where(w => WordMapper.ContainsAVowel(WordMapper.GetMiddleOfWord(w.ToLower())));
         
         foreach (var wordToFilter in vowalWords)
         {
            text = WordMapper.ReplaceWholeWord(text, wordToFilter, string.Empty);
         }

         string result = WordMapper.FormatToOneWhiteSpaces(text);
         return Task.FromResult(result);
      }
   }
}
