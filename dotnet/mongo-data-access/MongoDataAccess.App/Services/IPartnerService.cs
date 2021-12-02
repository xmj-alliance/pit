using MongoDataAccess.App.Models;

namespace MongoDataAccess.App.Services;

public interface IPartnerService : IDataAccessService<Partner>
{
    Task<InstanceCUDMessage<Partner>> Add(InputPartner newPartner);
    Task<InstanceCUDMessage<Partner>> Add(IEnumerable<InputPartner> newPartners);
}
