class Breathing : Activity
{
    public void StartActivity()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Welcome to the Breathing Activity.");
        Console.WriteLine("");
        Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine("");

        SetTime();

        Breath();
    }

    void Breath()
    {
        GetReady();

        DateTime endTime = DateTime.Now.AddSeconds(time);
        Console.ForegroundColor = ConsoleColor.White;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write($"Breath in...");
            DisplayTime(4);
            Console.WriteLine("");
            Console.Write($"Breath out...");
            DisplayTime(6);
            Console.WriteLine();
        }

        ShowWellDone(time: time,activityName: "breathing");
    }
}