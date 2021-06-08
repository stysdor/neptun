using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.SeedData
{
    class MovieJSONRoot
    {  
            public string id { get; set; }
            public string title { get; set; }
            public string poster { get; set; }
            public string overview { get; set; }
            public DateTime release_date { get; set; }
            public List<string> genres { get; set; }
        
    }
}
