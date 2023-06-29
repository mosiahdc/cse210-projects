public class Scripture{
 
    private Reference _reference;

    private List<Word> _words;

    private List<int> _wordsIndex = new List<int>();

    public Scripture()
    {

    }
    public Scripture(Reference reference, string text)
    {   
        _reference = reference;
        _words = new List<Word>();

        List<string> allWords = text.Split(' ').ToList();
        foreach(string wordString in allWords)
        {
            Word newWord = new Word(wordString);
            _words.Add(newWord);
        }
        
    }

    public void GenerateRandomNumber()
    {   

        Random random = new Random();

        int randomNumber;
        do{
            randomNumber = random.Next(_words.Count);
        }
        while (_wordsIndex.Contains(randomNumber));
        
        HideRandomWords(randomNumber);

    }

    public void HideRandomWords(int numberToHide)
    {   
        _wordsIndex.Add(numberToHide);
        Word hiddenText = _words[numberToHide];
        hiddenText.Hide();
    }

    public string GetDisplayText()
    {   

        string scriptureText = "";

        foreach (Word word in _words)
        {
            if (word.GetIsHidden() == false)
            {
                scriptureText += word.GetDisplaytext() + " ";
            }
            else
            {
                scriptureText += new string('_', word.GetDisplaytext().Length) + " ";
            }
        }

        return ($"{_reference.GetDisplayText()} {scriptureText}");
    }

    public bool IsCompletelyHidden()
    {   
        bool allWordsHidden = false;


        if (_wordsIndex.Count == _words.Count)
        {
            allWordsHidden = true;
        }

        return allWordsHidden;
    }

    public void LoadFromFile()
    {
        string[] lines = System.IO.File.ReadAllLines("scriptures.txt");

        Random random = new Random();

        int randomLine, lineNumber;
        randomLine = random.Next(lines.Count());

        if (randomLine % 2 == 0)
        {
            lineNumber = randomLine;
        }
        else
        {
            lineNumber = randomLine - 1;
        }

        string[] scriptureReference = lines[lineNumber].Split("/");
        string book = scriptureReference[0];
        int chapter = Int32.Parse(scriptureReference[1]);
        int verse = Int32.Parse(scriptureReference[2]);
        
        if (scriptureReference.Count() == 4)
        {
            int endVerse = Int32.Parse(scriptureReference[3]);
            _reference = new Reference(book, chapter, verse, endVerse);
        }
        else
        {
            _reference = new Reference(book, chapter, verse);
        }
            
        string scripturePassage = lines[lineNumber + 1];
        Scripture scripture = new Scripture(_reference, scripturePassage);
        this._words = scripture._words;
    }
}