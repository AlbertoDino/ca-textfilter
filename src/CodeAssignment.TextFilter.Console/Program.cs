
namespace CodeAssigment.TextFilterConsole
{
   using CodeAssignment.TextFilter.Contract;
   using CodeAssignment.TextFilter.Filters.English;
   using System;

   class Program
   {
      /// <summary>
      /// TextFilter Console App
      /// </summary>
      /// <param name="args">
      /// -input  <FilePath> : (default: input.txt ), input file path
      /// </param>
      static void Main(string[] args)
      {

         try
         {
            var inputFile = GetInputFileFromArgument(args);

            IList<ITextFilter> filters = new List<ITextFilter>() {
               new FilterOutMiddleVowelWords(),
               new FilterOutOWordsContainsLowerT(),
               new FilterOutWordsLessThanThree() };

            using (Application app = new Application(filters))
            {
               var output = app.RunApplyFiltersToTextFile(inputFile);
               Console.WriteLine(output);
            }

            Console.ReadLine();

         }
         catch (Exception e)
         {
            Console.WriteLine($"Exception: {e.ToString()}");
         }

         return;
      }

      private static string GetInputFileFromArgument(string[] args)
      {

         string inputFile = "input.txt";

            if (args.Length == 2)
               for (int i = 0; i < args.Length; i++)
                  if (args[i] == "-input") inputFile = args[i + 1];

         return inputFile;
      }
   }
}