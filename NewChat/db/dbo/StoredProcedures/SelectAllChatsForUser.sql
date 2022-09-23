create procedure SelectAllChatsForUser
    @userId int
as
    select * from chat_schema.member_chat as mc
    join chat_schema.chat as c on mc.user_id = c.id
    where user_id = @userId;
GO

