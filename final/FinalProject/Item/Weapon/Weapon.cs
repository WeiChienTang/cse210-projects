class Weapon : IItem, IATK, IDEF
{
    public Weapon()
    {
        Name = GetType().Name;
    }
    public string Name { get; set; }
    public int ATK_ { get; set; }
    public int DEF_ { get; set; }
    public int Price { get; set; }
}