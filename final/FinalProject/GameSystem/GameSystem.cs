sealed class GameSystem
{
    public static Player? player { set; get; }
    public static bool IsWeirdGuyEventEnd = false;
    public static void CheckCommand(string input)
    {
        switch(input.ToLower())
        {
            case "-sta":
                ShowState();
                break;
            case "-map":
                ShowMap();
                break;
            case "-cl":
                Clear();
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Can't fint 【{input}】 this command.");
                break;
        }
    }

    static void Clear()
    {
        Console.Clear();
    }
    static void ShowMap()
    {
        List<string> map = new()
        {
            "----------------------------------------------------------------------------------------------------",
            "| █████████████████████                                                           ████████████████ |",
            "| █ ════════ ███████████                 Black Forest                                  ███████████ |",
            "| █  KamDyn  ██████████                                                        ███████████████████ |",
            "| █ ════════ █████████████                                             ███████████████████████████ |",
            "| █████  ████████████████   ████                                     █████████████████████████████ |",
            "| ██████  █████████████   ██████████████████████████████████████  ████████████████████████████████ |",
            "| ███████  ██████████   █████████~~~~~~~~~~~~~~~~~~~~~~~~~~█████  ████████████████████████████████ |",
            "| ████████  ████████   █████████~     Lake Mbakaou        ~██████   ██████████████████████████████ |",
            "| ██████╔═════════════╗███████~           ████████       ~████████  ██████████████████████████████ |",
            "| ██████  ██ ═════ ██  ██████████~         ██????██     ~██████████   ████████████████████████████ |",
            "| ██████  ██ ═════ ██  ████████████~         █████        ~██████████   ██████████████████████████ |",
            "| ██████  █ Paxtun  █  ████████████~~~~~~~~            ~██████████████   █████████████████████████ |",
            "| ██████  ███████████         ████████████~~~~~~~~  ~██████████████████  █████████████████████████ |",
            "| ██████╚═════════════╝███████   ██████████████████~~~~~█████████████████             ████████████ |",
            "| ██████████████████████████████   ████ ═══ ███████████████████████████████████╔═════════╗████████ |",
            "| ████████████████████████████████   ██ ═══ ██ Slyborn ████████████████████████  ███████  ████████ |",
            "| ^^████████████████████████████████    ═══ ███████████████████████████████████  ███████  ████████ |",
            "| ██^^██^^██^^█████████████████████████ ═══        █████████████████╔═══════════ ███████  ████████ |",
            "| ████^^██^^██^^███████████████████████ ═══ █████         ██████████  ██████████████████  ████████ |",
            "| ██████████████^^██████████████████████   ████████████               ██████████████████  ████████ |",
            "| ████████████████^^███████████████████   ██████████████████████████  ████████ Odes ████  ████████ |",
            "| ██████████████████^^^█████████████    ██████████ *** █████████████  ██████████████████  ████████ |",
            "| █████████████████████                ███████████* ? *█████████████  ██████████████████  ████████ |",
            "| ███ Mount MoLa ███████^^████████████████████████ *** █████████████╚════════════════════╝████████ |",
            "| ███████████████████████^^███████████████████████████████████████████████████████████████████████ |",
            "| ████████████████████████^^^█████████████████████████████████████████████████████████████████████ |",                    
            "----------------------------------------------------------------------------------------------------",                  
        };

        map.ForEach(m =>
        {
            Console.WriteLine(m);
        });
    }

    static void ShowState()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string line = "";
        for(int l = 0;l < 40;l++)
        {
            line += "-";
        }
        Console.WriteLine($"\n    {line}");
        Console.WriteLine(StateLength("Name",player.Name));
        Console.WriteLine(StateLength("Money",player.Money));
        Console.WriteLine($"    {line}");
        Console.WriteLine(StateLength("HP", player.HP));
        Console.WriteLine(StateLength("SP", player.SP));
        Console.WriteLine(StateLength("ATK", player.ATK));
        Console.WriteLine(StateLength("DEF", player.DEF));
        Console.WriteLine(StateLength("Weapon", player.weapon));
        Console.WriteLine(StateLength("Armor", player.armor));
        Console.WriteLine($"    {line}\n");
    }

    static string StateLength<T>(string title,T contend)
    {
        return $"   |   {title}: {contend}".PadRight(39) + "|";
    }

    public static void RandomConverSation()
    {
        List<string> conversations = new()
        {
            "What are your hobbies or interests?",
            "Have you traveled anywhere interesting recently?",
            "What is your favorite book or movie, and why?",
            "How do you like to spend your weekends?",
            "What is the most memorable concert or live performance you've attended? ",
            "Do you have any pets? Tell me about them.",
            "What is your favorite cuisine or type of food?",
            "Are you a morning person or a night owl?",
            "What is something you've always wanted to learn or try but haven't yet?",
            "Do you prefer city life or living in the countryside?",
            "What is your favorite quote or motto that inspires you?",
            "Do you have any hidden talents or skills?",
            "What is the best piece of advice you've ever received?",
            "Do you have a favorite sport or athletic activity?",
            "What is your preferred form of exercise or fitness routine?",
            "Have you ever had any interesting or unusual jobs in the past?",
            "Do you enjoy any specific forms of art, such as painting or sculpting?",
            "What is your favorite way to unwind after a long day?",
            "If you could have one superpower, what would it be and how would you use it ?",
            "You are enough just as you are.",
            "You have the strength to face any obstacles.",
            "You have the capacity for forgiveness and healing.",
            "You have a bright future ahead of you",
            "You are surrounded by love and support.",
            "You are capable of creating meaningful relationships.",
            "You have the capacity to bring joy to others.",
            "Are you familiar with the existence of a land situated in the midst of Lake Mbakaou?",
            "I wish I could visit the enchanting Black Forest.",
            "However, I am in need of a reliable weapon.",
            "What are your thoughts on this place?",
            "I have heard about a modest place near the city of Odes. I'm curious if I can locate it.",
        };

        List<string> names = new()
        {
            "Liam",
            "Olivia",
            "Noah",
            "Emma",
            "William",
            "Ava",
            "James",
            "Isabella",
            "Oliver",
            "Sophia",
            "Benjamin",
            "Mia",
            "Elijah",
            "Charlotte",
            "Lucas",
            "Amelia",
            "Henry",
            "Harper",
            "Alexander",
            "Evelyn",
            "Samuel",
            "Abigail",
            "Matthew",
            "Emily",
            "Joseph",
            "Elizabeth",
            "Daniel",
            "Sofia",
            "Michael",
            "Grace",
        };

        Console.ForegroundColor = ConsoleColor.Blue;
        int randConversation = new Random().Next(conversations.Count-1);
        int randName = new Random().Next(names.Count-1);
        Console.WriteLine($"\n{names[randName]}: {conversations[randConversation]}\n");
    }

    public static void NoticeMeassage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string content = "Press enter to continue..";
    
        content = MakeBorder(content);

        string line = "";
        for (int l = 0; l < content.Length; l++)
        {
            line += "-";
        }

        Console.WriteLine($"{line}\n{content}\n{line}");
    }
    static string MakeBorder(string contend)
    {
        return $"|  {contend} |";
    }

    public static void Resting()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nRoom Attendant: The price for a comfortable stay is " +
            "【10 $】. Are you interested in reserving a room? ");
        Console.Write("yes/no : ");

        string answer = Console.ReadLine();

        if(answer.ToLower() == "yes" )
        {
            if(player.Money > 10)
            {
                player.Money = -10;
                player.HP = player.FullHP;
                player.SP = player.FullSP;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou have a good rest..");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Room Attendant: I apologize, but it seems you don't have enough funds to " +
                    "cover the cost.\"");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nRoom Attendant: No worries.");
        }
    }

    public static void EventMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string content = "*** EVENT ***";

        content = MakeBorder(content);

        string line = "";
        for (int l = 0; l < content.Length; l++)
        {
            line += "-";
        }

        Console.WriteLine($"{line}\n{content}\n{line}");
    }
    public static void SpendMoneyMessage(int money)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string content = $"You have spend {money}$";

        content = MakeBorder(content);
        string line = "";
        for (int l = 0; l < content.Length; l++)
        {
            line += "-";
        }

        Console.WriteLine($"{line}\n{content}\n{line}");
    }
    public static void GetItemWeaponMessage(Weapon item)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        string content = item.Name;

        content = MakeBorder(content);
        string line = "";
        for (int l = 0; l < content.Length; l++)
        {
            line += "-";
        }

        Console.WriteLine($"{line}\n{content}\n{line}");

        if(player.weapon != null)
        {
            player.ATK -= player.weapon.ATK_;
            player.DEF -= player.weapon.DEF_;
        }

        player.weapon = item;
        player.ATK += item.ATK_;
        player.DEF += item.DEF_;
    }

    /// <summary>
    /// Chceck if the new weapon's ATK is higher then the old one
    /// </summary>
    /// <param name="newWeapn"></param>
    public static void CheckWeapon(Weapon newWeapon)
    {
        if(player.weapon.ATK_ < newWeapon.ATK_)
        {
            player.weapon = newWeapon;
        }
    }
    public static void CheckArmor(Armor newArmor)
    {
        if (player.armor.DEF_ < newArmor.ATK_)
        {
            player.armor = newArmor;
        }
    }
}