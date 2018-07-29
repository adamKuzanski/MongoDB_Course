using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MongoDB_part3
{
    class F1Drivers
    {
        public ObjectId id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Team { get; set; }
        public int Number { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> HistoricalTeams { get; set; }
        public bool WasChampion { get; set; }
    }
}
