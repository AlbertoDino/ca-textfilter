

namespace CodeAssignment.TextFilter.Filters.English
{
   using CodeAssignment.TextFilter.Contract;
   using System;
   using System.Linq;
   using System.Threading.Tasks;

   /// <summary>
   /// This class filter out words that have length less than 3
   /// </summary>
   public class FilterOutWordsLessThanThree : ITextFilter
   {

      public Task<string> FilterTextAsync(string text)
      {
         var words = text.Split(WordMapper.Separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

         var wordsLessThanThree= words.Where(w => WordMapper.LengthLessThanThree(w));

         foreach (var wordToFilter in wordsLessThanThree)
         {
            text = WordMapper.ReplaceWholeWord(text, wordToFilter, string.Empty);
         }

         string result = WordMapper.FormatToOneWhiteSpaces(text);
         return Task.FromResult(result);
      }
   }
}
