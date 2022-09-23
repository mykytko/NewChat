using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewChat.DAL.Entities;

namespace NewChat.DAL;

public class ChatsContext : DbContext
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<IdentityUser> Users { get; set; }

    private readonly IConfiguration _config;

    public ChatsContext(IConfiguration config)
    {
        _config = config;
    }
    
    public ChatsContext(DbContextOptions<ChatsContext> options,
        IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Default"));
        }
        base.OnConfiguring(optionsBuilder);
    }
}