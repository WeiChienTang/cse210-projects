using System;

class Program
{
    static void Main(string[] args)
    {
        int result = 0;
List<Goal> goals = new List<Goal>();
int totalPoint = 0;
string fileName;
int index = 1;

while (result != 6)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Menu Options:");
    Console.WriteLine(" 1. Create New Goal");
    Console.WriteLine(" 2. List Goals");
    Console.WriteLine(" 3. Save Goals");
    Console.WriteLine(" 4. Load Goals");
    Console.WriteLine(" 5. Record Event");
    Console.WriteLine(" 6. Quit");
    Console.Write("Select a choice from t he menu: ");

    try
    {
        result = int.Parse(Console.ReadLine());
        bool isDone = false;

        if (result > 0 && result < 7 && !isDone)
        {
            switch (result)
            {
                case 1:
                    while (!isDone)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("The types of Goals are:");
                        Console.WriteLine(" 1. Simple Goal");
                        Console.WriteLine(" 2. Eternal Goal");
                        Console.WriteLine(" 3. Checklist Goal");
                        Console.Write("Which Typeof goal would you like to create? ");
                        try
                        {
                            result = int.Parse(Console.ReadLine());
                            switch (result)
                            {
                                case 1:                 
                                    SimpleGoal simpleGoal = new SimpleGoal();
                                    simpleGoal.GoalQuestions();
                                    goals.Add(simpleGoal);
                                    break;
                                case 2:
                                    EternalGoal eternalGoal = new EternalGoal();
                                    eternalGoal.GoalQuestions();
                                    goals.Add(eternalGoal);
                                    break;
                                case 3:
                                    ChecklistGoal checklistGoal = new ChecklistGoal();
                                    checklistGoal.GoalQuestions();
                                    goals.Add(checklistGoal);
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Pleas type one number from 1 ~ 3.");
                                    break;
                            }
                            isDone = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n{ex.Message}\n");
                        }
                        Console.WriteLine($"\nYou have {totalPoint} points.\n");
                    }
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThe goals are:");
                    index = 1;
                    string X;
                    foreach (Goal g in goals)
                    {
                        X = " ";
                        if (g.goalType == "ChecklistGoal")
                        {
                            if((g as ChecklistGoal).times == (g as ChecklistGoal).currentCompleted)
                            {
                                X = "X";
                            }
                            Console.WriteLine($"{index}. [{X}] {g.name} ({g.description}) --- Current completed: {(g as ChecklistGoal).currentCompleted}/{(g as ChecklistGoal).times}");
                        }
                        else
                        {
                            if(g.goalType == "SimpleGoal")
                            {
                                if((g as SimpleGoal).isCompleted)
                                {
                                    X = "X";
                                }
                            }
                            Console.WriteLine($"{index}. [{X}] {g.name} ({g.description})");
                        }
                    }
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Write("What is the file name fro the goal file? ");
                    fileName = Console.ReadLine();
                    if(File.Exists($"./{fileName}"))
                    {
                        File.WriteAllText($"./{fileName}", string.Empty);
                        using (StreamWriter sw = new StreamWriter($"./{fileName}"))
                        {
                            sw.WriteLine(totalPoint);
                            foreach (Goal g in goals)
                            {
                                string goal = $"{g.goalType}:{g.name},{g.description},{g.points}";
                                if (g.goalType == "SimpleGoal")
                                {
                                    goal += $",{(g as SimpleGoal).isCompleted}";
                                }
                                else if (g.goalType == "ChecklistGoal")
                                {
                                    goal += $",{(g as ChecklistGoal).bonus},{(g as ChecklistGoal).times},{(g as ChecklistGoal).currentCompleted}";
                                }
                                sw.WriteLine(goal);
                            }
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText($"./{fileName}"))
                        {
                            sw.WriteLine(totalPoint);
                            foreach (Goal g in goals)
                            {
                                string goal = $"{g.goalType}:{g.name},{g.description},{g.points}";
                                if (g.goalType == "SimpleGoal")
                                {
                                    goal += $",{(g as SimpleGoal).isCompleted}";
                                }
                                else if (g.goalType == "ChecklistGoal")
                                {
                                    goal += $",{(g as ChecklistGoal).bonus},{(g as ChecklistGoal).times},{(g as ChecklistGoal).currentCompleted}";
                                }
                                sw.WriteLine(goal);
                            }
                        }
                    }

                    break;
                case 4:
                    Console.Write("What is the file name fro the goal file? ");
                    fileName = Console.ReadLine();
                    List<string> readFromFile = File.ReadAllLines($"./{fileName}").ToList();
                    goals.Clear();
                    bool isFirst = true;

                    foreach (string line in readFromFile)
                    {
                        if(isFirst)
                        {
                            totalPoint = int.Parse(line);
                            isFirst = false;
                        }
                        else
                        {
                            string getGoalType = line.Substring(0, line.IndexOf(':'));

                            if (getGoalType == "SimpleGoal")
                            {
                                string goal = line.Substring(line.IndexOf(':'), line.Length - line.IndexOf(':'));
                                List<string> final = goal.Split(',').ToList();
                                SimpleGoal g = new SimpleGoal();
                                g.name = final[0];
                                g.description = final[1];
                                g.points = int.Parse(final[2]);
                                g.isCompleted = bool.Parse(final[3]);
                                goals.Add(g);
                            }
                            else if (getGoalType == "EternalGoal")
                            {
                                string goal = line.Substring(line.IndexOf(':'), line.Length - line.IndexOf(':'));
                                List<string> final = goal.Split(',').ToList();
                                EternalGoal g = new EternalGoal();
                                g.name = final[0];
                                g.description = final[1];
                                g.points = int.Parse(final[2]);
                                goals.Add(g);
                            }
                            else if (getGoalType == "ChecklistGoal")
                            {
                                string goal = line.Substring(line.IndexOf(':'), line.Length - line.IndexOf(':'));
                                List<string> final = goal.Split(',').ToList();
                                ChecklistGoal g = new ChecklistGoal();
                                g.name = final[0];
                                g.description = final[1];
                                g.points = int.Parse(final[2]);
                                g.bonus = int.Parse(final[3]);
                                g.times = int.Parse(final[4]);
                                g.currentCompleted = int.Parse(final[5]);
                                goals.Add(g);
                            }
                        }
                    }
                    break;
                case 5:
                    index = 1;
                    int eventPoint = 0;
                    foreach (Goal g in goals)
                    {
                        Console.WriteLine($"{index}. {g.name}");
                        index++;
                    }
                    Console.Write("Which goal did you accomplish? ");
                    while (true)
                    {
                        try
                        {
                            int restul = int.Parse(Console.ReadLine());
                            totalPoint += goals[restul - 1].points;
                            eventPoint += goals[restul - 1].points;

                            if (goals[restul - 1].goalType == "SimpleGoal")
                            {
                                (goals[restul - 1] as SimpleGoal).isCompleted = true;
                            }

                            if (goals[restul - 1].goalType == "ChecklistGoal")
                            {
                                (goals[restul - 1] as ChecklistGoal).currentCompleted++;
                                if((goals[restul - 1] as ChecklistGoal).currentCompleted == (goals[restul - 1] as ChecklistGoal).times)
                                {
                                    totalPoint += (goals[restul - 1] as ChecklistGoal).bonus;
                                    eventPoint += goals[restul - 1].points;
                                }
                            }

                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    Console.WriteLine($"Congratulations! You have earned {eventPoint}!");
                    Console.WriteLine($"You now have {totalPoint} points.");

                    
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter 1 ~ 3");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    }
}
}