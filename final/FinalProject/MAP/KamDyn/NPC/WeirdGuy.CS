namespace FinalProjectGame.MAP.KamDyn.NPC
{
    public class WeirdGuy : INPC
    {
        public string Name => GetType().Name;
        Blade blade = new Blade();
        int firstMoney = 20;
        int secondMoney = 10;
        public bool Talk()
        {
            bool isEnd = false;
            GameSystem.NoticeMeassage();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{GameSystem.player.Name}: Hello sir.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name}: Who are you? What do you want?");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{GameSystem.player.Name}: From a distance, I caught a glimpse of you " +
                $"and sensed something special about you. " +
                $"Thus, I felt compelled to approach and extend my greetings.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name}: Hahahaha Funny guy, everyone here thinks I'm crazy, only you think I'm special.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name}: Since you think I am special, if you can give me 【{firstMoney} $】, " +
                $"I will give you something in return. What do you think?");
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("yes/no: ");
            string answer = Console.ReadLine();

            if(answer.ToLower() == "yes" && GameSystem.player.Money > firstMoney)
            {
                GameSystem.player.Money -= firstMoney;
                GameSystem.SpendMoneyMessage(firstMoney);
                Console.ForegroundColor = ConsoleColor.Magenta;                
                Console.WriteLine($"{Name}: Ha thanks. But it's still not enough. What do you think if you give me another 【{secondMoney} $】 yuan?");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("yes/no: ");
                answer = Console.ReadLine();

                if (answer.ToLower() == "yes")
                {
                    GameSystem.player.Money -= secondMoney;
                    GameSystem.SpendMoneyMessage(secondMoney);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{Name}: Take this.");
                    GameSystem.GetItemWeaponMessage(blade);
                    GameSystem.player.weapon = blade;
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{Name}: See you next time.");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"The weird man walks away...");

                    // The event end.
                    isEnd = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{Name}: You miserly scoundrel! Leave this place immediately!");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n{Name}:Go away!!! You cheapskate!!");
            }
            return isEnd;
        }

        public bool Event()
        {
            bool result = false;

            GameSystem.EventMessage();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();
            Console.WriteLine("Your attention is drawn to an unfamiliar individual " +
                "standing at the road corner, seemingly engaged in muttering. " +
                "Are you interested in initiating a conversation with him?");
            Console.Write("yes/no? : ");
            string answer = Console.ReadLine();

            if(answer.ToLower() == "yes")
            {
                result = true;
            }
            else
            {
                result= false;
            }

            return result;
        }
    }
}
