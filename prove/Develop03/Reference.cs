class Reference
{
    public Reference(string _book, int _chapter, int _startverse, int _endtverse = 0)
    {
        book = _book;
        chapter = _chapter;
        startverse = _startverse;
        endtverse = _endtverse;
    }

    string book;
    int chapter;
    int startverse;
    int endtverse;

    public string GetReference()
    {
        string result;
        if (endtverse == 0)
        {
            result = book + chapter + " " + startverse;
        }
        else
        {
            result = book + chapter + " " + startverse + ":" + endtverse;
        }
        return result;
    }
}