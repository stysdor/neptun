using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    /// <summary>
    /// Represents User table from datebase.
    /// </summary>
    public class User : PersonalInfo
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsEmailConfirmed { get; set; }

    }
}
