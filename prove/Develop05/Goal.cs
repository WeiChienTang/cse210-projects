class Goal
{
    public Goal()
    {
        goalType = GetType().Name;
    }

    public string goalType { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int points { get; set; }

    public virtual void GoalQuestions()
    {
        Console.Write("What is the name of your goal? ");
        name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        points = int.Parse(Console.ReadLine());  
    }
}