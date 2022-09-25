namespace NewChat.DAL.Entities;

public record Message
(
    int Id,
    int ChatId,
    int ReplyTo,
    string ReplyIsPersonal
);
