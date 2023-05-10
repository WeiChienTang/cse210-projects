using System;

class Program
{
    static void Main(string[] args)
    {
        int result = 0;
        while (result != 4)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflection activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");

            try
            {
                result = int.Parse(Console.ReadLine());
                switch (result)
                {
                    case 1:
                        Breathing breathing = new Breathing();
                        breathing.StartActivity();
                        break;
                    case 2:
                        Reflecting reflecting = new Reflecting();
                        reflecting.StartActivity();
                        break;
                    case 3:
                        Listing listing = new Listing();
                        listing.StartActivity();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"{result} is not in the options.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }
    }
}