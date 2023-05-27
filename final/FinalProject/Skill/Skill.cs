class Skill : ISkil
{
    public Skill(ICreature creature)
    {
        Name = GetType().Name;
    }

    public string Name { get; set; }
    public double Damage { get; set; }
    public double CastSP { get; set; }
    public double CastHP { get; set; }
}
