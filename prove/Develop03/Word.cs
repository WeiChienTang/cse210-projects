class Word
{
    public Word(string _words)
    {
        words = _words;
        isAllreplaced = false;
    }

    string words;
    bool isAllreplaced;
    public string GetWordS() => words;
    public string HideWords()
    {
        if(isAllreplaced)
        {
            Environment.Exit(0);
        }

        List<string> word = words.Split(' ').ToList();
        Random r = new Random();
        words = "";
        int countingHide = 0;

        while(countingHide != 5)
        {
            int index = r.Next(word.Count);
            if (!word[index].Trim().Contains('_'))
            {
                string replacement = "";
                for(int i = 0; i< word[index].Length; i++)
                {
                    replacement += "_";
                }
                word[index] = replacement;
                countingHide++;

                if(word.Where(x => !x.Contains('_')).Count() == 0)
                {
                    isAllreplaced = true;
                    break;
                }
            }
        }

        words = String.Join(" ", word.ToArray());

        return words.Trim();
    }
}