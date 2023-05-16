class Activity
{
    protected int time;
    protected void GetReady()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Get ready... ");
        DisPlayAnimation(2);
        Console.WriteLine();
    }

    protected void SetTime()
    {
        Console.Write("How long, in second, would you like for your session? ");

        try
        {
            time = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
        }
    }

    protected void DisPlayAnimation(int second)
    {
        List<string> result = new List<string>()
        {
            "\\",
            "|",
            "/",
            "-",
        };

        int index = 0;
        DateTime endTime = DateTime.Now.AddSeconds(second);

        while (DateTime.Now < endTime)
        {
            Console.Write(result[index]);
            Thread.Sleep(300);
            Console.Write("\b \b");

            index++;

            if (index >= result.Count())
            {
                index = 0;
            }
        }
    }

    protected void DisplayTime(int time)
    {
        for (; time != 0; time--)
        {
            Console.Write(time);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void ShowWellDone(int time, string activityName)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Well done!!");
        Console.ForegroundColor = ConsoleColor.White;
        DisPlayAnimation(4);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You have completed another {time} seconds of the {activityName} Activity.");
        Console.ForegroundColor = ConsoleColor.White;
        DisPlayAnimation(4);
    }
}