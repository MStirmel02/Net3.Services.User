using Net3.Services.User.UserServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserServices.Services
{
    public interface IUserService
    {
        Task<bool> UserSignupAsync(UserModel user);
    }
}
