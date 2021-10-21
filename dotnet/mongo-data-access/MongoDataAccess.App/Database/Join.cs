using MongoDataAccess.App.Library;
using MongoDB.Bson;

namespace MongoDataAccess.App.Database;
public static class Join
{
    public static void AddLeftJoinToPipeline(IList<BsonDocument> pipelineStages, ILeftJoinOption options)
    {
        var leftJoinProcedures = new List<BsonDocument>()
        {
            BsonDocument.Parse(JsonUtil.CreateCompactLiteral($@"{{
                ""$lookup"": {{
                    ""from"": ""{options.CollectionName}"",
                    ""localField"": ""{options.LocalField}"",
                    ""foreignField"": ""{options.ForeignField}"",
                    ""as"": ""jointDBName""
                }}
            }}")),

            BsonDocument.Parse(JsonUtil.CreateCompactLiteral($@"{{
                ""$replaceRoot"": {{
                    ""newRoot"": {{
                        ""$mergeObjects"": [
                            {{
                                ""$arrayElemAt"": [ ""$jointDBName"", 0 ]
                            }},
                            ""$$ROOT""
                        ]
                    }}
                }}
            }}")),

            BsonDocument.Parse(JsonUtil.CreateCompactLiteral($@"{{
                ""$project"": {{ ""jointDBName"": 0 }}
            }}")),

        };

        foreach (var proc in leftJoinProcedures)
        {
            pipelineStages.Add(proc);
        }
    }


}

