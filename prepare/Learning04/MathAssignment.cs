class MathAssignment : Assignment
{
    public MathAssignment(string textbookSection, string problems,string studentName,string topic) : base (studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    string _textbookSection { get; set; }    
    string _problems { get; set; }    

    public string GetHomeworkList()
    {
        string result = GetSummary();
        return $"{result}\nSection {_textbookSection} Problems {_problems}";
    }
}