using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NewChat.DAL.Entities;

public class Message : BaseEntity
{
    public int UserId { get; set; }
    public int ChatId { get; set; }
    public string Text { get; set; }
    public DateTime DateTime { get; set; }
    public int ReplyTo { get; set; }
    public bool ReplyIsPersonal { get; set; }

    [JsonIgnore]
    public User User { get; set; }

    [JsonIgnore]
    public Chat Chat { get; set; }
    
    [JsonIgnore]
    public ICollection<User> DeletedForUsers { get; set; }
}