using NewChat.ViewModels;

namespace NewChat.BLL;

public interface IBlockService
{ 
    IEnumerable<ChatView> GetBlocks(string username);
}