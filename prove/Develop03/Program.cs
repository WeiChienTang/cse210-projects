using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();

        while (true)
        {
            scripture.ShowScripture();

            Console.WriteLine("\nType Enter to continu. '-q' to exit. '-re' to get new scripture.");

            string result = Console.ReadLine().ToLower().Trim();

            if (result == "-q")
            {
                Environment.Exit(0);
            }
            else if(result == "-re")
            {
                scripture.Refresh();
            }
            else
            {
                scripture.word.HideWords();
            }

            Console.Clear();
        }
    }
}