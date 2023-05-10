class Reflecting : Activity
{
    public void StartActivity()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Welcome to the Reflecting Activity.");
        Console.WriteLine("");
        Console.WriteLine("This activity will help you reflect on times in your life wheb you have shown strength and resilience. This will" +
            "help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine("");

        SetTime();

        Reflect();
    }

    void Reflect()
    {
        List<string> ReflectQuestion = GetReflectingQuestion();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"--- {ReflectQuestion[new Random().Next(ReflectQuestion.Count())]} ---");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        DisplayTime(5);

        Console.Clear();
        List<string> PonderingQuestion = GetPonderingQuestion();

        DateTime endTime = DateTime.Now.AddSeconds(time);
        Console.ForegroundColor = ConsoleColor.White;

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {PonderingQuestion[new Random().Next(PonderingQuestion.Count())]} ");
            DisPlayAnimation(12);
            Console.WriteLine();
        }

        ShowWellDone(time: time, activityName: "Reflecting");
    }

    List<string> GetReflectingQuestion()
    {
        List<string> result = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
        };

        return result;
    }
    List<string> GetPonderingQuestion()
    {
        List<string> result = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        };

        return result;
    }
}