class WritingAssignment : Assignment
{
    public WritingAssignment(string title, string studentName, string topic) : base(studentName, topic)
    {
        _title = title;
    }
    string _title { get; set; }

    public string GetWritingInformation()
    {
        string result = GetSummary();
        return $"{result}\n{_title}";
    }
}