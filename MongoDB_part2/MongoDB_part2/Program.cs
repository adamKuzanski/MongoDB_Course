using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB_part2
{
    class Program
    {

        static void Main(string[] args)
        {
            MainAsync().Wait();
            
            Console.WriteLine("Press enter to exit");
            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            var client = new MongoClient();

            IMongoDatabase db = client.GetDatabase("school");

            var collection = db.GetCollection<BsonDocument>("students");

            using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    foreach (BsonDocument document in batch)
                    {
                        Console.WriteLine(document);
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("#########################################################################3");
            Console.WriteLine();
            Console.WriteLine();

            FilterDefinition<BsonDocument> filter = FilterDefinition<BsonDocument>.Empty;
            FindOptions<BsonDocument> options = new FindOptions<BsonDocument>
            {
                BatchSize = 2,
                NoCursorTimeout = false
            };

            using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(filter, options))
            {
                var batch = 0;
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<BsonDocument> documents = cursor.Current;
                    batch++;

                    Console.WriteLine($"Batch: {batch}");

                    foreach (BsonDocument document in documents)
                    {
                        Console.WriteLine(document);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine($"Total Batch:  {batch}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("#########################################################################3");
            Console.WriteLine();
            Console.WriteLine();

            await collection.Find(FilterDefinition<BsonDocument>.Empty).ForEachAsync(doc => Console.WriteLine(doc));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("#########################################################################3");
            Console.WriteLine();
            Console.WriteLine();

            var filterOpt = new BsonDocument("FirstName", "Piotrek");
            await collection.Find(filterOpt).ForEachAsync(document => Console.WriteLine(document));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("#########################################################################3");
            Console.WriteLine();
            Console.WriteLine();

            var jFilter = "{ FirstName: 'Piotrek' }";
            await collection.Find(jFilter).ForEachAsync(document => Console.WriteLine(document));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("#########################################################################3");
            Console.WriteLine();
            Console.WriteLine();

            var bFilter = new FilterDefinitionBuilder<BsonDocument>().Lt("age", 21);
            await collection.Find(bFilter).ForEachAsync(document => Console.WriteLine(document));

            var linqFilter = new FilterDefinitionBuilder<Students>().Lt( student => student.Age, 25);

            var collection2 = db.GetCollection<Students>("students");
            await collection2.Find(student => student.Age < 25 && student.FirstName != "Peter")
                .ForEachAsync(student => Console.WriteLine($"Id: {student.Id}, FirstName: {student.FirstName}, LastName: {student.LastName}"));
        }        
    }
}
