public class Reference
{

    private string _book;

    private int _chapter, _verse, _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {   
        string referenceDisplay = "";

        if (_endVerse != 0)
        {
            referenceDisplay = $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            referenceDisplay = $"{_book} {_chapter}:{_verse}";
        }


        return referenceDisplay;
    }
}