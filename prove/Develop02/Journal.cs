class Journal
{
    public string FileName { get; set; }
    public List<string> StoredAnswer = new List<string>();
    List<string> question = PromptGenerator.GetPromptQuestion();

    /// <summary>
    /// First, Get the Prompt Question from the PromptGenerator.GetPromptQuestion(). Then, users can write whatever they want and save it into the List<string> StoredAnswer.
    /// </summary>
    public void Writ()
    {
        Random r = new Random();
        int randomQuestion = r.Next(question.Count - 1);
        Console.WriteLine(question[randomQuestion]);
        StoredAnswer.Add($"Date: {DateTime.Now}\nQuestion: {question[randomQuestion]}\nAnswer: {Console.ReadLine()}\n");
    }
    /// <summary>
    /// Display the content in the file and List<string> StoredAnswer.
    /// </summary>
    public void Display()
    {
        StoredAnswer.ToList().ForEach(answer =>
        {
            Console.WriteLine(answer);
        });
    }
    /// <summary>
    /// Ask the user about the file name and save it to .txt format.
    /// </summary>
    public void Save()
    {
        Console.Write("File name : ");
        FileName = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(FileName + ".txt"))
        {
            sw.Write("");
            StoredAnswer.ForEach(answer =>
            {
                sw.WriteLine(answer);
            });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Save!\n");
        }
    }
    /// <summary>
    /// Ask the file name the user would like to load. If the file exists, then load. If not showing the wrong message.
    /// </summary>
    public void Load()
    {
        Console.Write("File name : ");
        FileName = Console.ReadLine();

        if (File.Exists(FileName + ".txt"))
        {
            using (StreamReader sw = new StreamReader(FileName + ".txt"))
            {
                while (!sw.EndOfStream)
                {
                    StoredAnswer.Add(sw.ReadLine());
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have loaded the file {FileName}.txt\n");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Can't find {FileName}.txt file\n");
        }
    }
    /// <summary>
    /// Exit the application.
    /// </summary>
    public void Quit()
    {
        Environment.Exit(0);
    }

    public void Delete()
    {
        Console.Write("File name : ");
        FileName = Console.ReadLine();

        if (File.Exists(FileName + ".txt"))
        {
            File.Delete(FileName + ".txt");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have deleted the {FileName}.txt file.\n");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Can't find {FileName}.txt file\n");
        }
    }
}