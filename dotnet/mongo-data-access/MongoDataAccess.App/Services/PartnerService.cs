using MongoDataAccess.App.Database;
using MongoDataAccess.App.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDataAccess.App.Services;

internal class PartnerService: DataAccessService<Partner>, IPartnerService
{
    private readonly string dbnamePrefix = "partner";
    private readonly IMongoCollection<Partner> collection;
    public PartnerService(IDBCollection collections) : base(
        collection: collections.Partners
    )
    { collection = collections.Partners; }

    public async Task<InstanceCUDMessage<Partner>> Add(InputPartner newPartner)
    {
        try
        {
            var partner = new Partner(
                ID: ObjectId.GenerateNewId().ToString(),
                DBName: string.IsNullOrWhiteSpace(newPartner.DBName) ? $"{ dbnamePrefix }-{ Guid.NewGuid() }" : newPartner.DBName,
                Name: newPartner.Name ?? "",
                Description: newPartner.Description ?? "",
                UpdateDate: DateTime.Now,
                DeleteDate: null,
                Type: newPartner.Type,
                Phone: newPartner.Phone ?? "",
                Address: newPartner.Address ?? "",
                Email: newPartner.Email ?? "",
                BankAccount: newPartner.BankAccount ?? "",
                Ratings: newPartner.Ratings ?? 0f,
                Contacts: new List<string>()
            );

            await collection.InsertOneAsync(partner);

            return new InstanceCUDMessage<Partner>(
                OK: true,
                NumAffected: 1,
                Message: "",
                Instances: new List<Partner>() { partner }
            );
        }
        catch (Exception e)
        {
            return new InstanceCUDMessage<Partner>(
                OK: false,
                NumAffected: 0,
                Message: e.Message,
                Instances: null
            );
        }
    }

    public async Task<InstanceCUDMessage<Partner>> Add(IEnumerable<InputPartner> newPartners)
    {

        try
        {
            var partners = (
                from partner in newPartners
                select new Partner(
                    ID: ObjectId.GenerateNewId().ToString(),
                    DBName: string.IsNullOrWhiteSpace(partner.DBName) ? $"{ dbnamePrefix }-{ Guid.NewGuid() }" : partner.DBName,
                    Name: partner.Name ?? "",
                    Description: partner.Description ?? "",
                    UpdateDate: DateTime.Now,
                    DeleteDate: null,
                    Type: partner.Type,
                    Phone: partner.Phone ?? "",
                    Address: partner.Address ?? "",
                    Email: partner.Email ?? "",
                    BankAccount: partner.BankAccount ?? "",
                    Ratings: partner.Ratings ?? 0f,
                    Contacts: new List<string>()
                )
            );

            await collection.InsertManyAsync(partners);

            return new InstanceCUDMessage<Partner>(
                OK: true,
                NumAffected: partners.Count(),
                Message: "",
                Instances: partners
            );

        }
        catch (Exception e)
        {
            return new InstanceCUDMessage<Partner>(
                OK: false,
                NumAffected: 0,
                Message: e.Message,
                Instances: null
            );
        }

    }
}

