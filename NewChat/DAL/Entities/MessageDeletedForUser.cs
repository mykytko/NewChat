namespace NewChat.DAL.Entities;

public record MessageDeletedForUser
(
    int Id,
    int MessageId,
    string UserId
);
