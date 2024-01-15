namespace CodeAssignment.TextFilter.Filters.English
{
   using CodeAssignment.TextFilter.Contract;
   using System;
   using System.Linq;
   using System.Threading.Tasks;

   /// <summary>
   /// This class filter out words that contains the letter ‘t’
   /// </summary>
   public class FilterOutOWordsContainsLowerT : ITextFilter
   {
      public Task<string> FilterTextAsync(string text)
      {
         var words = text.Split(WordMapper.Separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

         var wordsWithT = words.Where(w => WordMapper.ContainsLowerT(w));

         
         foreach (var wordToFilter in wordsWithT)
         {
            text = WordMapper.ReplaceWholeWord(text, wordToFilter,string.Empty);
         }

         string result = WordMapper.FormatToOneWhiteSpaces(text);
         return Task.FromResult(result);

      }
   }
}
