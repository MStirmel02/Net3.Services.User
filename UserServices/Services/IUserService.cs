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
        HttpStatusCode UserLogin(string user, string pass);
    }
}
