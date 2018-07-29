using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MongoDB_part2
{
    class Students
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}
