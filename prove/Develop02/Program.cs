using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Entry en = new Entry();
        int result;

        while(true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            result = en.ShowOptions();
            switch(result)
            {
                case 1:
                    journal.Writ();
                    break;
                case 2:
                    journal.Display();
                    break;
                case 3:
                    journal.Save();
                    break;
                case 4:
                    journal.Load();
                    break;
                case 5:
                    journal.Delete();
                    break;
                case 6:
                    journal.Quit();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n【WRONG】Please enter number 1 ~ 5.\n");
                    break;
            }
        }
    }
}