using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;

namespace WorkingWithMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.WriteLine("Press key to exit");
            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            var client = new MongoClient();

            IMongoDatabase db = client.GetDatabase("school");

            var collection = db.GetCollection<Students>("students");
            var newStudents = CreateNewStudents();

            await collection.InsertManyAsync(newStudents);
        }

        private static IEnumerable<Students> CreateNewStudents()
        {
            var studnet1 = new Students
            {
                FirstName = "Maciek",
                LastName = "Jagusiak",
                Subjects = new List<string> {"English", "Mathematics", "Physics", "Chemistry"},
                Class = "3B",
                Age = 15
            };

            var studnet2 = new Students
            {
                FirstName = "Piotrek",
                LastName = "Ładoński",
                Subjects = new List<string> {"Informatyka ", "Kodowanie", "Programming", "Algorythms"},
                Class = "3B",
                Age = 19
            };

            var newStudents = new List<Students> {studnet1, studnet2};

            return newStudents;
        }
    }
}
        