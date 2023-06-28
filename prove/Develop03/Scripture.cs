public class Scripture{
 
    private Reference _reference;

    private List<Word> _words;

    private List<int> _wordsIndex;

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
        //Random random = new Random();
        //int randomNumber = 0;
        //randomNumber= random.Next(_words.Count);
//
        //HideRandomWords(5);
    }

    public void HideRandomWords(int numberToHide)
    {
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
        return true;
    }
}