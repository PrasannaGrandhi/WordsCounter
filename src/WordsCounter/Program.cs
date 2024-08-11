using WordsCounter;

internal class Program
{
    private static void Main(string[] args)
    {
        string? inputFile = GetInputFile(args);

        if (IsValid(inputFile))
        {
            Lazy<TextFile> lazyTextFileProcessor = new(() => new TextFile(new WordFrequencyCounter(), inputFile));
            try
            {
                int count = lazyTextFileProcessor.Value.GetDistinctWordsCount();
                Print(count);

                Dictionary<string, int> wordCountDictionary = lazyTextFileProcessor.Value.ProcessDistinctWords();
                Print(wordCountDictionary);
            }
            catch
            {
                Console.WriteLine("\u001b[31m Something went wrong, please try again.\u001b[0m");
            }
        }
        Console.ReadKey();
    }
   
    private static string? GetInputFile(string[] args)
    {
        string? inputFile;
        if (args.Length > 0)
        {
            inputFile = args[0].Trim('"', '\'');
        }
        else
        {
            Console.WriteLine("Please provide the full file path, including the file name:");
            inputFile = Console.ReadLine()?.Trim('"', '\''); ;
        }

        return inputFile;
    }

    private static bool IsValid(string? inputFile)
    {
        if (File.Exists(inputFile))
        {
            if (Path.GetExtension(inputFile).Equals(".txt"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\u001b[31mApologies, but we currently support processing .txt files only. Please provide a .txt file.\u001b[0m");
            }
        }
        else
        {
            Console.WriteLine("\u001b[31File not found! Please verify the file path and try again.\u001b[0m");
        }
        return false;
    }

    private static void Print(int count)
    {
        Console.WriteLine($"\u001b[32mDistinct words : {count}\u001b[0m");
    }

    private static void Print(Dictionary<string, int> distinctWords)
    {
        var sortedDistinctWords = distinctWords.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
        Console.WriteLine("\u001b[33mWords used \u001b[0m");
        foreach (var word in sortedDistinctWords)
        {
            Console.WriteLine($"{word.Key} {word.Value}");
        }
    }
}