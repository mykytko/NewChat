namespace NewChat.BLL;

public class MessageView
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Text { get; set; }
    public string Date { get; set; }
    public int ReplyTo { get; set; }
    public bool ReplyIsPersonal { get; set; }
}