class ChecklistGoal : Goal
{
    public int times { get; set; }
    public int bonus { get; set; }
    public int currentCompleted { get; set; }

    public override void GoalQuestions()
    {
        base.GoalQuestions();
        Console.Write("How many times dpes this goal need to be accomlished for a bouns? ");
        times = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomlishing it that many times? ");
        bonus = int.Parse(Console.ReadLine());
        currentCompleted = 0;
    }
}