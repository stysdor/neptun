using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    /// <summary>
    /// Represents Theatre table from datebase.
    /// </summary>
    public class Theatre :EntityBase
    {
        [Required]
        public string Name { get; set; }
    }
}
