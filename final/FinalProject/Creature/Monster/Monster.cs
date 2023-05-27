class Monster : ICreature
{
    public Monster()
    {
        Name = GetType().Name;
    }
    public string Name { get; set; }
    public double HP { get; set; }
    public double SP { get; set; }
    public double ATK { get; set; }
    public double DEF { get; set; }
    public double EXP { get; set; }
    public List<Skill> skils { get; set; }
    public double FullHP { get; set; }
    public double FullSP { get; set; }
}
