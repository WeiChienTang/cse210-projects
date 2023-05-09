using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment MathAssignment = new MathAssignment(textbookSection: "7.3",problems: "8-19",studentName: "Roberto Rodriguez",topic: "Fractions");
        WritingAssignment writingAssignment = new WritingAssignment(title: "The Causes of World War II by Mary Waters", studentName: "Mary Waters", topic: "European History");

        Console.WriteLine(MathAssignment.GetHomeworkList());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}