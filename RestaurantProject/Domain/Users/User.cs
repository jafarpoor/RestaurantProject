using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    [Auditable]
    public class User :IdentityUser
    {
        [Required]
        public string FristName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }
    }
}
