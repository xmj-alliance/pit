using MongoDataAccess.App.Database;
using MongoDataAccess.App.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDataAccess.App.Services;

public class StoredCustomerService: DataAccessService<StoredCustomer>, IStoredCustomerService
{
    private readonly string dbnamePrefix = "customer";
    private readonly IMongoCollection<StoredCustomer> collection;
    public StoredCustomerService(IDBCollection collections) : base(
        collection: collections.Customers
    )
    { collection = collections.Customers; }

    public async Task<InstanceCUDMessage<StoredCustomer>> Add(InputCustomer newCustomer)
    {
        try
        {
            var customer = new StoredCustomer(
                ID: ObjectId.GenerateNewId().ToString(),
                DBName: string.IsNullOrWhiteSpace(newCustomer.DBName) ? $"{ dbnamePrefix }-{ Guid.NewGuid() }" : newCustomer.DBName,
                IsAdult: newCustomer.IsAdult ?? false
            );

            await collection.InsertOneAsync(customer);

            return new InstanceCUDMessage<StoredCustomer>(
                OK: true,
                NumAffected: 1,
                Message: "",
                Instances: new List<StoredCustomer>() { customer }
            );
        }
        catch (Exception e)
        {
            return new InstanceCUDMessage<StoredCustomer>(
                OK: false,
                NumAffected: 0,
                Message: e.Message,
                Instances: null
            );
        }
    }

    public async Task<InstanceCUDMessage<StoredCustomer>> Add(IEnumerable<InputCustomer> newCustomers)
    {

        try
        {
            var customers = (
                from customer in newCustomers
                select new StoredCustomer(
                    ID: ObjectId.GenerateNewId().ToString(),
                    DBName: string.IsNullOrWhiteSpace(customer.DBName) ? $"{ dbnamePrefix }-{ Guid.NewGuid() }" : customer.DBName,
                    IsAdult: customer.IsAdult ?? false
                )
            );

            await collection.InsertManyAsync(customers);

            return new InstanceCUDMessage<StoredCustomer>(
                OK: true,
                NumAffected: customers.Count(),
                Message: "",
                Instances: customers
            );

        }
        catch (Exception e)
        {
            return new InstanceCUDMessage<StoredCustomer>(
                OK: false,
                NumAffected: 0,
                Message: e.Message,
                Instances: null
            );
        }

    }

}

