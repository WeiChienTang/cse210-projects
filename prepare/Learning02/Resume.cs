class Resume
{
    public string _name { get; set; }
    public List<Job> jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs:");
        jobs.ForEach(j =>
        {
            Console.WriteLine($"{j._jobTitle} ({j._company}) {j._startYear}-{j._endYear}");
        });
    }
}