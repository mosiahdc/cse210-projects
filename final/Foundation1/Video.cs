using System;

public class Video
{
    public string _title, _author;
    public int _length;
    public List<Comment> _comments = new List<Comment>();

    public Video (string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(string name, string comment)
    {
        _comments.Add(new Comment(name, comment));
    }
}