namespace NewChat.DAL.Entities;

public class MessageDeletedForUser
{
    public int Id { get; set; }
    public int MessageId { get; set; }
    public string UserId { get; set; }
}
