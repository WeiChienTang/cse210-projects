class Armor : IItem, IATK, IDEF
{
    public string Name { get; set; }
    public int ATK_ { get; set; }
    public int DEF_ { get; set; }

    public void AddATK()
    {
        GameSystem.player.ATK += ATK_;
    }
    public void AddDEF()
    {
        GameSystem.player.DEF += DEF_;
    }
}