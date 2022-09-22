using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NewChat.DAL.Entities;

public class User : BaseEntity
{
    public string Login { get; set; }
    public string Password { get; set; }

    [JsonIgnore]
    public ICollection<Message> Messages { get; set; }
    
    [JsonIgnore]
    public ICollection<Chat> Chats { get; set; }
    
    [JsonIgnore]
    public ICollection<Message> DeletedMessages { get; set; }
}