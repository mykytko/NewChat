namespace NewChat.ViewModels;

public record ChatView(
    string ChatName,
    string LastMessageSender,
    string LastMessageText,
    bool IsPersonal);