using System.Collections.Generic;
using System.Text;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetDisplay()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Title: {_title}");
        sb.AppendLine($"Author: {_author}");
        sb.AppendLine($"Length: {_lengthInSeconds} seconds");
        sb.AppendLine($"Comments ({GetCommentCount()}):");

        foreach (Comment comment in _comments)
        {
            sb.AppendLine($"- {comment.GetDisplay()}");
        }

        return sb.ToString();
    }
}
