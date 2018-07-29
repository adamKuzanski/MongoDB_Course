using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}
