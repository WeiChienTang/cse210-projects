class Assignment
{
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    protected string _studentName { get; set; }
    protected string _topic { get; set; }
    protected string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}