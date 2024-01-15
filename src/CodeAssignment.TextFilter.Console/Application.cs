namespace CodeAssigment.TextFilterConsole
{
   using CodeAssignment.TextFilter.Contract;

   public class Application : IDisposable
   {
      public IList<ITextFilter> Filters { get; } 

      public Application(IList<ITextFilter> filter) {
         Filters = filter;
      }

      public string RunApplyFiltersToTextFile(string textFilePath)
      {
         if (string.IsNullOrEmpty(textFilePath) || !File.Exists(textFilePath))
            throw new Exception($"Cannot read the File [{textFilePath}]");

         string inputText = File.ReadAllText(textFilePath);

         string outputtext = inputText;

         foreach (ITextFilter filter in Filters)
         {
            outputtext = filter.FilterTextAsync(outputtext).Result;
         }

         return outputtext;
      }

      public void Dispose()
      {
         Filters.Clear();
      }
   }
}
