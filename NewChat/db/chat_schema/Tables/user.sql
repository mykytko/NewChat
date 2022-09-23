CREATE TABLE [chat_schema].[user] (
    [id]       INT          NOT NULL,
    [login]    VARCHAR (24) NOT NULL,
    [password] VARCHAR (32) NOT NULL,
    CONSTRAINT [user_pk] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO

