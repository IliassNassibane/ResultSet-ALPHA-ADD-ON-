#define LOG

using System;
using TMS_ResultSet;
using TMS_ResultSet.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ResultSet
{
    class Programs
    {
        static void Main(string[] args)
        {
            //string today = DateTime.Now.ToString("yyyy-MM-dd");

            var client = new MongoClient();
            var database = client.GetDatabase("TSStorageData");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("results");

#if LOG
            Console.WriteLine("Collection heeft {0} regels gevonden!", collection.CountDocuments(new BsonDocument()));
#endif

            List<BsonDocument> list = GetMongoData.GetResultsDataSet(collection, "2019-03-07");

#if LOG
            Console.WriteLine("Collection na query toepassing heeft {0} regels!", list.Count);
#endif

            TMS_ResultSet.ResultSet results = new TMS_ResultSet.ResultSet(list);

#if LOG
            Console.WriteLine("Results heeft {0} regels!", results._resultSet.Count);

            foreach(TestResult result in results._resultSet)
            {
                Console.WriteLine(result.ToString());
            }
            Console.WriteLine("Query is klaar met uitvoeren...<druk op enter om te stoppen>...");
            Console.ReadLine();
#endif
        }
    }
}
