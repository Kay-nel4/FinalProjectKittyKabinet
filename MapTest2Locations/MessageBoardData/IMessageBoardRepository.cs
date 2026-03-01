using System.Collections;
using MapTest2Locations.Models;

namespace MapTest2Locations.MessageBoardData;

public interface IMessageBoardRepository
{
    Task<IEnumerable<MessageBoard>> GetAllPostsAsync();
    Task<MessageBoard> GetPostByIdAsync(int postId);
    Task AddPostAsync(MessageBoard post);
    
    Task DeletePostAsync(int id);
    

}