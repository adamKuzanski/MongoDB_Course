using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoDB_part3
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            IMongoDatabase db = client.GetDatabase("F1Community");
            var collection = db.GetCollection<F1Drivers>("F1Drivers");

            await collection.Find(f1driver => f1driver.Age < 30).Sort("{Age: 1}").ForEachAsync(f1driver =>
                Console.WriteLine(f1driver.FirstName + " " + f1driver.LastName + " " + f1driver.Age));


        }









        private static IEnumerable<F1Drivers> CreateNewDrivers()
        {
            var driver1 = new F1Drivers
            {
                FirstName = "Lewis",
                LastName = "Hamilton",
                Nationality = "Great Britian",
                Number = 44,
                Team = "Mercedes",
                Age = 25,
                HistoricalTeams = new List<string>() {"McLaren", "Mercedes"},
                WasChampion = true
            };

            var driver2 = new F1Drivers
            {
                FirstName = "Valtteri",
                LastName = "Bottas",
                Nationality = "Finland",
                Number = 77,
                Team = "Mercedes",
                Age = 29,
                HistoricalTeams = new List<string>() { "Williams", "Mercedes" },
                WasChampion = false
            };

            var driver3 = new F1Drivers
            {
                FirstName = "Sebastian",
                LastName = "Vettel",
                Nationality = "Finland",
                Number = 5,
                Team = "Ferrari",
                Age = 31,
                HistoricalTeams = new List<string>() { "BMW Sauber", "RedBull Racing", "Ferrari" },
                WasChampion = true
            };

            var driver4 = new F1Drivers
            {
                FirstName = "Kimmi",
                LastName = "Raikkonen",
                Nationality = "Finland",
                Number = 7,
                Team = "Ferrari",
                Age = 39,
                HistoricalTeams = new List<string>() { "Sauber", "McLaren", "Ferrari" },
                WasChampion = true
            };

            var driver5 = new F1Drivers
            {
                FirstName = "Robert",
                LastName = "Kubica",
                Nationality = "Poland",
                Number = 74,
                Team = "Williams",
                Age = 34,
                HistoricalTeams = new List<string>() { "BMW Sauber", "Renault", "Williams" },
                WasChampion = false
            };

            var driver6 = new F1Drivers
            {
                FirstName = "Michael",
                LastName = "Schumacher",
                Nationality = "Germany",
                Number = 1,
                Team = "",
                Age = 49,
                HistoricalTeams = new List<string>() { "Jordan", "Benetton", "Ferrari" },
                WasChampion = true
            };

            var driver7 = new F1Drivers
            {
                FirstName = "Daniel",
                LastName = "Ricciardo",
                Nationality = "Australian",
                Number = 3,
                Team = "RedBull Racing",
                Age = 29,
                HistoricalTeams = new List<string>() { "Toro Rosso", "RedBull Racing"},
                WasChampion = false
            };

            var driver8 = new F1Drivers
            {
                FirstName = "Max",
                LastName = "Verstappen",
                Nationality = "Dutch",
                Number = 33,
                Team = "RedBull Racing",
                Age = 21,
                HistoricalTeams = new List<string>() { "Toro Rosso", "RedBull Racing" },
                WasChampion = true
            };

            var newDrivers =
                new List<F1Drivers> {driver1, driver2, driver3, driver4, driver5, driver6, driver7, driver8};

            return newDrivers;

        }
    }
}
