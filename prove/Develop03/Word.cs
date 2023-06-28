public class Word{
    private string _text;
    private Boolean _isHidden;

    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }    

    public string GetDisplaytext()
    {
        return _text;
    }    
}