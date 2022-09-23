CREATE TABLE [chat_schema].[member_chat] (
    [id]      INT NOT NULL,
    [user_id] INT NOT NULL,
    [chat_id] INT NULL,
    CONSTRAINT [member_chat_pk] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [member_chat_chat_null_fk] FOREIGN KEY ([chat_id]) REFERENCES [chat_schema].[chat] ([id]) ON DELETE CASCADE,
    CONSTRAINT [member_chat_user_null_fk] FOREIGN KEY ([user_id]) REFERENCES [chat_schema].[user] ([id]) ON DELETE CASCADE
);


GO

