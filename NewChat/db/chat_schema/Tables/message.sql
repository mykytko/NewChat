CREATE TABLE [chat_schema].[message] (
    [id]                INT            NOT NULL,
    [user_id]           INT            NOT NULL,
    [chat_id]           INT            NOT NULL,
    [datetime]          DATETIME       NOT NULL,
    [text]              VARCHAR (4096) NOT NULL,
    [reply_to]          INT            NOT NULL,
    [reply_is_personal] BIT            NOT NULL,
    CONSTRAINT [message_pk] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [message_chat_null_fk] FOREIGN KEY ([chat_id]) REFERENCES [chat_schema].[chat] ([id]) ON DELETE CASCADE,
    CONSTRAINT [message_user_null_fk] FOREIGN KEY ([user_id]) REFERENCES [chat_schema].[user] ([id]) ON DELETE CASCADE
);


GO

