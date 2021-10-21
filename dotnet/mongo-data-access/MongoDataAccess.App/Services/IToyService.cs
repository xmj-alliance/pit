using MongoDataAccess.App.Models;

namespace MongoDataAccess.App.Services;

public interface IToyService: IDataAccessService<Toy>
{
    Task<InstanceCUDMessage<Toy>> Add(InputToy newToy);
    Task<InstanceCUDMessage<Toy>> Add(IEnumerable<InputToy> newToys);
}

