using MongoDataAccess.App.Database;
using MongoDataAccess.App.Models;
using MongoDB.Driver;

namespace MongoDataAccess.App.Services;

public interface ICustomerService
{
    Task<JointCustomer> Get(string dbname, IViewOption? options = null);
    Task<IEnumerable<JointCustomer>> Get(FilterDefinition<JointCustomer> customerCondition, IViewOption? viewOptions = null);
    Task<(InstanceCUDMessage<Partner>, InstanceCUDMessage<StoredCustomer>)> Add(InputCustomer newCustomer);
    Task<(InstanceCUDMessage<Partner>, InstanceCUDMessage<StoredCustomer>)> Add(IEnumerable<InputCustomer> newCustomers);
    Task<IEnumerable<CUDMessage>> Update(string dbname, UpdateDefinition<JointCustomer> token);
    Task<IEnumerable<CUDMessage>> Update(FilterDefinition<JointCustomer> condition, UpdateDefinition<JointCustomer> token);
    Task<IEnumerable<CUDMessage>> Delete(string dbname);
    Task<IEnumerable<CUDMessage>> Delete(FilterDefinition<JointCustomer> condition);
    Task<IEnumerable<CUDMessage>> Drop(string dbname);
    Task<IEnumerable<CUDMessage>> Drop(FilterDefinition<JointCustomer> condition);

}

