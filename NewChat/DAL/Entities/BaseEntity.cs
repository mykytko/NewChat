using System.ComponentModel.DataAnnotations;

namespace NewChat.DAL.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}