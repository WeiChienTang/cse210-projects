class Entry
{
    /// <summary>
    /// It will show the options that the user can choice. Then return the number user choice.
    /// </summary>
    /// <returns></returns>
    public int ShowOptions()
    {
        int result;
        while(true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            try
            {
                result = int.Parse(Console.ReadLine());
                break;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n【WRONG】" + ex.Message +"\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        return result;
    }
}