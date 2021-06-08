using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace neptun.API.DTO
{
    public class ShowingDTO
    {
        public string MovieDTO { get; set; }
        
        public string TheatreName { get; set; }
        public DateTime ShowingDateTime { get; set; }
    }
}
