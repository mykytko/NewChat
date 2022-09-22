using System.Collections.Generic;

namespace NewChat.BLL;

public interface IBlockService
{ 
    IEnumerable<ChatView> GetBlocks(string username);
}