class SimpleGoal : Goal
{
    public bool isCompleted { get; set; }

    public override void GoalQuestions()
    {
        base.GoalQuestions();
        isCompleted = false;
    }
}