CREATE TABLE [chat_schema].[messages_deleted_for_user] (
    [id]         INT NOT NULL,
    [message_id] INT NOT NULL,
    [user_id]    INT NOT NULL,
    CONSTRAINT [messages_deleted_for_user_pk] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [messages_deleted_for_user_message_null_fk] FOREIGN KEY ([message_id]) REFERENCES [chat_schema].[message] ([id]) ON DELETE CASCADE,
    CONSTRAINT [messages_deleted_for_user_user_null_fk] FOREIGN KEY ([user_id]) REFERENCES [chat_schema].[user] ([id])
);


GO

