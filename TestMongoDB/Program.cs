using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TestMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // var client = new MongoClient();

            var connectionString = "mongodb://192.168.1.209:27017";
            var client = new MongoClient(connectionString);

            IMongoDatabase database = client.GetDatabase("bookstore");

            var document = new BsonDocument
            {
                {"bookname", BsonValue.Create(".net core3.1 with mongodb")},
                {"description", new BsonString("这是一本关于在.net core3.1中使用mongodb进行开发的教程")},
                {"tags", new BsonArray(new[] {".net core", "mongodb"}) },
                {"remark", "C#是世界上最好的语言" },
                {"publishyear", 2020 }
            };


            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("books");

            collection.InsertOne(document);


            Console.WriteLine("Test Here!");
        }
    }
}
