using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Services.User.UserServices.Models
{
    public class UserModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
