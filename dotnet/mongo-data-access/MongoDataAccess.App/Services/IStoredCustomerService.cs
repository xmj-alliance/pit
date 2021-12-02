using MongoDataAccess.App.Models;

namespace MongoDataAccess.App.Services;

public interface IStoredCustomerService: IDataAccessService<StoredCustomer>
{
    Task<InstanceCUDMessage<StoredCustomer>> Add(InputCustomer newCustomer);
    Task<InstanceCUDMessage<StoredCustomer>> Add(IEnumerable<InputCustomer> newCustomers);
}

