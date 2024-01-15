
C.A. TextFilter Console

Console application that given a text input file apply teh following filter

– Filter1 – filter out all the words that contains a vowel in the middle of the word – the centre 1 or 2 letters ("clean" middle is ‘e’, "what" middle is ‘ha’, "currently" middle is ‘e’ and should be filtered, "the", "rather" should not be)
– Filter2 – filter out words that have length less than 3
– Filter3 – filter out words that contains the letter ‘t’  - 

For Runnning test: dotnet test

Executable:
  CodeAssigment.TextFilterConsole.exe

parameters:
  [optional] -input  <FilePath> : input file path (default: input.txt )

