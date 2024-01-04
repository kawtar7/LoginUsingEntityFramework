using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LoginLogoutEF.Models
{
    public class User 
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
