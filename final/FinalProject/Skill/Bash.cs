class Bash : Skill
{
    public Bash(ICreature creature) : base(creature)
    {
        Damage = Math.Round((creature.ATK * 0.5) + 10);
        CastSP = 5;
        CastHP = 0;
    }
}