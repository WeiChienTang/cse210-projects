class KamDynSeller : INPC,INPCWeaponsMerchant
{
    public string Name => "Weapons Merchant";
    List<Weapon> weapons = new()
    {
        new Blade(),
        new Rapier(),
        new Scimitar(),
    };
    public void Sell()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"{Name}: Greetings, brave explorer! What specific gear are you" +
            $" in need of for your expedition?");
        ShowItem(); 

        Console.Write("Enter number : ");
        try
        {
            int answer = int.Parse(Console.ReadLine());

            if (weapons[answer-1] != null)
            {
                if(GameSystem.player.Money > weapons[answer - 1].Price)
                {
                    GameSystem.GetItemWeaponMessage(weapons[answer - 1]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** It appears that you have an insufficient amount of funds**");
                }
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Um .. I'm not sure if I have that.");
        }
    }
    void ShowItem()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        int index = 1;
        weapons = weapons.OrderBy(x => x.Price).ToList();
        weapons.ForEach(w =>
        {
            Console.WriteLine($"{index}. ▊ Name: {w.Name} ▊ ATK : {w.ATK_} ▊ DEF: {w.DEF_} ▊ Pirce: {w.Price}");
            index++;
        });
    }
}
