using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Bson.Serialization;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace TMS_ResultSet
{
    public class GetMongoData
    {
        public static List<BsonDocument> GetResultsDataSet(IMongoCollection<BsonDocument> collection, string day)
        {
            var query = collection.Aggregate()
                .Unwind("Data.__value.TestResults")
                .Match(Builders<BsonDocument>.Filter.Eq("Data.__value.IsComplete", true))
                .Match(Builders<BsonDocument>.Filter.Gt("Data.__value.FailedCount", 0))
                .Match(Builders<BsonDocument>.Filter.Regex("Data.__value.TestResults.__value.Message", "/Overall Result: Fail/"))
                .Match(Builders<BsonDocument>.Filter.Regex("Data.__value.TestResults.__value.StartTime", "/(" + day + ")T([0-2][0-9]:)/"))
                .Group(new BsonDocument{
                    { "_id", new BsonDocument{
                        {"Test", "$Data.__value.TestResults.__value.TestName"},
                        {"Testpad", "$Data.__value.TestResults.__value.TestPath"},
                    }},
                    { "StartVanTest", new BsonDocument("$first", "$Data.__value.TestResults.__value.StartTime")},
                    { "EindVanTest", new BsonDocument("$last", "$Data.__value.TestResults.__value.EndTime")},
                    { "Resultaten", new BsonDocument(
                        "$push", new BsonDocument{
                            { "Bericht", "$Data.__value.TestResults.__value.Message"}
                        }
                    )}
                });

            List<BsonDocument> result = query.ToList();

            return result;
        }
    }
}
