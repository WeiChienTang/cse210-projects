class BasciMAP : IPlace
{    
    public string Name => GetType().Name;

    protected List<INPC> NPCs = new();
    protected List<BasciMAP> places = new();
    protected INPCWeaponsMerchant NPCWeaponsMerchant;
    protected List<Monster> monsters = new();
    protected void ShowCommandInformation()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("【-sta】 Show player states.");
        Console.WriteLine("【-map】 Show the map.");
        Console.WriteLine("【-cl】 Clear contents.");
    }
    public void ShowWelcome()
    {
        Console.Clear();
        ShowCommandInformation();
        Console.ForegroundColor = ConsoleColor.Yellow;
        string welcome = $"| Welcome to {Name} |";
        string line = "";

        for (int l = 0; l < welcome.Length; l++)
        {
            line += "-";
        }

        Console.WriteLine($"    {line}\n    {welcome}\n    {line}");
    }
    /// <summary>
    /// Adding the NPC to List<NPC>
    /// </summary>
    protected virtual void SetNPC()
    {

    }
    /// <summary>
    /// Adding the NPC to List<IPlace>
    /// </summary>
    protected virtual void SetPlace()
    {

    }
    /// <summary>
    /// Adding the NPC to List<IPlace>
    /// </summary>
    protected virtual void SetWeaponsMerchant()
    {

    }
    /// <summary>
    /// Adding the NPC to List<IPlace>
    /// </summary>
    protected virtual void SetMonsters()
    {

    }

    bool isFirstTime = true;
    BasciMAP place = null;
    public virtual BasciMAP ShowDos()
    {
        // To prevent keep adding new NPC and Place
        if (isFirstTime)
        {
            SetNPC();
            SetPlace();
            SetWeaponsMerchant();
            SetMonsters();
            isFirstTime = false;
        }

        // The program will continue looping until the player decides to go to a new location.
        while (place == null)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" \nWhat would you like to do?");
            Console.WriteLine("     1. Go to other place");
            Console.WriteLine("     2. Talk to people");
            Console.WriteLine("     3. Buy Equipment ");
            Console.WriteLine("     4. XP farming");
            Console.WriteLine("     5. Rest");
            Console.Write(" : ");

            string? result = Console.ReadLine();

            try
            {
                int toNumber;
                if (int.TryParse(result, out toNumber))
                {
                    Decision(toNumber);
                }
                else
                {
                    GameSystem.CheckCommand(result);
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }

        return place;
    }

    protected virtual void Decision(int result)
    {
        switch (result)
        {
            case 1:
                GoOtherPlace();
                break;
            case 2:
                TalkToVillagers();
                break;
            case 3:
                BuyEquipment();
                break;
            case 4:
                XPFarming();
                break;
            case 5:
                Rest();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{result} is not in the options.");
                break;
        }
    }
    protected virtual void XPFarming()
    {
        int rand = new Random().Next(1,6);
        Monster m = monsters[new Random().Next(monsters.Count()-1)];
        Thread.Sleep(150);
        // Fight
        if(rand == 3 || rand == 2)
        {
            GameSystemCombat.Combat(m);
        }
        // Find money
        else if (rand == 4)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int money = new Random().Next(1,4);
            Console.WriteLine($"        \nYou found {money}$ on the ground!!");
            GameSystem.player.Money += money;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("     \nYou didn't encounter anything..");
        }
    }
    protected virtual void TalkToVillagers()
    {
        GameSystem.RandomConverSation();
    }
    protected virtual void GoOtherPlace()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        int index = 1;
        int result = -1;
        Console.WriteLine();
        foreach (IPlace p in places)
        {
            Console.WriteLine($"{index}. {p.Name}");
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Where would you like to go? ");

        try
        {
            result = int.Parse(Console.ReadLine());

            if (places[result - 1] != null)
            {
                place = places[result - 1];
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Can't find this place.");
        }
    }
    protected virtual void Rest()
    {
        GameSystem.Resting();
    }
    protected virtual void BuyEquipment()
    {
        if (NPCWeaponsMerchant != null)
        {
            NPCWeaponsMerchant.Sell();
        }    
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n** There are currently no merchants here. **");
        }
    }
}