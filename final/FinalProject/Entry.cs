sealed class Entry
{
    public void ShowWelcome()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Welcome to the Small Story Game! In this game, you can interact with NPCs, collect " +
            "or purchase items, and even venture into dangerous territories to defeat monsters and obtain valuable supplies to sell to the NPC.");
        Console.WriteLine("Your journey will unfold through a series of decisions, and based on the choices you make " +
            "and the items you gather, you will encounter one of three unique endings.\r\n");
        Console.WriteLine("We aim to provide you with an enjoyable experience and the chance to" +
            " discover happiness in this game. Are you ready to embark on this adventure? Let's begin!");
    }
    public Player CreatPlayer()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.Write("What is your name: ");
        string name = Console.ReadLine();
        Player p = new(name);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        Console.Write($"{p.Name}, ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("I'm glad you find the name special, and I hope it brings happiness to your gaming experience. Get ready, because in just a moment, " +
            "you will be entering the game. Enjoy your journey and may this virtual world bring you joy and excitement. The countdown begins now: 3... 2... 1... Let the adventure begin!");

        //Thread.Sleep(1000);

        return p;
    }
}
