using Microsoft.EntityFrameworkCore;
using NewChat.DAL.Entities;

namespace NewChat.DAL;

public class ChatsContext : DbContext
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>()
            .HasMany(c => c.Members)
            .WithMany(u => u.Chats);
        modelBuilder.Entity<Chat>()
            .HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(m => m.ChatId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.UserId);
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId);
        modelBuilder.Entity<Message>()
            .HasMany(m => m.DeletedForUsers)
            .WithMany(mdfu => mdfu.DeletedMessages);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Chats)
            .WithMany(c => c.Members);
        modelBuilder.Entity<User>()
            .HasMany(u => u.Messages)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
        modelBuilder.Entity<User>()
            .HasMany(u => u.DeletedMessages)
            .WithMany(mdfu => mdfu.DeletedForUsers);
        
        base.OnModelCreating(modelBuilder);
    }
}