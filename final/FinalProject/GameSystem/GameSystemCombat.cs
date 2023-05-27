

sealed class GameSystemCombat
{
    static Monster monster;

    public static void Combat(Monster monster_)
    {
        monster = monster_;
        Console.Clear();
        //ShowMonsterState();
        StartFight();
    }

    static void StartFight()
    {
        bool isBattleEnd = false;

        while (!isBattleEnd)
        {
            ShowEncounterMessage();
            Console.ForegroundColor = ConsoleColor.Yellow;
            ShowHPAndSp(GameSystem.player);

            Console.ForegroundColor = ConsoleColor.Magenta;
            ShowHPAndSp(monster);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\n 1. Attack 2. Skill 3. Run : ");
            // Player Round
            try
            {
                int result = int.Parse(Console.ReadLine());
                switch(result)
                {
                    case 1:
                        isBattleEnd = PlayerAttack();
                        break;
                    case 2:
                        isBattleEnd = Skill();
                        break;
                    case 3:
                        isBattleEnd = Run();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{result} is not on the options.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            // Monster Round
            if (monster.skils != null)
            {
                int skill = new Random().Next(10);
            }
        }
    }
    static void ShowHPAndSp(ICreature creature)
    {
        string line = "";
        for (int l = 0; l < 35; l++)
        {
            line += "-";
        }
        int index = 1;
        Console.WriteLine($"\n    {line}");
        Console.WriteLine(StateLength($"Name: ", creature.Name));
        Console.WriteLine(StateLength($"", $"HP: {creature.HP}/{creature.FullHP}  SP: {creature.SP}/{creature.FullSP}"));
        Console.WriteLine(StateLength($"",$"ATK: {creature.ATK} DEF: {creature.DEF}"));
        Console.WriteLine($"    {line}\n");
    }

    /// <summary>
    /// Attack without skill
    /// </summary>
    static bool PlayerAttack()
    {
        bool isMonsterDie = false;
        Console.Write($"You attack {monster.Name}. {monster.Name} lost ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{GameSystem.player.ATK - monster.DEF}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" HP.");
        monster.HP -= (GameSystem.player.ATK - monster.DEF);
        isMonsterDie = IsMonsterDie();
        return isMonsterDie;
    }
    /// <summary>
    /// Attack without skill
    /// </summary>
    static bool MonsterAttack()
    {
        bool isPlayerDie = false;

        Console.Write($"{monster.Name} attack you. you lost ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{monster.ATK - GameSystem.player.DEF}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" HP.");
        GameSystem.player.HP -= (monster.ATK - GameSystem.player.DEF);
        isPlayerDie = IsPlayerDie();

        return isPlayerDie;
    }
    /// <summary>
    /// Attack with skill
    /// </summary>
    static bool MonsterAttack(Skill s)
    {
        bool isPlayerDie = false;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{monster.Name} use skill ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"【{s.Name.ToUpper()}】!!");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" !!");
        Console.WriteLine();

        Console.Write($"{monster.Name} attack you. you lost ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{monster.ATK - GameSystem.player.DEF}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" HP.");

        GameSystem.player.HP -= (s.Damage + monster.ATK - GameSystem.player.DEF);
        monster.SP -= s.CastSP;

        isPlayerDie = IsPlayerDie();

        return isPlayerDie;
    }
    /// <summary>
    /// Attack with skill
    /// </summary>
    static bool PlayerAttack(Skill s)
    {
        bool isMonsterDie = false;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"You use skill ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"【{s.Name.ToUpper()}】!!");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(" !!");
        Console.WriteLine();
        Console.Write($"You attack {monster.Name}. {monster.Name} lost ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{s.Damage + GameSystem.player.ATK - monster.DEF}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($" HP.");

        monster.HP -= (s.Damage + GameSystem.player.ATK - monster.DEF);
        GameSystem.player.SP -= s.CastSP;
        isMonsterDie = MonsterLostHP();

        return isMonsterDie;
    }

    static bool IsPlayerDie()
    {
        bool isDie = false;

        if (monster.HP < 0)
        {
            isDie = true;
        }
        return isDie;
    }

    static bool IsMonsterDie()
    {
        bool isDie = false;

        if(monster.HP < 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n\n{monster.Name} is dead, you gain ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"【{monster.EXP}】");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" experience!");
            Console.WriteLine();
            isDie = true;
        }
        return isDie;
    }
    static bool MonsterLostHP()
    {
        bool isHPLowerThanZero = false;

        if (monster.HP < 0)
        {
            isHPLowerThanZero = true;
        }

        return isHPLowerThanZero;
    }

    static void PlayerLostHP()
    {
        Console.WriteLine($"{monster.Name} attacks You cost {monster.ATK - GameSystem.player.DEF} damage." +
                $" You lost {GameSystem.player.HP -= (monster.ATK - GameSystem.player.DEF)} HP.");
        GameSystem.player.HP -= (monster.ATK - GameSystem.player.DEF);

        if (GameSystem.player.HP < 0)
        {
            Die();
        }
    }
    static void Die()
    {
        ReSetPalyerState();
    }

    static void ReSetPalyerState()
    {
        GameSystem.player.HP = 1;
        GameSystem.player.SP = 1;
    }

    static void ShowPlayerSkill()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string line = "";
        for (int l = 0; l < 35; l++)
        {
            line += "-";
        }
        int index = 1;
        Console.WriteLine($"\n    {line}");
        Console.WriteLine(StateLength($"0.", "Return"));
        GameSystem.player.skills.ForEach(s =>
        {
            if (GameSystem.player.SP > s.CastSP)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(StateLength($"{index}.", $"{s.Name} (-{s.CastSP} SP)"));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(StateLength($"{index}.", s.Name));
            }
            index++;
        });
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"    {line}\n");
    }

    static bool Skill()
    {
        bool isMonsterDie = false;
        ShowPlayerSkill();        

        while(true)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter number : ");
                int answer = int.Parse(Console.ReadLine())-1;

                // -1 means no skill and return to the battle.
                if(answer == -1)
                {
                    break;
                }

                if (GameSystem.player.skills[answer] != null && GameSystem.player.SP > GameSystem.player.skills[answer].CastSP)
                {
                    isMonsterDie = PlayerAttack(GameSystem.player.skills[answer]);
                    break;
                }
                else if (GameSystem.player.skills[answer] != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** You don't have enough SP **");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("** You don't have this skill **");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }
        return isMonsterDie;
    }
    static bool Run()
    {
        bool isRunAway = false;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Are you sure you want to run away?");
        Console.Write("yes/no : ");
        string answer = Console.ReadLine();

        if(answer.ToLower() == "yes")
        {
            isRunAway = true;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You have fled from the battlefield..");
        }

        return isRunAway;
    }


    static void ShowMonsterState()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        string line = "";
        for (int l = 0; l < 35; l++)
        {
            line += "-";
        }

        Console.WriteLine($"\n    {line}");
        Console.WriteLine(StateLength("Name", monster.Name));
        Console.WriteLine($"    {line}");
        Console.WriteLine(StateLength("HP", monster.HP));
        Console.WriteLine(StateLength("SP", monster.SP));
        Console.WriteLine(StateLength("ATK", monster.ATK));
        Console.WriteLine(StateLength("DEF", monster.DEF));
        Console.WriteLine($"    {line}\n");
    }
    static string StateLength<T>(string title, T contend)
    {
        return $"   |   {title}: {contend}".PadRight(39) + "|";
    }
    static void ShowEncounterMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string content = " FIGHT ";

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
}
