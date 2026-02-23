using System.Data;
using Dapper;
using MapTest2Locations.Models;

namespace MapTest2Locations.Data;

public class KabinetRepository : IKabinetRepository
{
    private readonly IDbConnection _connection;

    public KabinetRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Kabinet> GetKittyKabinets()
    {
        return _connection.Query<Kabinet>("SELECT * FROM catfood;");
    }

    public Kabinet GetKabinet(int id)
    {
        return _connection.QuerySingle<Kabinet>("SELECT * FROM catfood WHERE KabinetNumber = @id;", new { id });
    }

    public void UpdateKabinet(Kabinet kabinet)
    {
        _connection.Execute("UPDATE catfood SET DryFood = @dryfood, CannedFood = @cannedfood, Treats = @treats WHERE KabinetNumber = @id",
            new { dryfood = kabinet.DryFood, cannedfood = kabinet.CannedFood, treats = kabinet.Treats, id = kabinet.KabinetNumber});
    }
    
    
}
