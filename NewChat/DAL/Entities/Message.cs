namespace NewChat.DAL.Entities;

public class Message
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int ChatId { get; set; }
    public DateTime Datetime { get; set; }
    public int ReplyTo { get; set; }
    public string ReplyIsPersonal { get; set; }
}
