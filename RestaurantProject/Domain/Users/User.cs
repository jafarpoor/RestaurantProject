using Domain.Attributes;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
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

        public ICollection<UserToken> userTokens { get; set; } = new List<UserToken>();
    }
}
