using MongoDataAccess.App.Database;
using MongoDataAccess.App.Library;
using MongoDataAccess.App.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDataAccess.App.Services;
public class DataAccessService<T>: IDataAccessService<T> where T: IBaseEntity
{
    private readonly IMongoCollection<T> collection;
    public string IndexFieldName { get; }
    public DataAccessService(
        IMongoCollection<T> collection,
        string indexFieldName = "dbname"
    )
    {
        IndexFieldName = indexFieldName;
        this.collection = collection;
    }

    public async Task<T> Get(string indexFieldValue, IViewOption? options = null)
    {

        FilterDefinition<T> condition = BuildConditions(indexFieldValue);

        var query = collection.Find(condition);

        if (options is { })
        {
            query = View.MakePagination(query, options);
            query = query.Project<T>(View.BuildProjection(options));
            query.Sort(View.BuildSort(options));
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> Get(FilterDefinition<T> condition, IViewOption? options = null)
    {
        var query = collection.Find(condition);

        if (options is { })
        {
            query = View.MakePagination(query, options);
            query = query.Project<T>(View.BuildProjection(options));
            query.Sort(View.BuildSort(options));
        }

        return await query.ToListAsync();
    }

    public async Task<CUDMessage> Update(string indexFieldValue, UpdateDefinition<T> token)
    {

        FilterDefinition<T> condition = BuildConditions(indexFieldValue);

        try
        {
            UpdateResult result = await collection.UpdateOneAsync(condition, token);
            return new CUDMessage(
                OK: true,
                NumAffected: result.ModifiedCount,
                Message: ""
            );
        }
        catch (Exception e)
        {
            return new CUDMessage(
                OK: false,
                NumAffected: 0,
                Message: e.Message
            );
        }
    }

    public async Task<CUDMessage> Update(FilterDefinition<T> condition, UpdateDefinition<T> token)
    {
        try
        {
            UpdateResult result = await collection.UpdateManyAsync(condition, token);
            return new CUDMessage(
                OK: true,
                NumAffected: result.ModifiedCount,
                Message: ""
            );
        }
        catch (Exception e)
        {
            return new CUDMessage(
                OK: false,
                NumAffected: 0,
                Message: e.Message
            );
        }
    }

    public async Task<CUDMessage> Drop(string indexFieldValue)
    {

        FilterDefinition<T> condition = BuildConditions(indexFieldValue);

        try
        {
            DeleteResult result = await collection.DeleteOneAsync(condition);
            return new CUDMessage(
                OK: true,
                NumAffected: result.DeletedCount,
                Message: ""
            );
        }
        catch (Exception e)
        {
            return new CUDMessage(
                OK: false,
                NumAffected: 0,
                Message: e.Message
            );
        }
    }

    public async Task<CUDMessage> Drop(FilterDefinition<T> condition)
    {
        try
        {
            DeleteResult result = await collection.DeleteManyAsync(condition);
            return new CUDMessage(
                OK: true,
                NumAffected: result.DeletedCount,
                Message: ""
            );
        }
        catch (Exception e)
        {
            return new CUDMessage(
                OK: false,
                NumAffected: 0,
                Message: e.Message
            );
        }
    }

    public async Task<CUDMessage> Delete(string indexFieldValue)
    {
        FilterDefinition<T> condition = BuildConditions(indexFieldValue);
        UpdateDefinition<T> updateToken = Builders<T>.Update.Set("deleteDate", DateTime.Now);

        return await Update(condition, updateToken);
    }

    public async Task<CUDMessage> Delete(FilterDefinition<T> condition)
    {
        UpdateDefinition<T> updateToken = Builders<T>.Update.Set("deleteDate", DateTime.Now);

        return await Update(condition, updateToken);
    }

    public async Task<TJoint> LeftJoinAndGet<TJoint>(string indexFieldValue, ILeftJoinOption joinOptions, IViewOption? viewOption = null)
    {

        var pipelineStages = new List<BsonDocument>();
        Join.AddLeftJoinToPipeline(pipelineStages, joinOptions);

        View.AddFilterToPipeline(pipelineStages, BuildConditions(indexFieldValue));

        if (viewOption is { })
        {
            if (viewOption.Includes is { } || viewOption.Excludes is { })
            {
                View.AddProjectionToPipeline(pipelineStages, viewOption);
            }
            if (viewOption.OrderBy != null)
            {
                View.AddSortToPipeline(pipelineStages, viewOption);
            }
        }

        PipelineDefinition<T, TJoint> pipeline = pipelineStages;

        return await collection.Aggregate(pipeline).FirstOrDefaultAsync();

    }

    public async Task<IEnumerable<TJoint>> LeftJoinAndGet<TJoint>(FilterDefinition<TJoint> condition, ILeftJoinOption joinOptions, FilterDefinition<T>? limitCondition = null, IViewOption? viewOption = null)
    {
        var pipelineStages = new List<BsonDocument>();

        if (limitCondition is { })
        {
            // Narrow down by filtering with T fields first
            // before doing left join, to improve performance.
            View.AddFilterToPipeline(pipelineStages, limitCondition.RenderToBsonDocument().ToString());
        }

        Join.AddLeftJoinToPipeline(pipelineStages, joinOptions);

        View.AddFilterToPipeline(pipelineStages, condition.RenderToBsonDocument().ToString());

        if (viewOption is null)
        {
            View.AddPaginationToPipeline(pipelineStages, new ViewOption());
        }
        else
        {
            View.AddPaginationToPipeline(pipelineStages, viewOption);

            if (viewOption.Includes is { } || viewOption.Excludes is { })
            {
                View.AddProjectionToPipeline(pipelineStages, viewOption);
            }
            if (viewOption.OrderBy != null)
            {
                View.AddSortToPipeline(pipelineStages, viewOption);
            }
        }

        PipelineDefinition<T, TJoint> pipeline = pipelineStages;

        return await collection.Aggregate(pipeline).ToListAsync();

    }
    public async Task<CUDMessage> AddItemToList(string instanceArrayFieldName, string arrayIndexFieldValue, string instanceIndexFieldValue)
    {
        UpdateDefinition<T> updateToken = JsonUtil.CreateCompactLiteral($@"{{
            ""$push"": {{
                ""{instanceArrayFieldName}"": ""{arrayIndexFieldValue}""
            }}
        }}");
        return await Update(instanceIndexFieldValue, updateToken);
    }

    public async Task<CUDMessage> AddItemToList(string instanceArrayFieldName, IEnumerable<string> arrayIndexFieldValues, string instanceIndexFieldValue)
    {
        List<string> quotedNames = (
            from name in arrayIndexFieldValues
            select $@"""{name}"""
        ).ToList();

        UpdateDefinition<T> updateToken = JsonUtil.CreateCompactLiteral($@"{{
            ""$push"": {{
                ""{instanceArrayFieldName}"": {{
                    ""$each"": [ { string.Join(',', quotedNames) } ]
                }}
            }}
        }}");
        return await Update(instanceIndexFieldValue, updateToken);
    }

    public async Task<CUDMessage> RemoveItemFromList(string instanceArrayFieldName, string arrayIndexFieldValue, string instanceIndexFieldValue)
    {
        UpdateDefinition<T> updateToken = JsonUtil.CreateCompactLiteral($@"{{
            ""$pull"": {{
                ""{instanceArrayFieldName}"": ""{arrayIndexFieldValue}""
            }}
        }}");
        return await Update(instanceIndexFieldValue, updateToken);
    }

    public async Task<CUDMessage> RemoveItemFromList(string instanceArrayFieldName, IEnumerable<string> arrayIndexFieldValues, string instanceIndexFieldValue)
    {
        List<string> quotedNames = (
            from name in arrayIndexFieldValues
            select $@"""{name}"""
        ).ToList();

        UpdateDefinition<T> updateToken = JsonUtil.CreateCompactLiteral($@"{{
            ""$pull"": {{
                ""{instanceArrayFieldName}"": {{
                    ""$in"": [ { string.Join(',', quotedNames) } ]
                }}
            }}
        }}");
        return await Update(instanceIndexFieldValue, updateToken);
    }

    #region private methods
    private string BuildConditions(string indexFieldValue)
    {

        string condition;
        if (IndexFieldName == "_id")
        {
            condition = Builders<T>.Filter.Eq(IndexFieldName, ObjectId.Parse(indexFieldValue)).RenderToBsonDocument().ToString();
        }
        else
        {
            condition = Builders<T>.Filter.Eq(IndexFieldName, indexFieldValue).RenderToBsonDocument().ToString();
        }
        return condition;
    }

    #endregion

}

