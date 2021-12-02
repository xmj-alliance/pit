using MongoDataAccess.App.Database;
using MongoDataAccess.App.Library;
using MongoDataAccess.App.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDataAccess.App.Services;

public class CustomerService : ICustomerService
{
    private readonly string dbnamePrefix = "customer";
    //private readonly List<string> partnerInputFields = new () {
    //    "type",
    //    "dbname",
    //    "name",
    //    "description",
    //    "phone",
    //    "address",
    //    "email",
    //    "bankAccount",
    //    "ratings",
    //    "contacts",
    //};
    
    //private readonly List<string> storedCustomerInputFields = new()
    //{
    //    "isAdult",
    //};
    private readonly List<string> partnerFields = new()
    {
        "type",
        "dbname",
        "name",
        "description",
        "updateDate",
        "deleteDate",
        "phone",
        "address",
        "email",
        "bankAccount",
        "ratings",
        "contacts",
    };

    private readonly List<string> storedCustomerFields = new()
    {
        "isAdult",
    };
    private readonly IStoredCustomerService storedCustomerService;
    private readonly IPartnerService partnerService;

    public CustomerService(
        IStoredCustomerService storedCustomerService,
        IPartnerService partnerService
    )
    {
        this.storedCustomerService = storedCustomerService;
        this.partnerService = partnerService;
    }

    public async Task<JointCustomer> Get(string dbname, IViewOption? viewOptions = null)
        => await storedCustomerService.LeftJoinAndGet<JointCustomer>(
            dbname,
            new LeftJoinOption(
                CollectionName: storedCustomerService.DBCollectionNamespace.CollectionName,
                LocalField: storedCustomerService.IndexFieldName,
                ForeignField: partnerService.IndexFieldName
            ),
            viewOptions
        );

    public async Task<IEnumerable<JointCustomer>> Get(FilterDefinition<JointCustomer> customerCondition, IViewOption? viewOptions = null)
    {
        // Extract the limitCondition from the big customerCondition
        var limitCondition = ExtractFindToken<StoredCustomer>(customerCondition.ToBsonDocument(), storedCustomerFields);

        // Do the join and get a JointCustomer document
        return await storedCustomerService.LeftJoinAndGet(
            customerCondition,
            new LeftJoinOption(
                CollectionName: storedCustomerService.DBCollectionNamespace.CollectionName,
                LocalField: storedCustomerService.IndexFieldName,
                ForeignField: partnerService.IndexFieldName
            ),
            limitCondition,
            viewOptions
        );

    }

    public async Task<(InstanceCUDMessage<Partner>, InstanceCUDMessage<StoredCustomer>)> Add(InputCustomer newCustomer)
    {
        InputPartner newPartner = newCustomer with
        {
            DBName = string.IsNullOrWhiteSpace(newCustomer.DBName) ? $"{ dbnamePrefix }-{ Guid.NewGuid() }" : newCustomer.DBName,
        };

        InstanceCUDMessage<Partner> partnerAddMessage = await partnerService.Add(newPartner);
        InstanceCUDMessage<StoredCustomer> storedCustomerAddMessage = await storedCustomerService.Add(newCustomer);

        return (
            partnerAddMessage,
            storedCustomerAddMessage
        );

    }

    public async Task<(InstanceCUDMessage<Partner>, InstanceCUDMessage<StoredCustomer>)> Add(IEnumerable<InputCustomer> newCustomers)
    {
        IEnumerable<InputPartner> newPartners = (
            from customer in newCustomers
            select customer with
            {
                DBName = string.IsNullOrWhiteSpace(customer.DBName) ? $"{ dbnamePrefix }-{ Guid.NewGuid() }" : customer.DBName,
            }
        );

        InstanceCUDMessage<Partner> partnerAddMessage = await partnerService.Add(newPartners);
        InstanceCUDMessage<StoredCustomer> storedCustomerAddMessage = await storedCustomerService.Add(newCustomers);

        return (
            partnerAddMessage,
            storedCustomerAddMessage
        );

    }

    public async Task<IEnumerable<CUDMessage>> Update(string dbname, UpdateDefinition<JointCustomer> token)
    {
        // extract update token
        var tokenDoc = token.ToBsonDocument();
        var storedCustomerUpdateToken = ExtractUpdateToken<StoredCustomer>(tokenDoc, storedCustomerFields);
        var partnerUpdateToken = ExtractUpdateToken<Partner>(tokenDoc, partnerFields);

        // perform update on collections by that dbname and respective token
        List<CUDMessage> messages = new();

        if (storedCustomerUpdateToken is { })
        {
            CUDMessage storedCustomerUpdateMessage = await storedCustomerService.Update(dbname, storedCustomerUpdateToken);
            messages.Add(storedCustomerUpdateMessage);
        }

        if (partnerUpdateToken is { })
        {
            CUDMessage partnerUpdateMessage = await partnerService.Update(dbname, partnerUpdateToken);
            messages.Add(partnerUpdateMessage);
        }

        return messages;
    }

    public async Task<IEnumerable<CUDMessage>> Update(FilterDefinition<JointCustomer> condition, UpdateDefinition<JointCustomer> token)
    {
        // join 2 colllections and find the results
        var jointCustomers = await Get(
            condition,
            new ViewOption()
            {
                Includes = new List<string>() { "dbname" },
            }
        );

        // extract dbnames
        var dbnames = (
            from customer in jointCustomers
            select customer.DBName
        );

        // extract update token
        var tokenDoc = token.ToBsonDocument();
        var storedCustomerUpdateToken = ExtractUpdateToken<StoredCustomer>(tokenDoc, storedCustomerFields);
        var partnerUpdateToken = ExtractUpdateToken<Partner>(tokenDoc, partnerFields);

        // perform update on collections by those dbnames and respective token
        string updateCondition = JsonUtil.CreateCompactLiteral($@"{{
                ""dbname"": {{
                    ""$in"": [ { dbnames.ToMarkedString() } ]
                }}
            }}"
        );

        // perform update on collections by that dbname and respective token
        List<CUDMessage> messages = new();

        if (storedCustomerUpdateToken is { })
        {
            CUDMessage storedCustomerUpdateMessage = await storedCustomerService.Update((FilterDefinition<StoredCustomer>)updateCondition, storedCustomerUpdateToken);
            messages.Add(storedCustomerUpdateMessage);
        }

        if (partnerUpdateToken is { })
        {
            CUDMessage partnerUpdateMessage = await partnerService.Update((FilterDefinition<Partner>)updateCondition, partnerUpdateToken);
            messages.Add(partnerUpdateMessage);
        }

        return messages;
    }

    public async Task<IEnumerable<CUDMessage>> Delete(string dbname)
        => await Update(
            dbname,
            Builders<JointCustomer>.Update.Set("deleteDate", DateTime.Now)
        );

    public async Task<IEnumerable<CUDMessage>> Delete(FilterDefinition<JointCustomer> condition)
        => await Update(
            condition,
            Builders<JointCustomer>.Update.Set("deleteDate", DateTime.Now)
        );

    public async Task<IEnumerable<CUDMessage>> Drop(string dbname)
    {
        CUDMessage storedCustomerDropMessage = await storedCustomerService.Drop(dbname);
        CUDMessage partnerDropMessage = await partnerService.Drop(dbname);

        return new List<CUDMessage>()
        {
            storedCustomerDropMessage,
            partnerDropMessage,
        };
    }

    public async Task<IEnumerable<CUDMessage>> Drop(FilterDefinition<JointCustomer> condition)
    {
        // join 2 colllections and find the results
        var jointCustomers = await Get(
            condition,
            new ViewOption()
            {
                Includes = new List<string>() { "dbname" },
            }
        );

        // extract dbnames
        var dbnames = (
            from customer in jointCustomers
            select customer.DBName
        );

        string deleteToken = JsonUtil.CreateCompactLiteral($@"{{
                ""dbname"": {{
                    ""$in"": [ { dbnames.ToMarkedString() } ]
                }}
            }}"
        );

        CUDMessage storedCustomerDropMessage = await storedCustomerService.Drop((FilterDefinition<StoredCustomer>)deleteToken);
        CUDMessage partnerDropMessage = await partnerService.Drop((FilterDefinition<Partner>)deleteToken);

        return new List<CUDMessage>()
        {
            storedCustomerDropMessage,
            partnerDropMessage
        };

    }

    private FilterDefinition<T>? ExtractFindToken<T>(BsonDocument findTokenDocument, IEnumerable<string> fields)
    {
        var findDoc = (
            from fieldCondition in findTokenDocument
            where fields.Contains(fieldCondition.Name)
            select fieldCondition
        );

        if (findDoc.Any())
        {
            return findDoc.ToJson();
        }

        return null;
    }

    /// <summary>
    ///     Extract Update Token for a collection from a big Update Token that sets across multiple collections
    /// </summary>
    /// <typeparam name="T">The target collection type</typeparam>
    /// <param name="updateTokenDocument">A Bson Document that should look like: {<$updateOperator1>: { <field1>: xxx, <field2>: xxx }, <$updateOperator2>: { <field1>: xxx, <field2>: xxx }}</param>
    /// <param name="fields">Fields in a collection to filter out</param>
    /// <returns></returns>
    private UpdateDefinition<T>? ExtractUpdateToken<T>(BsonDocument updateTokenDocument, IEnumerable<string> fields)
    {
        var originalTokenMap = updateTokenDocument.ToDictionary(
            kv => kv.Name,
            (kv) => {
                return kv.Value.ToBsonDocument().Elements.ToDictionary(el => el.Name, el => el.Value);
            }
        );

        var updateTokenMap = new Dictionary<string, Dictionary<string, BsonValue>>();

        foreach (var operatorKV in originalTokenMap)
        {
            var targetOperatorDict = updateTokenMap.GetValueOrDefault(operatorKV.Key);
            foreach (var fieldKV in operatorKV.Value)
            {
                if (fields.Contains(fieldKV.Key))
                {
                    if (targetOperatorDict is null)
                    {
                        targetOperatorDict = new Dictionary<string, BsonValue>();
                        updateTokenMap[operatorKV.Key] = targetOperatorDict;
                    }
                    targetOperatorDict.Add(fieldKV.Key, fieldKV.Value);
                }
            }
        }

        if (updateTokenMap.Count > 0)
        {
            return updateTokenMap.ToJson();
        }

        return null;

    }

}

