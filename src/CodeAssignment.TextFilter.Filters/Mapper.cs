namespace CodeAssignment.TextFilter.Filters.English
{
   using System.Collections.Generic;
   using System.Linq;
   using System.Text.RegularExpressions;

   public static class WordMapper
   {
      public static readonly List<string> Separators = new List<string>() { ",", ".", " ", ":", "#", ";", "?", "!", "'", "\"", "(", ")", "[", "]", "{", "}" };
      public static readonly List<string> Vowel = new List<string>() { "a", "e", "i", "o", "u", "y" };

      public static string GetMiddleOfWord(string word)
      {
         if (string.IsNullOrEmpty(word))
            return string.Empty;

         if ((word.Length % 2) == 1)
            return word.Substring((word.Length - 1) / 2, 1);
         else
            return word.Substring((word.Length - 1) / 2, 2);
      }

      public static bool ContainsAVowel(string word)
      {
         return word.Any(x => Vowel.Contains($"{x}"));
      }

      public static bool ContainsLowerT(string word)
      {
         return word.Contains("t");
      }

      public static bool LengthLessThanThree(string word)
      {
         return word.Length < 3;
      }


      /// <summary>
      /// This function takes a text and the replace the whole word considering bounderies with a new value
      /// </summary>
      public static string ReplaceWholeWord(string text, string word, string newword) =>  Regex.Replace(text, $@"\b{word}\b", newword);

      /// <summary>
      /// This function replace multiple consecutive whitespaces into one 
      /// </summary>
      public static string FormatToOneWhiteSpaces(string text) => Regex.Replace(text, @"\s+", " ");
      
   }
}
