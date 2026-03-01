using System.Collections;
using System.Data;
using Dapper;
using MapTest2Locations.Models;


namespace MapTest2Locations.MessageBoardData;

public class MessageBoardRepository : IMessageBoardRepository
{
    private readonly IDbConnection _connection;

    public MessageBoardRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<MessageBoard>> GetAllPostsAsync()
    {
        string sql = "SELECT * FROM kabinetkommunity ORDER BY TimeCreated DESC";
        return await _connection.QueryAsync<MessageBoard>(sql);
    }

    public async Task<MessageBoard> GetPostByIdAsync(int postId)
    {
        string sql = "SELECT * FROM kabinetkommunity WHERE PostNumber = @postId";
        return await _connection.QueryFirstOrDefaultAsync<MessageBoard>(sql, new { postId });
    }

    public async Task AddPostAsync(MessageBoard post)
    {
        string sql =
            "INSERT INTO kabinetkommunity (UserName, Post, KabinetNumber, TimeCreated) VALUES (@UserName, @Post, @KabinetNumber, @TimeCreated)";
        await _connection.ExecuteAsync(sql, post);
    }

    public async Task DeletePostAsync(int id)
    {
        string sql = "DELETE FROM kabinetkommunity WHERE PostNumber = @id";
        await _connection.ExecuteAsync(sql, new { id });
    }

}