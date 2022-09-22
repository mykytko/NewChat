using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NewChat.DAL.Entities;

public class Chat : BaseEntity
{
    public string Name { get; set; }
    
    [JsonIgnore]
    public ICollection<Message> Messages { get; set; }
    
    [JsonIgnore]
    public ICollection<User> Members { get; set; }
}