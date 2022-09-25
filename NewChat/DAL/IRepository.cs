namespace NewChat.DAL;

public interface IRepository
{
    public ChatsContext Context { get; set; }
}