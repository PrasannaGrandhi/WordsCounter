# WordsCounter
I developed a WordsCounter Console application to meet the requirement of reading a text file, counting distinct words, and providing a frequency count for each word. 
To efficiently handle large text files, I incorporated lazy loading and parallel processing techniques, ensuring optimal performance even with arbitrarily large file sizes.

**Project Framework:** .NET 8

**Installation**
Clone the repository: 
`git clone https://github.com/yourusername/WordsCounter.git`

Navigate to the project directory:
`cd .\src\WordsCounter`

Build the project:
`dotnet build`

**How to Run**

Goto cloned solution folder and run below commands
  - `cd ".\src\WordsCounter"`
  - Run the application with the path to the text file as an argument:
      `dotnet run -- "path/to/your/textfile.txt"`

Alternatively, you can run the application(**WordsCounter.exe** from bin folder) and provide the file path when prompted.

The application will output the count of distinct words and the frequency of each word.


