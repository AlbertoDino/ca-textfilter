namespace CodeAssignment.TextFilter.Contract
{

   public interface ITextFilter
   {
      Task<string> FilterTextAsync(string text);
   }
}
