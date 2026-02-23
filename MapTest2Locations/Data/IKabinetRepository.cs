using MapTest2Locations.Models;

namespace MapTest2Locations.Data;

public interface IKabinetRepository
{
    public IEnumerable<Kabinet> GetKittyKabinets();

    Kabinet GetKabinet(int id);

    void UpdateKabinet(Kabinet kabinet);
}