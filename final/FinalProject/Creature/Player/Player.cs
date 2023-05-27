internal class Player : ICreature
{
    public Player(string name)
    {
        Name = name;
        Money = 40;
        HP = 70;
        SP = 14;
        FullHP = HP;
        FullSP = SP;
        ATK = 7;
        DEF = 2;
        Level = 1;

        skills.Add(new Bash(this));
    }

    public string Name { get; set; }
    public int Level { get; set; }
    public int Money { get; set; }
    public double HP { get; set; }
    public double FullHP { get; set; }
    public double SP { get; set; }
    public double FullSP { get; set; }
    public double EXP { get; set; }
    public string CurrentLocation { get; set; }
    public double ATK { get; set; }
    public double DEF { get; set; }
    public Weapon weapon { get; set; }
    public Armor armor { get; set; }
    public List<Skill> skills = new List<Skill>();
}