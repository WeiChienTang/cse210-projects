class Scripture
{
    Reference reference;
    public Word word { get; private set; }
    public Scripture()
    {
        SetScripture();
    }
    public void Refresh()
    {
        SetScripture();
    }
    public void ShowScripture()
    {
        Console.WriteLine(reference.GetReference() + " " + word.GetWordS());
    }
    void SetScripture()
    {
        Dictionary<Reference, Word> _scripture = GetScripture();

        Random r = new Random();
        int result = r.Next(_scripture.Count - 1);
        reference = _scripture.ElementAt(result).Key;
        word = _scripture.ElementAt(result).Value;

    }
    Dictionary<Reference, Word> GetScripture()
    {
        Dictionary<Reference, Word> result = new Dictionary<Reference, Word>()
        {
            {new Reference(_book:"Moses",_chapter: 1, _startverse:39), new Word("For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man.") },
            {new Reference(_book:"D&C",_chapter: 1, _startverse:37,_endtverse: 38), new Word("Search these commandments, for they are true and faithful, and the prophecies and promises " +
            "which are in them shall all be fulfilled. What I the Lord have spoken, I have spoken, and I excuse not myself; and though the heavens and the earth " +
            "pass away, my word shall not pass away, but shall all be fulfilled, whether by mine own voice or by the voice of my servants, it is the same.") },
            {new Reference(_book : "1 Nephi", _chapter:3, _startverse:7), new Word("And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath " +
            "commanded,for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish " +
            "the thing which he commandeth them.") },
            {new Reference(_book : "Abraham", _chapter:3, _startverse:22,_endtverse:23), new Word("Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was;and" +
            " among all these there were many of the noble and great ones; And God saw these souls that they were good, and he stood in the midst of them, and he said:" +
            " These I will make my rulers; for he stood among those that were spirits, and he saw that theywere good; and he said unto me: Abraham, thou art one of them;" +
            " thou wast chosen before thou wast born.") },
        };

        return result;
    }
}
