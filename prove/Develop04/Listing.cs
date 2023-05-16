class Listing : Activity
{
    public void StartActivity()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Welcome to the Listing Activity.");
        Console.WriteLine("");
        Console.WriteLine("This activity will help you relax on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("");

        SetTime();
        listen();
    }

    void listen()
    {
        GetReady();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        List<string> ListingQuestion = GetListingQuestion();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"--- {ListingQuestion[new Random().Next(ListingQuestion.Count())]} ---");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("You may begin in: ");
        DisplayTime(5);        

        Console.WriteLine("> ");
        List<string> answer = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(time);       

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            answer.Add(Console.ReadLine());
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You listed {answer.Count()} items!");
        ShowWellDone(time: time, activityName: "listening");
    }

    List<string> GetListingQuestion()
    {
        List<string> result = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
        };

        return result;
    }
}