using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


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
